using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager 
{
    public delegate void OnSelectedCardData(string cardData);
    public static event OnSelectedCardData onSelectedCardData;

    public delegate void OnSelectedCardEffects();
    public static event OnSelectedCardEffects onSelectedCardEffects;

    public delegate void OnPickedState();
    public static event OnPickedState onPickedState;

    public delegate void OnVerifiedState();
    public static event OnVerifiedState onVerifiedState;

    public delegate void OnRestartGame();
    public static event OnRestartGame onRestartGame;

    public  EventManager()
    {
        Debug.Log("I am a constructor of Event Manager Class");
    }

    public static string newCardValue;

    public static void InvokeSelectedCardData(string cardData)
    {
        if(onSelectedCardData!=null)
        {
            onSelectedCardData(cardData);
        }

        if(onPickedState!=null)
        {
            onPickedState();
        }

        if (newCardValue==null)
        {
            newCardValue = cardData;
            Debug.Log($"Selected card Data is {newCardValue}");
        }
        if(newCardValue!=cardData)
        {
            Debug.Log("Try again! ");
        }
        if(newCardValue==cardData)
        {
            Debug.Log($"You are card {newCardValue} & you have guessed the correct your card {cardData}");

            InvokeRestartGame();
        }
    }

    public static void InvokeRestartGame()
    {
        if (onRestartGame!= null)
            onRestartGame();

    }

    public static void InvokeOnPickedState()
    {
        if (onPickedState != null)
            onPickedState();
    }

    public static void InvokeVerifiedState()
    {
        if (onVerifiedState != null)
            onVerifiedState();
    }
   
}
