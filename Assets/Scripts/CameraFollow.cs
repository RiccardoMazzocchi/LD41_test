using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    Transform target;

	// Use this for initialization
	void Start () {

        target = FindObjectOfType<PlayerScript>().transform;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(target.position.x, transform.position.y, transform.position.z);

	}
}
