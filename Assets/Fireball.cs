using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fireball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move()
    {
        if (GameManager.Instance.player.currentDirection == PlayerScript.Direction.Right)
        {
            transform.DOMove(new Vector3(transform.position.x + 1, transform.position.y, 0f), 0.1f);
        }
        else if (GameManager.Instance.player.currentDirection == PlayerScript.Direction.Left)
        {
            transform.DOMove(new Vector3(transform.position.x - 1, transform.position.y, 0f), 0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
