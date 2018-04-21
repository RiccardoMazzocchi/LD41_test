using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager Instance;
    public TurnManager tm;

	// Use this for initialization
	void Start () {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        tm = GetComponent<TurnManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
