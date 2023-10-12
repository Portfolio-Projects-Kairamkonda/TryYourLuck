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

        debug.Log(cardStateManager.currentState.ToString());

        cardStateManager.SwitchState(cardStateManager.pickState);

    }

    public override void OnButtonEvent(CardStateManager cardStateManager)
    {

    }
}
