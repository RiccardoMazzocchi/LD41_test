using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour {


    public Slot[] slots;

    public bool cardAllowed;
    public bool cardInPlay;
    public bool cardHasPlayed;

    // Use this for initialization
    void Start () {
        cardAllowed = true;
	}
	
	// Update is called once per frame
	void Update () {
        slots = FindObjectsOfType<Slot>();
    }

   
}
