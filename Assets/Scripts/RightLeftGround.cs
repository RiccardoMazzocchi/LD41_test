using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftGround : MonoBehaviour {

    public bool againstRightGround, againstLeftGround;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            if (gameObject.tag == "RightCheck")
            {
                againstRightGround = true;
                againstLeftGround = false;
            }
            else if (gameObject.tag == "LeftCheck")
            {
                againstRightGround = false;
                againstLeftGround = true;
            }

        }
    }
}
