using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager 
{
    public delegate void OnSelectedCardData(string cardData);
    public static event OnSelectedCardData onSelectedCardData;

    public delegate void OnSelectedCardEffects();
    public static event OnSelectedCardEffects onSelectedCardEffects;

    public static void InvokeSelectedCardData(string cardData)
    {
        if (onSelectedCardData != null)
            onSelectedCardData(cardData);

        if (onSelectedCardEffects != null)
            onSelectedCardEffects();
    }

    public delegate void OnPickedState();
    public static event OnPickedState onPickedState;

    public static void InvokeOnPickedState()
    {
        if (onPickedState != null)
            onPickedState();
    }

    public delegate void OnVerifiedState();
    public static event OnVerifiedState onVerifiedState;

    public static void InvokeVerifiedState()
    {
        if (onVerifiedState != null)
            onVerifiedState();
    }
}
