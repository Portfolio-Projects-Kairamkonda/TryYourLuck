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
    private TextMeshProUGUI _mainButtonText;

    private List<char> _cardNumbers;
    private const char blankCardChar = '*';

    private ILogger debug;

    public CardBaseState currentState;

    public IdleState idleState = new IdleState();
    public RevealState revealState = new RevealState();
    public PickState pickState = new PickState();
    public ShuffleState shuffleState = new ShuffleState();
    public GuessState guessState = new GuessState();

    #region Unity methods

    private void Awake()
    {
        debug = new Logger();
        _cardNumbers = new List<char>();
        currentState = idleState;

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
    public void BlankCards()
    {
        foreach (var buttonText in _getButtonsText)
            buttonText.text = blankCardChar.ToString();

        _mainButtonText.text = "Reveal";
    }

    #endregion

    #region Logic: Reveal State

    // Reveal Numbers on the cards
    public void RevealCards(bool buttonActiveState)
    {
        for (int i = 0; i < _cardNumbers.Count; i++)
        {
            _getButtonsText[i].text = _cardNumbers[i].ToString();
        }

       
        _mainButtonText.text = "Pick";
    }

    #endregion

    #region Common methods

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
        SwitchState(idleState);
    }

    #endregion

    #region Logic methods


    // Shuffle state logic
    private void ChangetoShuffleState()
    {
        SwitchState(shuffleState);
        //EventManager.onPickedState -= ChangetoShuffleState;
        _mainButton.interactable = false;
        _mainButton.GetComponentInChildren<TextMeshProUGUI>().text = "Shuffle";

        foreach (var button in _getButtons)
        {
            button.interactable = false;
        }
    }

    // Shuffle Delay
    public IEnumerator ShuffleDelay()
    {
        yield return new WaitForSeconds(5f);
        SwitchState(guessState);
        _mainButton.GetComponentInChildren<TextMeshProUGUI>().text = "Guess";
        _mainButton.interactable = false;
        foreach (var button in _getButtons)
        {
            button.interactable = true;
        }
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
