using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CardBaseState 
{
    public ILogger debug;

    public CardBaseState()
    {
        debug = new Logger();
    }

    public abstract void OnStart(CardStateManager cardStateManager);

    public abstract void OnButtonEvent(CardStateManager cardStateManager);
}


