using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IPointerDownHandler
{

    public bool hasCard;
    public CardData cardData;
    public Image img;

	// Use this for initialization
	void Start () {
        img = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		if (img.sprite == null)
        {
            hasCard = false;
        }
	}

    public void SetCard()
    {
        img.sprite = cardData.cardImage;
        hasCard = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        cardData = null;
        img.sprite = null;
    }

}
