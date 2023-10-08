using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CardBaseState 
{
    public string message;

    public abstract void EnterState(CardStateManager cardStateManager);
}


