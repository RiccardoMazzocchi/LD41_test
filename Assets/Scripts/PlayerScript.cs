using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScript : MonoBehaviour {

    public enum Direction { Left, Right }
    Direction currentDirection;

    CollisionCheck collCheck;

    public GameObject leftSlot, rightSlot, actionSlot;


    Enemy[] enemies;

    bool jumping, highJumping, doubleJumping;

    // Use this for initialization
    void Start () {
        collCheck = GetComponentInChildren<CollisionCheck>();
        enemies = FindObjectsOfType<Enemy>();
    }
	
	// Update is called once per frame
	void Update () {
        if (GameManager.Instance.tm.CurrentMacroTurn == TurnManager.MacroTurn.PlayerTurn && GameManager.Instance.tm.CurrentMacroPhase == TurnManager.MacroPhase.Game)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                transform.position += new Vector3(1, 0, 0);
                //GameManager.Instance.tm.ChangeTurn();
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                transform.position -= new Vector3(1, 0, 0);
                //GameManager.Instance.tm.ChangeTurn();
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }
        }
	}

    IEnumerator DropFromJump()
    {
        while (!gameObject.transform.GetChild(2).GetComponent<GroundCollisionCheck>().touchingGround)
        {
            //transform.position += new Vector3(0, -1, 0);
            transform.DOMove(new Vector3(transform.position.x, transform.position.y - 1, 0), 0.5f);
            yield return new WaitForSeconds(.01f);
        }
        yield return null;
    }

    public void Movement()
    {

        if (jumping)
        {
            if (actionSlot.transform.childCount > 0 && actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "DoubleJumpCard")
            {
                if (currentDirection == Direction.Right)
                {
                    transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y + 1, 0), 0.5f);
                    Destroy(actionSlot.transform.GetChild(0).gameObject);
                    StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
                }
                else if (currentDirection == Direction.Left)
                {
                    transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y + 1, 0), 0.5f);
                    Destroy(actionSlot.transform.GetChild(0).gameObject);
                    StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
                }
                return;
            }

            StartCoroutine(DropFromJump());
            jumping = false;
            StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            return;
        }

        if (highJumping)
        {
            if (actionSlot.transform.childCount > 0 && actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "DoubleJumpCard")
            {
                if (currentDirection == Direction.Right)
                {
                    transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y + 1, 0), 0.5f);
                    Destroy(actionSlot.transform.GetChild(0).gameObject);
                    //GameManager.Instance.tm.ChangeTurn();
                    StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
                }
                else if (currentDirection == Direction.Left)
                {
                    transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y + 1, 0), 0.5f);
                    Destroy(actionSlot.transform.GetChild(0).gameObject);
                    //GameManager.Instance.tm.ChangeTurn();
                    StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
                }
                return;
            }


            if (currentDirection == Direction.Right)
            {
                transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y + 1, 0), 0.5f);
            }
            else if (currentDirection == Direction.Left)
            {
                transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y + 1, 0), 0.5f);
            }

            jumping = true;
            highJumping = false;
            //GameManager.Instance.tm.ChangeTurn();
            StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            return;
        }


        // RIGHT SLOT MOVEMENT CARDS

        
        if (rightSlot.transform.childCount > 0)
        {

            //if right slot has child, and child is RunCard, then move >
            if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "RunCard")
            {
                transform.DOMove(new Vector3(transform.position.x + 1, 0, 0), 0.5f);
                currentDirection = Direction.Right;
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }

            //f right slot has child, and child is JumpCard, then move >^ & jumping
            else if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "JumpCard")
            {
                transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y + 1, 0), 0.5f);
                jumping = true;
                currentDirection = Direction.Right;
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());

            }
            
            //f right slot has child, and child is HighJumpCard, then move >^ & highJumping
            else if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "HighJumpCard")
            {
                transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y + 1, 0), 0.5f);
                highJumping = true;
                currentDirection = Direction.Right;
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());

            }
            else if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "JumpUpCard")
            {
                transform.DOMove(new Vector3(0, transform.position.y + 1, 0), 0.5f);
                //GameManager.Instance.tm.ChangeTurn();
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }
            else if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "StopCard")
            {
                transform.position += new Vector3(0, 0, 0);
                //GameManager.Instance.tm.ChangeTurn();
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }
        }




        //LEFT SLOT MOVEMENT CARDS
        if (leftSlot.transform.childCount > 0)
        {
            if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "RunCard")
            {
                transform.DOMove(new Vector3(transform.position.x - 1, 0, 0), 0.5f);
                //GameManager.Instance.tm.ChangeTurn();
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }
            else if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "JumpCard")
            {
            //   //transform.position += new Vector3(-1, 1, 0);
            //   transform.DOMove(new Vector3(-1, 2, 0), 0.5f);
            //   if (actionSlot.transform.childCount > 0)
            //   {
            //       if (actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "DoubleJumpCard")
            //       {
            //           transform.position += new Vector3(-1, 1, 0);
            //           GameManager.Instance.tm.ChangeTurn();
            //       }
            //   }
            //   else
            //   {
            //       GameManager.Instance.tm.ChangeTurn();
            //   }
            }
            else if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "HighJumpCard")
            {
            //   //transform.position += new Vector3(-1, 1, 0);
            //   transform.DOMove(new Vector3(-1, 1, 0), 0.5f);
            //   if (actionSlot.transform.childCount > 0)
            //   {
            //       if (actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "DoubleJumpCard")
            //       {
            //           transform.position += new Vector3(-1, 1, 0);
            //           GameManager.Instance.tm.ChangeTurn();
            //       }
            //   }
            //   else
            //   {
            //       GameManager.Instance.tm.ChangeTurn();
            //   }
            }
            else if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "JumpUpCard")
            {
                transform.DOMove(new Vector3(0, transform.position.y + 1, 0), 0.5f);
                //GameManager.Instance.tm.ChangeTurn();
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }
            else if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "StopCard")
            {
                transform.position += new Vector3(0, 0, 0);
                //GameManager.Instance.tm.ChangeTurn();
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }
        }



        //ACTION CARDS
        if (actionSlot.transform.childCount > 0)
        {
            if (actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "PunchCard")
            {
                if (collCheck.enemyInSight)
                {
                    foreach (Enemy enemy in enemies)
                    {
                        if (enemy.iWillDie == true)
                        {
                            Destroy(enemy.gameObject);
                        }
                        else if (enemy == null)
                        {
                            return;
                        }
                    }
                }
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "EnvironmentalDanger")
        {
            Destroy(gameObject);
        }
    }

}
