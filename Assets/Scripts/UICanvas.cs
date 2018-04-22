using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvas : MonoBehaviour {

    public RectTransform background;

	// Use this for initialization
	void Start () {

        background.sizeDelta = new Vector3(Screen.width, (Screen.height / 100f) * 25f);

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
