using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleState : CardBaseState
{
    public override void ButtonEvent(CardStateManager cardStateManager)
    {
        throw new System.NotImplementedException();
    }

    public override void EnterState(CardStateManager cardStateManager)
    {
        Debug.Log(cardStateManager.cardCurrentState);
        cardStateManager.SubPickStateEvent();
        cardStateManager.ShuffleCardNumbers();
        cardStateManager.BlankCards();
        cardStateManager.ChangeToGuessState();
        
    }
}
