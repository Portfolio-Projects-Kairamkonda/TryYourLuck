using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardStateManager : MonoBehaviour
{
    public CardBaseState cardCurrentState;

    public Button[] _getButtons;

    public Button mainButton;
    private string mainButtonText;

    private List<char> _cardNumbers = new List<char>{'K','Q','J','A'};

    private const char blankCardChar = '*';

    public IdleState idleState = new IdleState();
    public RevealState revealState = new RevealState();
    public PickState pickState = new PickState();
    public ShuffleState shuffleState = new ShuffleState();
    public GuessState guessState = new GuessState();

    private void Awake()
    {
        mainButtonText = mainButton.GetComponentInChildren<TextMeshProUGUI>().text;
    }

    private void Start()
    {
        cardCurrentState = idleState;
        cardCurrentState.EnterState(this);

        mainButton.onClick.AddListener(() => UpdateButtonData(cardCurrentState));
    }

    private void OnEnable()
    {
        EventManager.onRestartGame += RestartGame;
    }

    private void OnDisable()
    {
        EventManager.onRestartGame -= RestartGame;    
    }

    #region Add & Sub methods events

    public void AddPickedStateEvent()
    {
        EventManager.onPickedState += ChangetoShuffleState;
    }

    public void SubPickStateEvent()
    {
        EventManager.onPickedState -= ChangetoShuffleState;
    }

    public void AddVerifyStateEvent()
    {
        EventManager.onVerifiedState += VerifyGuessData;
    }
    public void SubVerifyStateEvent()
    {
        EventManager.onVerifiedState -= VerifyGuessData;
    }

    #endregion

    #region Common methods
    // Switch State 
    public void SwitchState(CardBaseState state)
    {
        cardCurrentState = state;
        cardCurrentState.EnterState(this);
    }

    // Update the button Event 
    public void UpdateButtonData(CardBaseState state)
    {
        cardCurrentState = state;
        cardCurrentState.ButtonEvent(this);
    }

    private void RestartGame()
    {
        SwitchState(idleState);
    }
    #endregion

    #region Logic methods

    private void VerifyGuessData()
    {
        RevealCards();
    }


    // Shuffle state logic
    private void ChangetoShuffleState()
    {
        SwitchState(shuffleState);
        //EventManager.onPickedState -= ChangetoShuffleState;
        mainButton.interactable = false;
        mainButton.GetComponentInChildren<TextMeshProUGUI>().text = "Shuffle";

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
        mainButton.GetComponentInChildren<TextMeshProUGUI>().text = "Guess";
        mainButton.interactable = false;
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

    // Blank Cards
    public void BlankCards()
    {
        foreach (var button in _getButtons)
        {
            button.GetComponentInChildren<TextMeshProUGUI>().text = blankCardChar.ToString();
        }
    }

    // Reveal Numbers on the cards
    public void RevealCards()
    {
        for (int i = 0; i < _cardNumbers.Count; i++)
        {
            _getButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = _cardNumbers[i].ToString();
        }

        mainButton.interactable = false;
        mainButton.GetComponentInChildren<TextMeshProUGUI>().text = "Pick";
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
