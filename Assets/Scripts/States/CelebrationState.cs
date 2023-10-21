using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CelebrationState : CardBaseState
{
    public override void OnStart(CardStateManager cardStateManager)
    {
        cardStateManager.RevealCardsText();
        cardStateManager.StartDelayingState(cardStateManager.idleState, 3f);
        cardStateManager._mainButtonText.text = "Perfect";
    }

    public override void OnButtonEvent(CardStateManager cardStateManager)
    {
      
    }

}
