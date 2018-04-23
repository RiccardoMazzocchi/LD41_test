using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Enemy : MonoBehaviour {

    bool goingRight;
    public Transform startPoint, endPoint;

    public bool iWillDie;

    private void Start()
    {
    }

    public void Movement()
    {
        if (transform.position == startPoint.position)
            goingRight = false;
        else if (transform.position == endPoint.position)
            goingRight = true;

        if (goingRight)
            transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y, 0), 0.5f);
        else if (!goingRight)
            transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y, 0), 0.5f);
    }
}
