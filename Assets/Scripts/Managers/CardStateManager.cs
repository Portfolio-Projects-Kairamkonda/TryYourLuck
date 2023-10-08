using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardStateManager : MonoBehaviour
{
    public CardBaseState cardCurrentState;

    [SerializeField]
    private Button[] GetButtons;

    [SerializeField]
    private Button mainButton;

    public RevealState revealState = new RevealState();

    private void Start()
    {
        cardCurrentState = revealState;
        cardCurrentState.EnterState(this);
    }

    public void SwitchState(CardBaseState state)
    {
        cardCurrentState = state;
        cardCurrentState.EnterState(this);
    }
}
