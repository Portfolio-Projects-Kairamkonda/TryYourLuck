using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardData : MonoBehaviour
{
    private Button _cardButton;
    private TextMeshProUGUI _cardText;
    private string _selectedCardData;

    private ILogger debug;

    private void Awake()
    {
        _cardButton = GetComponent<Button>();
        _cardText = _cardButton.GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        debug = new NoLogging();
        _cardButton.onClick.AddListener(ButtonClicked);
    }

    void ButtonClicked()
    {
        _selectedCardData = _cardText.text;
        _cardButton.interactable = false;
        EventManager.InvokeSelectedCardData(_selectedCardData);
        
        debug.Log($"{_selectedCardData}: Button clicked");
    }
}
