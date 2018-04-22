using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    bool goingRight;
    public Transform startPoint, endPoint;



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
            transform.position += new Vector3(1, 0, 0);
        else if (!goingRight)
            transform.position -= new Vector3(1, 0, 0);
    }


}
