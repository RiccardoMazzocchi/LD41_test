using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour {

    int currentEnemies;
    int i;

    //general turn enum, will be the first check always
    public enum MacroTurn { PlayerTurn, OtherTurn };

    private MacroTurn _currentMacroTurn;
    public MacroTurn CurrentMacroTurn
    {
        get
        {
            return _currentMacroTurn;
        }
        set
        {
            _currentMacroTurn = value;
            OnTurnStart(_currentMacroTurn);
        }
    }

    //macro phase enum, you're either in the Menu, Deck building phase, or game phase
    public enum MacroPhase { Menu, Deck, Game}

    private MacroPhase _currentMacroPhase;
    public MacroPhase CurrentMacroPhase
    {
        get
        {
            return _currentMacroPhase;
        }
        set
        {
            if (MacroPhaseChange(value))
            {
                _currentMacroPhase = value;
                OnMacroPhaseStart(_currentMacroPhase);
            }
        }
    }

    //only active if inside the game phase? you're either moving/jumping, or using an action card
    public enum TurnState { Movement, Action }

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
            OnStateStart(_currentTurnState);
        }
    }

    private void Start()
    {
        //debugging
        CurrentMacroTurn = MacroTurn.PlayerTurn;
        CurrentMacroPhase = MacroPhase.Menu;
        CurrentTurnState = TurnState.Movement;
    }

    private void Update()
    {
    //  //debugging
    //  if (Input.GetKeyDown(KeyCode.E))
    //  {
    //      if (CurrentMacroPhase == MacroPhase.Menu)
    //      {
    //          CurrentMacroPhase = MacroPhase.Deck;
    //      }
    //      else if (CurrentMacroPhase == MacroPhase.Deck)
    //      {
    //          CurrentMacroPhase = MacroPhase.Game;
    //      }
    //   }
    }

    bool MacroPhaseChange(MacroPhase newPhase)
    {
        switch (newPhase)
        {
            case MacroPhase.Menu:
                return true;
            case MacroPhase.Deck:
                if (CurrentMacroPhase != MacroPhase.Menu)
                    return false;
                return true;
            case MacroPhase.Game:
                if (CurrentMacroPhase != MacroPhase.Deck)
                    return false;
                return true;
            default:
                return false;
        }
    }

    bool TurnStateChange(TurnState newState)
    {
        switch (newState)
        {
            case TurnState.Movement:
                if (CurrentMacroPhase != MacroPhase.Game)
                    return false;
                return true;
            case TurnState.Action:
                if (CurrentTurnState != TurnState.Movement)
                    return false;
                return true;
            default:
                return false;
        }
    }

    void OnStateStart(TurnState stateStart)
    {
        switch (stateStart)
        {
            case TurnState.Movement:
                Debug.Log("Movement TurnState");

                Enemy[] enemies = FindObjectsOfType<Enemy>();
                currentEnemies = enemies.Length;
                
                if (CurrentMacroTurn == MacroTurn.OtherTurn)
                {
                    foreach (Enemy enemy in enemies)
                    {
                        enemy.Movement();
                        i++;
                        if (i == currentEnemies)
                        {
                            ChangeTurn();
                            i = 0;
                        }
                    }
                }
                break;
            case TurnState.Action:
                Debug.Log("Action TurnState");
                break;
            default:
                break;
        }
    }

    void OnMacroPhaseStart(MacroPhase macroPhaseStart)
    {
        switch (macroPhaseStart)
        {
            case MacroPhase.Menu:
                Debug.Log("You are now in MacroPhase Menu");
                break;
            case MacroPhase.Deck:
                Debug.Log("You are now in MacroPhase Deck");
                break;
            case MacroPhase.Game:
                Debug.Log("You are now in MacroPhase Game");
                break;
            default:
                break;
        }
    }

    void OnTurnStart(MacroTurn turnStart)
    {
        switch (CurrentMacroPhase)
        {
            case MacroPhase.Menu:
                break;
            case MacroPhase.Deck:
                break;
            case MacroPhase.Game:
                CurrentTurnState = TurnState.Movement;
                if (CurrentMacroTurn == MacroTurn.PlayerTurn)
                {
                    GameManager.Instance.cm.FillCards();
                }
                break;
            default:
                break;
        }
    }

    public void ChangeTurn()
    {
        if (CurrentMacroTurn == MacroTurn.PlayerTurn)
        {
            Debug.Log("Other Turn");
            CurrentMacroTurn = MacroTurn.OtherTurn;
        }
        else if (CurrentMacroTurn == MacroTurn.OtherTurn)
        {
            Debug.Log("Player Turn");
            CurrentMacroTurn = MacroTurn.PlayerTurn;
        }
    }
}
