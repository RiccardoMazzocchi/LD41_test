using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour {

    public Card[] cards;
    public Slot[] slots;

    public CardData[] cardsData;

    public Sprite noCard;

    public int deckCount;

    public GameObject cardToInstantiate;

	// Use this for initialization
	void Start () {
        deckCount = 30;
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void FillCards()
    {
        slots = FindObjectsOfType<Slot>();
        foreach (Slot slot in slots)
        {
            if (!slot.hasCard && slot.name == "EmptyCard" && deckCount >= 0 && slot.transform.childCount == 0)
            {
                Instantiate(cardToInstantiate, slot.transform.position, Quaternion.identity, slot.transform);
                cardToInstantiate.GetComponent<Card>().cardData = cardsData[Random.Range(0, cardsData.Length)];
                cardToInstantiate.GetComponent<Card>().SetCard();
                deckCount--;
                GameManager.Instance.uim.deckCountText.text = deckCount.ToString();

                if (deckCount == 0)
                {

                }
            }
        }
    }
}
