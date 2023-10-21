using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShuffleState : CardBaseState
{
    public override void OnStart(CardStateManager cardStateManager)
    {
        cardStateManager.MainButtonInteractivity(false);
        cardStateManager.ButtonsInteractivity(false);

        cardStateManager.BlankCardsText();
        cardStateManager.ShuffleCardNumbers();

        // Wait period for shuffle
        cardStateManager.ChangeToGuessState();

        debug.Log(cardStateManager.currentState.ToString());
    }

    public override void OnButtonEvent(CardStateManager cardStateManager)
    {
      
    }
}
 