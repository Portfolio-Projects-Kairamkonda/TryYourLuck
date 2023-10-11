using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardManager : MonoBehaviour
{
    public Button[] getButtons;

    public Button revealButton;

    public string cardData;

    private List<char> _cardNumbers= new List<char>(new List<char> { 'K', 'Q', 'J', 'A'});

    private ILogger debug;

    private void Awake()
    {
        debug = new NoLogging();
    }

    private void Start()
    {
        revealButton.onClick.AddListener(()=> AddNumbersToCards(_cardNumbers));
    }


    #region Class methods

   

    /// <summary>
    /// 
    /// </summary>
    /// <param name="buttons"></param>
    /// <param name="cardNumbers"></param>
    private void AddNumbersToCards(List<char> cardNumbers)
    {
        for (int i = 0; i < getButtons.Length; i++)
        {
            getButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = cardNumbers[i].ToString();
        }

        revealButton.GetComponentInChildren<TextMeshProUGUI>().text = "Pick";
        revealButton.interactable = false;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="cardData"></param>
    private void SelectedCardUpdate(string cardData)
    {
        debug.Log($"Updated selected card data is {cardData}");
        revealButton.GetComponentInChildren<TextMeshProUGUI>().text = "Shuffle";
        BlankCards();
        StartCoroutine(ShuffleCardTime());
    }

    IEnumerator ShuffleCardTime()
    {
        _cardNumbers = ShuffleCharacters(_cardNumbers);
        yield return new WaitForSeconds(5f);
        revealButton.GetComponentInChildren<TextMeshProUGUI>().text = "Guess";
        revealButton.interactable = true;
    }

    private void BlankCards()
    {
        for (int i = 0; i < getButtons.Length; i++)
        {
            getButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "*";

            getButtons[i].interactable = false;
        }
    }

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

    #region Debug methods
    /// <summary>
    /// 
    /// </summary>
    /// <param name="newList"></param>
    private void RevealList(List<string> newList)
    {
        string numbersList = $"Numbers are ";

        for (int i = 0; i < newList.Count; i++)
        {
            numbersList += newList[i]+", ";
        }

        debug.Log(numbersList);
    }

    public void LoadCardData()
    {
        debug.Log($"Card data from CardManager is {cardData}");
    }

    #endregion

    #region Data methods
    /// <summary>
    /// Numbers of card in data
    /// </summary>
    private void CardNumbersData()
    {
        
    }
    #endregion
}
