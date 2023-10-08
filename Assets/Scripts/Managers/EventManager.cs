using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager 
{
    public delegate void SelectedCardData(string cardData);
    public static event SelectedCardData onSelectedCardData;

    public delegate void OnSelectedCardEffects();
    public static event OnSelectedCardEffects onSelectedCardEffects;

    public static void InvokeSelectedCardData(string cardData)
    {
        if (onSelectedCardData != null)
            onSelectedCardData(cardData);

        if (onSelectedCardEffects != null)
            onSelectedCardEffects();
    }
}
