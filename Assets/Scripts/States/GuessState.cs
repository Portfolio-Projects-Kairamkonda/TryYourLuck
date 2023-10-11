using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessState : CardBaseState
{
    public override void ButtonEvent(CardStateManager cardStateManager)
    {
        
    }

    public override void EnterState(CardStateManager cardStateManager)
    {
        Debug.Log(cardStateManager.cardCurrentState);
        cardStateManager.AddVerifyStateEvent();
    }
}
