using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealState : CardBaseState
{
    public override void OnStart(CardStateManager cardStateManager)
    {
        cardStateManager.RevealCards(true);
        cardStateManager.ButtonsInteractivity(false);
        cardStateManager.MainButtonInteractivity(true);

        cardStateManager.SwitchState(cardStateManager.pickState);

        debug.Log(cardStateManager.currentState.ToString());
    }

    public override void OnButtonEvent(CardStateManager cardStateManager)
    {

    }
}
