using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickState : CardBaseState
{
    public override void OnStart(CardStateManager cardStateManager)
    {
        cardStateManager.ButtonsInteractivity(true);
        cardStateManager.MainButtonInteractivity(false);

        debug.Log(cardStateManager.currentState.ToString());
    }

    public override void OnButtonEvent(CardStateManager cardStateManager)
    {
        
    }
  
}
