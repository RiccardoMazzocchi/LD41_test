using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    public enum TurnState { PlayerTurn, OtherTurn };

    private TurnState _currentTurnState;
    public TurnState CurrentTurnState
    {
        get
        {
            return _currentTurnState;
        }
        set
        {
            _currentTurnState = value;
            OnTurnStart(_currentTurnState);
        }
    }


    void OnTurnStart(TurnState newTurn)
    {
        switch (switch_on)
        {
            default:
        }
    }
}
