using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour
{

    public Card[] cards;
    public Slot[] slots;

    public CardData[] cardsData;

    public Sprite noCard;

    public int deckCount;
    public int actionCards;



    public GameObject cardToInstantiate;
    GameObject cardInstance;
    // Use this for initialization
    void Start()
    {
        actionCards = 0;
        deckCount = 30;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void FillCards()
    {
        Debug.Log("Creating cards");

        slots = FindObjectsOfType<Slot>();
        foreach (Slot slot in slots)
        {
            if (!slot.hasCard && slot.name == "EmptyCard" && deckCount >= 0 && slot.transform.childCount == 0)
            {
                cardInstance = Instantiate(cardToInstantiate, slot.transform.position, Quaternion.identity, slot.transform);
                cardInstance.GetComponent<Card>().cardData = cardsData[Random.Range(0, cardsData.Length)];
                cardInstance.GetComponent<Card>().SetCard();
                deckCount--;
                GameManager.Instance.uim.deckCountText.text = deckCount.ToString();

                if (cardInstance.GetComponent<Card>().cardData.cardType == CardData.CardType.Action)
                {
                    actionCards++;
                }
            }
        }

        Debug.Log(actionCards);
    }

}

