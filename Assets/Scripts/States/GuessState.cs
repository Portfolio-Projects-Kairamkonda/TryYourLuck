using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuessState : CardBaseState
{

    public override void OnStart(CardStateManager cardStateManager)
    {
        cardStateManager._mainButtonText.text = "Guess";
        cardStateManager.MainButtonInteractivity(false);
        cardStateManager.ButtonsInteractivity(true);
        cardStateManager.RevealCards();

        debug.Log(cardStateManager.currentState.ToString());
    }

    public override void OnButtonEvent(CardStateManager cardStateManager)
    {
        
    }

}
