using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleState : CardBaseState
{
    public override void OnStart(CardStateManager cardStateManager)
    {
        Debug.Log(cardStateManager.currentState);
        cardStateManager.ShuffleCardNumbers();
        cardStateManager.BlankCards();
        cardStateManager.ChangeToGuessState();
    }

    public override void OnButtonEvent(CardStateManager cardStateManager)
    {
      
    }
}
