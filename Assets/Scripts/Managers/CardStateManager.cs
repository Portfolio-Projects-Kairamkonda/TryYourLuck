using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardStateManager : MonoBehaviour
{
    public Button[] _getButtons;
    private TextMeshProUGUI[] _getButtonsText;

    public Button _mainButton;
    public TextMeshProUGUI _mainButtonText;

    private List<char> _cardNumbers;
    private const char blankCardChar = '*';

    private ILogger debug;

    public CardBaseState currentState;

    private AudioSource _audio;

    public AudioClip _shuffleAudio;
    public AudioClip _closeAudio;

    public IdleState idleState = new IdleState();
    public RevealState revealState = new RevealState();
    public PickState pickState = new PickState();
    public ShuffleState shuffleState = new ShuffleState();
    public GuessState guessState = new GuessState();
    public CelebrationState celebrationState = new CelebrationState();

    #region Unity methods

    private void OnEnable()
    {
        EventManager.onRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        EventManager.onRestartGame -= RestartGame;
    }

    private void Awake()
    {
        debug = new Logger();
        _cardNumbers = new List<char>();
        currentState = idleState;

        _audio = this.GetComponent<AudioSource>();
        _getButtonsText = new TextMeshProUGUI[_getButtons.Length];

        for (int i = 0; i < _getButtons.Length; i++)
        {
            _getButtonsText[i]=_getButtons[i].GetComponentInChildren<TextMeshProUGUI>();
        }

        _mainButtonText=_mainButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        currentState.OnStart(this);

        _mainButton.onClick.AddListener(() => ButtonEvent(currentState));
    }
    

    #endregion

    #region Logic: idle state

    /// <summary>
    /// Default card numbers
    /// </summary>
    public void DefaultCardData()
    {
        _cardNumbers.Clear();

        _cardNumbers.Add('K');
        _cardNumbers.Add('Q');
        _cardNumbers.Add('J');
        _cardNumbers.Add('A');

        debug.Log($"Default card numbers count is {_cardNumbers.Count}");
    }

    /// <summary>
    /// Blank card with stars
    /// </summary>
    public void BlankCardsText()
    {
        foreach (var buttonText in _getButtonsText)
            buttonText.gameObject.SetActive(false);
            //buttonText.text= blankCardChar.ToString();
    }

    /// <summary>
    /// Blank card with stars
    /// </summary>
    public void RevealCardsText()
    {
        foreach (var buttonText in _getButtonsText)
            buttonText.gameObject.SetActive(true);
        //buttonText.text= blankCardChar.ToString();

    }
    #endregion

    #region Logic: Reveal State

    // Reveal Numbers on the cards
    public void RevealCards()
    {
        for (int i = 0; i < _cardNumbers.Count; i++)
            _getButtonsText[i].text = _cardNumbers[i].ToString();

    }

    #endregion

    #region Shuffle State

    public void AddTriggerShuffleStatEvent()
    {
        EventManager.onCardSelected += TriggerShuffleState;
    }

    public void SubTriggerShuffleStatEvent()
    {
        EventManager.onCardSelected -= TriggerShuffleState;
    }

    public void TriggerShuffleState()
    {
        SwitchState(shuffleState);
        _mainButtonText.text = "Shuffle";
    }

    // Shuffle Delay
    public IEnumerator ShuffleDelay()
    {
        PlayStateAudio(_shuffleAudio,true);
        yield return new WaitForSeconds(2f);

        SwitchState(guessState);
        PlayStateAudio(null, false);

        SubTriggerShuffleStatEvent();
    }

    public void ShuffleCardNumbers()
    {
        _cardNumbers = ShuffleCharacters(_cardNumbers);
    }

    // Guess State
    public void ChangeToGuessState()
    {
        StartCoroutine(ShuffleDelay());
    }
    #endregion

    #region Common methods

    // Play Audio
    public void PlayStateAudio(AudioClip clip, bool loop)
    {
        _audio.clip = clip;
        _audio.loop = loop;
        _audio.Play();
    }

    // Switch State 
    public void SwitchState(CardBaseState state)
    {
        currentState = state;
        currentState.OnStart(this);
    }

    // Update the button Event 
    public void ButtonEvent(CardBaseState state)
    {
        currentState = state;
        currentState.OnButtonEvent(this);
    }

    public void ButtonsInteractivity(bool status)
    {
        for (int i = 0; i < _getButtons.Length; i++)
            _getButtons[i].interactable = status;
    }

    public void MainButtonInteractivity(bool status)
    {
        _mainButton.interactable = status;
    }

    private void RestartGame()
    {
        SwitchState(celebrationState);
    }

    public void StartDelayingState(CardBaseState  state, float time)
    {
        StartCoroutine(DelayState(state, time));
    }

    public IEnumerator DelayState(CardBaseState state, float time)
    {
        yield return new WaitForSeconds(time);
        SwitchState(state);
        PlayStateAudio(_closeAudio,false);
    }


    #endregion

    #region Randomize methods

    public List<char> ShuffleCharacters(List<char> charList)
    {
        int n = charList.Count;
        System.Random rng = new System.Random();

        for (int i = n - 1; i > 0; i--)
        {
            int j = rng.Next(0, i + 1);

            // Swap charList[i] and charList[j]
            char temp = charList[i];
            charList[i] = charList[j];
            charList[j] = temp;
        }

        return charList;
    }

    #endregion


}
