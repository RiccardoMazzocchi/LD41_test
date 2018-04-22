using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour {

    Card[] cards;

    public CardData[] cardsData;

    public Sprite noCard;

    public int deckCount;

	// Use this for initialization
	void Start () {
        deckCount = 30;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void FillCards()
    {
        cards = FindObjectsOfType<Card>();
        foreach (Card card in cards)
        {
            if (!card.hasCard)
            {
                card.cardData = cardsData[Random.Range(0, cardsData.Length)];
                card.SetCard();
                deckCount--;
                GameManager.Instance.uim.deckCountText.text = deckCount.ToString();
            }
        }
    }
}
