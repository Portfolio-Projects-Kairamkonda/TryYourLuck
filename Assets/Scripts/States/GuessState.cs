using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessState : CardBaseState
{
    public override void OnStart(CardStateManager cardStateManager)
    {
        Debug.Log(cardStateManager.currentState);
    }

    public override void OnButtonEvent(CardStateManager cardStateManager)
    {
        
    }

}
