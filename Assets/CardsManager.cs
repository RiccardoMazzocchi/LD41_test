using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsManager : MonoBehaviour {

    Card[] cards;

    public CardData[] cardsData;

	// Use this for initialization
	void Start () {
        cards = FindObjectsOfType<Card>();
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void FillCards()
    {
        foreach (Card card in cards)
        {
            if (!card.hasCard)
            {
                card.cardData = cardsData[Random.Range(0, cardsData.Length)];
                card.SetCard();
            }
        }
    }
}
