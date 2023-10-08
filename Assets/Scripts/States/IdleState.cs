using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CardBaseState
{
    public override void EnterState(CardStateManager cardStateManager)
    {
        cardStateManager.BlankCards();
        Debug.Log(cardStateManager.cardCurrentState);
    }

    public override void ButtonEvent(CardStateManager cardStateManager)
    {
        cardStateManager.SwitchState(cardStateManager.revealState);
    }


}
