using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {



	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.tm.CurrentMacroTurn == TurnManager.MacroTurn.PlayerTurn)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1, 0, 0);
                GameManager.Instance.tm.ChangeTurn();
            }
        }
	}
}
