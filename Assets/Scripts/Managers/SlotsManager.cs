using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotsManager : MonoBehaviour {


    Slot[] slots;

    public bool cardAllowed;
	// Use this for initialization
	void Start () {
        cardAllowed = true;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public void CheckSlots()
    {
  //   slots = FindObjectsOfType<Slot>();
  //
  //   foreach (Slot slot in slots)
  //   {
  //       if (slot.hasCard && slot.gameObject.tag == "MovementSlot")
  //       {
  //           cardAllowed = false;
  //       }
  //       else
  //       {
  //           cardAllowed = true;
  //       }
  //   }
    }
}
