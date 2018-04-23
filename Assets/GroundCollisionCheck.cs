using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionCheck : MonoBehaviour {

    public bool enemyInSight;
    public bool touchingGround;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            touchingGround = true;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            enemyInSight = true;
            collision.gameObject.GetComponent<Enemy>().iWillDie = true;
            Destroy(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        touchingGround = false;
    }
}
