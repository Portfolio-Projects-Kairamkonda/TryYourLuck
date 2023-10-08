using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CardBaseState 
{
    public string message;

    public abstract void EnterState(CardStateManager cardStateManager);

    public abstract void ButtonEvent(CardStateManager cardStateManager);
}


