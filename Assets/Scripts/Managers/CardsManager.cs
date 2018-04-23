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

    int cardDataIndex;

    public GameObject cardToInstantiate;
    GameObject cardInstance;
    // Use this for initialization
    void Start()
    {
        actionCards = 0;
        deckCount = 30;

        foreach (int i in GameManager.Instance.deckManager.cardsPickedIndex)
        {
            cardInstance = Instantiate(cardToInstantiate, transform.position, Quaternion.identity);
            cardInstance.GetComponent<Card>().cardData = cardsData[i];
            cardInstance.GetComponent<Card>().SetCard();
            cardInstance.transform.position = new Vector3(1000, 1000, 0);
            cardInstance.transform.parent = transform;
            cards.Add(cardInstance.GetComponent<Card>());
        }
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
                Card randomCard = cards[Random.Range(0, cards.Count - 1)];
                randomCard.gameObject.transform.position = slot.transform.position;
                randomCard.gameObject.transform.parent = slot.transform;
                randomCard.gameObject.transform.localScale = new Vector3(1, 1, 1);
                cards.Remove(randomCard);

                //   cardInstance = Instantiate(cardToInstantiate, slot.transform.position, Quaternion.identity, slot.transform);
                //   cardInstance.GetComponent<Card>().cardData = cardsData[Random.Range(0, cardsData.Length)];
                //   cardInstance.GetComponent<Card>().SetCard();
                //   deckCount--;
                //   GameManager.Instance.uim.deckCountText.text = deckCount.ToString();
                //
                //   if (cardInstance.GetComponent<Card>().cardData.cardType == CardData.CardType.Action)
                //   {
                //       actionCards++;
                //   }
            }
        }

        Debug.Log(actionCards);
    }

}

