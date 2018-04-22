using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public enum Direction { Left, Right }
    Direction currentDirection;

    public GameObject leftSlot, rightSlot, actionSlot; 

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.tm.CurrentMacroTurn == TurnManager.MacroTurn.PlayerTurn && GameManager.Instance.tm.CurrentMacroPhase == TurnManager.MacroPhase.Game)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1, 0, 0);
                GameManager.Instance.tm.ChangeTurn();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(1, 0, 0);
                GameManager.Instance.tm.ChangeTurn();
            }
        }
	}

    public void Movement()
    {
        //if run, vector3 ((-)1,0,0)
        if (rightSlot.transform.childCount > 0)
        {
            if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "RunCard")
            {
                transform.position += new Vector3(1, 0, 0);
                GameManager.Instance.tm.ChangeTurn();
            }

            else if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "JumpCard")
            {
                transform.position += new Vector3(1, 1, 0);

                if (actionSlot.transform.childCount > 0)
                {
                    if (actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "DoubleJumpCard")
                    {
                        transform.position += new Vector3(1, 1, 0);
                        GameManager.Instance.tm.ChangeTurn();
                    }
                }
                else
                {
                    GameManager.Instance.tm.ChangeTurn();
                }

            }
            else if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "HighJumpCard")
            {
                transform.position += new Vector3(1, 1, 0);

                if (actionSlot.transform.childCount > 0)
                {
                    if (actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "DoubleJumpCard")
                    {
                        transform.position += new Vector3(1, 1, 0);
                        GameManager.Instance.tm.ChangeTurn();
                    }
                }
                else
                {
                    GameManager.Instance.tm.ChangeTurn();
                }
            }
            else if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "JumpUpCard")
            {
                transform.position += new Vector3(0, 1, 0);
                GameManager.Instance.tm.ChangeTurn();
            }
            else if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "StopCard")
            {
                transform.position += new Vector3(0, 0, 0);
                GameManager.Instance.tm.ChangeTurn();
            }
        }


        if (leftSlot.transform.childCount > 0)
        {
            if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "RunCard")
            {
                transform.position -= new Vector3(1, 0, 0);
                GameManager.Instance.tm.ChangeTurn();
            }
            else if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "JumpCard")
            {
                transform.position += new Vector3(-1, 1, 0);
                if (actionSlot.transform.childCount > 0)
                {
                    if (actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "DoubleJumpCard")
                    {
                        transform.position += new Vector3(-1, 1, 0);
                        GameManager.Instance.tm.ChangeTurn();
                    }
                }
                else
                {
                    GameManager.Instance.tm.ChangeTurn();
                }
            }
            else if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "HighJumpCard")
            {
                transform.position += new Vector3(-1, 1, 0);
                if (actionSlot.transform.childCount > 0)
                {
                    if (actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "DoubleJumpCard")
                    {
                        transform.position += new Vector3(-1, 1, 0);
                        GameManager.Instance.tm.ChangeTurn();
                    }
                }
                else
                {
                    GameManager.Instance.tm.ChangeTurn();
                }
            }
            else if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "JumpUpCard")
            {
                transform.position += new Vector3(0, 1, 0);
                GameManager.Instance.tm.ChangeTurn();
            }
            else if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "StopCard")
            {
                transform.position += new Vector3(0, 0, 0);
                GameManager.Instance.tm.ChangeTurn();
            }
        }



        //if jump, vector3 (0,1,0) + vector3 ((-)1,0,0) and drop
        //if high jump, vector3 (0,1,0) + vector3 ((-)1,0,0) and then again vector3 (0,1,0) + vector3 ((-)1,0,0) and drop
        //if jump up, vector3(0,1,0) and drop
        //if stop, do nothing

        //if double jump && jump OR high jump active, add (0,1,0)+((-)1,0,0)
        //if direction swap, change card slot right>left or viceversa
        //if punch, check if enemy is in adjacent tile & kill it
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnvironmentalDanger")
        {
            Destroy(gameObject);
        }
    }

}
