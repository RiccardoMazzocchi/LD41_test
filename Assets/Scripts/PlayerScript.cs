using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerScript : MonoBehaviour {

    public enum Direction { Left, Right }
    public Direction currentDirection;

    CollisionCheck collCheck;
    GroundCollisionCheck groundCollCheck;

    public GameObject leftSlot, rightSlot, actionSlot;
    public GameObject fireball;

    Enemy[] enemies;

    bool jumping, highJumping, doubleJumping, jumpUpping;
    public bool hasDropped;

    // Use this for initialization
    void Start () {
        collCheck = GetComponentInChildren<CollisionCheck>();
        groundCollCheck = GetComponentInChildren<GroundCollisionCheck>();
        enemies = FindObjectsOfType<Enemy>();
        hasDropped = true;
    }


    IEnumerator DropFromJump()
    {
       hasDropped = false;
       while (!gameObject.transform.GetChild(2).GetComponent<GroundCollisionCheck>().touchingGround)
       {
           //transform.position += new Vector3(0, -1, 0);
           transform.DOMove(new Vector3(transform.position.x, transform.position.y - 1, 0), 0.1f);
           yield return new WaitForSeconds(.5f);
       }
        hasDropped = true;
        GameManager.Instance.sm.cardInPlay = false;
        GameManager.Instance.sm.cardHasPlayed = true;
        StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
        yield return null;
    }

    public void Movement()
    {

        if (actionSlot.transform.childCount > 0)
        {
            if (actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "SwapCard")
            {
                if (rightSlot.transform.childCount > 0)
                {
                    rightSlot.transform.GetChild(0).SetParent(leftSlot.transform);
                    currentDirection = Direction.Left;
                    Destroy(actionSlot.transform.GetChild(0).gameObject);
                }
                else if (leftSlot.transform.childCount > 0)
                {
                    leftSlot.transform.GetChild(0).SetParent(rightSlot.transform);
                    currentDirection = Direction.Right;
                    Destroy(actionSlot.transform.GetChild(0).gameObject);
                }
            }

            if (actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "FireBallCard")
            {
                GameObject fb;
                if (currentDirection == Direction.Right)
                {
                    fb = Instantiate(fireball, transform.position, Quaternion.identity);
                    fb.transform.position = new Vector3(transform.position.x + 1, transform.position.y, 0);
                }
                else if (currentDirection == Direction.Left)
                {
                    fb = Instantiate(fireball, transform.position, Quaternion.identity);
                    fb.transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
                }

                Destroy(actionSlot.transform.GetChild(0).gameObject);
            }
        }

        if (jumping)
        {
            if (actionSlot.transform.childCount > 0 && actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "DoubleJumpCard")
            {
                if (currentDirection == Direction.Right)
                {
                    transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y + 1, 0), 0.1f, true);
                    Destroy(actionSlot.transform.GetChild(0).gameObject);
                    StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
                }
                else if (currentDirection == Direction.Left)
                {
                    transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y + 1, 0), 0.1f, true);
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

        if (jumpUpping)
        {
            jumpUpping = false;
            StartCoroutine(DropFromJump());
            StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
        }

        if (highJumping)
        {
            if (actionSlot.transform.childCount > 0 && actionSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "DoubleJumpCard")
            {
                if (currentDirection == Direction.Right)
                {
                    transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y + 1, 0), 0.1f, true);
                    Destroy(actionSlot.transform.GetChild(0).gameObject);

                    StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
                }
                else if (currentDirection == Direction.Left)
                {
                    transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y + 1, 0), 0.1f, true);
                    Destroy(actionSlot.transform.GetChild(0).gameObject);

                    StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
                }
                return;
            }


            if (currentDirection == Direction.Right)
            {
                transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y + 1, 0), 0.1f);
            }
            else if (currentDirection == Direction.Left)
            {
                transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y + 1, 0), 0.1f);
            }

            jumping = true;
            highJumping = false;

            StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            return;
        }


        // RIGHT SLOT MOVEMENT CARDS

        
        if (rightSlot.transform.childCount > 0)
        {

            //if right slot has child, and child is RunCard, then move >
            if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "RunCard")
            {
                if (gameObject.GetComponentInChildren<RightLeftGround>().againstRightGround)
                {
                    return;
                }
                transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y, 0), 0.1f);
                currentDirection = Direction.Right;

                rightSlot.transform.GetChild(0).GetComponent<DragHandler>().enabled = false;
                GameManager.Instance.sm.cardHasPlayed = true;
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }

            //f right slot has child, and child is JumpCard, then move >^ & jumping
            else if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "JumpCard")
            {
                transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y + 1, 0), 0.1f);
                jumping = true;
                currentDirection = Direction.Right;

                GameManager.Instance.sm.cardInPlay = true;

                rightSlot.transform.GetChild(0).GetComponent<DragHandler>().enabled = false;

                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());

            }
            
            //f right slot has child, and child is HighJumpCard, then move >^ & highJumping
            else if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "HighJumpCard")
            {
                transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y + 1, 0), 0.1f);
                transform.position = new Vector3(Mathf.Round(transform.position.x), Mathf.Round(transform.position.y), 0);
                highJumping = true;
                currentDirection = Direction.Right;

                GameManager.Instance.sm.cardInPlay = true;

                rightSlot.transform.GetChild(0).GetComponent<DragHandler>().enabled = false;

                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());

            }
            else if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "JumpUpCard")
            {
                currentDirection = Direction.Right;
                transform.DOMove(new Vector3(transform.position.x, transform.position.y + 1, 0), 0.1f);
                GameManager.Instance.sm.cardHasPlayed = true;
                jumpUpping = true;
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }
            else if (rightSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "StopCard")
            {
                currentDirection = Direction.Right;
                transform.position += new Vector3(0, 0, 0);
                GameManager.Instance.sm.cardHasPlayed = true;
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }
        }




        if (leftSlot.transform.childCount > 0)
        {

            //if left slot has child, and child is RunCard, then move >
            if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "RunCard")
            {
                if (gameObject.GetComponentInChildren<RightLeftGround>().againstLeftGround)
                {
                    return;
                }
                transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y, 0), 0.1f);
                currentDirection = Direction.Left;

                leftSlot.transform.GetChild(0).GetComponent<DragHandler>().enabled = false;
                GameManager.Instance.sm.cardHasPlayed = true;
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }

            //f right slot has child, and child is JumpCard, then move >^ & jumping
            else if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "JumpCard")
            {
                transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y + 1, 0), 0.1f);
                jumping = true;
                currentDirection = Direction.Left;

                GameManager.Instance.sm.cardInPlay = true;

                leftSlot.transform.GetChild(0).GetComponent<DragHandler>().enabled = false;

                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());

            }

            //f left slot has child, and child is HighJumpCard, then move >^ & highJumping
            else if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "HighJumpCard")
            {
                transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y + 1, 0), 0.1f);
                highJumping = true;
                currentDirection = Direction.Left;

                GameManager.Instance.sm.cardInPlay = true;

                leftSlot.transform.GetChild(0).GetComponent<DragHandler>().enabled = false;

                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());

            }
            else if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "JumpUpCard")
            {
                currentDirection = Direction.Left;
                transform.DOMove(new Vector3(transform.position.x, transform.position.y + 1, 0), 0.1f);
                GameManager.Instance.sm.cardHasPlayed = true;
                jumpUpping = true;
                StartCoroutine(GameManager.Instance.tm.ChangeTurnCoroutine());
            }
            else if (leftSlot.transform.GetChild(0).GetComponent<Card>().cardData.name == "StopCard")
            {
                currentDirection = Direction.Left;
                transform.position += new Vector3(0, 0, 0);
                GameManager.Instance.sm.cardHasPlayed = true;
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
                    }
                }
                Destroy(actionSlot.transform.GetChild(0).gameObject);
            }
        }


        //if direction swap, change card slot right>left or viceversa
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "EnvironmentalDanger")
        {
            Debug.Log("spikes");
        }

        if (collision.tag == "Flag")
        {
            Debug.Log("YOU WIN");
        }

        if (collision.tag == "Star")
        {
            Destroy(collision.gameObject);
        }
    }

}
