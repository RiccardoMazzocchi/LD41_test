using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsManager : MonoBehaviour
{

    public List<Card> cards = new List<Card>();
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

    public void InitializeDeck()
    {
        foreach (int i in GameManager.Instance.deckManager.cardsPickedIndex)
        {
            cardInstance = Instantiate(cardToInstantiate, transform.position, Quaternion.identity);
            cardInstance.GetComponent<Card>().cardData = cardsData[i];
            cardInstance.GetComponent<Card>().SetCard();
            cardInstance.transform.position = new Vector3(1000, 1000, 0);
            cardInstance.transform.SetParent(transform);
            cards.Add(cardInstance.GetComponent<Card>());
        }
    }

    public void FillCards()
    {
        Debug.Log("Creating cards");

        slots = FindObjectsOfType<Slot>();
        foreach (Slot slot in slots)
        {
            if (!slot.hasCard && slot.name == "EmptyCard" && deckCount >= 0 && slot.transform.childCount == 0)
            {
                Card randomCard = cards[Random.Range(0, cards.Count)];
                randomCard.gameObject.transform.position = slot.transform.position;
                randomCard.gameObject.transform.SetParent(slot.transform);
                randomCard.gameObject.transform.localScale = new Vector3(1, 1, 1);
                cards.Remove(randomCard);
            }
        }

        Debug.Log(actionCards);
    }

}

