﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour {

    public bool enemyInSight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            enemyInSight = true;
            collision.gameObject.GetComponent<Enemy>().iWillDie = true;
        }
        else
            enemyInSight = false;
    }
}
