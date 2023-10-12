using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessState : CardBaseState
{
    public override void OnStart(CardStateManager cardStateManager)
    {
        debug.Log(cardStateManager.currentState.ToString());
        cardStateManager.RevealCards(true);
    }

    public override void OnButtonEvent(CardStateManager cardStateManager)
    {
        
    }

}
