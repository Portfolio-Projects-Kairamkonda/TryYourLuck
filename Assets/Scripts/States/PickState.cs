using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickState : CardBaseState
{
    public override void OnStart(CardStateManager cardStateManager)
    {
        cardStateManager._mainButtonText.text = "Pick";
        cardStateManager.ButtonsInteractivity(true);
        cardStateManager.MainButtonInteractivity(false);

        cardStateManager.AddTriggerShuffleStatEvent();

        debug.Log(cardStateManager.currentState.ToString());
    }

    public override void OnButtonEvent(CardStateManager cardStateManager)
    {
        
    }

    
}
