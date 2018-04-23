using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDeck : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    int amount;
    Text amountText;
    Image borderSprite;

    public Sprite jumpUpDesc, highJumpDesc, jumpDesc, runDesc, stopDesc, fireballDesc, doubleJumpDesc, punchDesc, swapDesc;

    Sprite cardSpriteDesc;

    int cardIndex;

    private void Start()
    {
        if (gameObject.name == "JumpUpCard")
        {
            cardIndex = 0;
            cardSpriteDesc = jumpUpDesc;
        }
        else if (gameObject.name == "HighJumpCard")
        {
            cardIndex = 1;
            cardSpriteDesc = highJumpDesc;
        }
        else if (gameObject.name == "JumpCard")
        {
            cardIndex = 2;
            cardSpriteDesc = jumpDesc;
        }
        else if (gameObject.name == "RunCard")
        {
            cardIndex = 3;
            cardSpriteDesc = runDesc;
        }
        else if (gameObject.name == "StopCard")
        {
            cardIndex = 4;
            cardSpriteDesc = stopDesc;
        }
        else if (gameObject.name == "FireBallCard")
        {
            cardIndex = 5;
            cardSpriteDesc = fireballDesc;
        }
        else if (gameObject.name == "DoubleJumpCard")
        {
            cardIndex = 6;
            cardSpriteDesc = doubleJumpDesc;
        }
        else if (gameObject.name == "PunchCard")
        {
            cardIndex = 7;
            cardSpriteDesc = punchDesc;
        }
        else if (gameObject.name == "SwapCard")
        {
            cardIndex = 8;
            cardSpriteDesc = swapDesc;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        DeckManager.deckManager.totalCards--;
        DeckManager.deckManager.totalCardsText.text = "x" + DeckManager.deckManager.totalCards.ToString("00");
        amount++;
        gameObject.transform.GetChild(0).GetComponent<Text>().text = "x" + amount.ToString("00");
        DeckManager.deckManager.cardsPicked.Add(gameObject.name);
        DeckManager.deckManager.cardsPickedIndex.Add(cardIndex);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.transform.GetChild(1).GetComponent<Image>().enabled = true;
        DeckManager.deckManager.description.GetComponent<Image>().enabled = true;
        DeckManager.deckManager.description.GetComponent<Image>().sprite = cardSpriteDesc;
        Debug.Log("Mouse enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.transform.GetChild(1).GetComponent<Image>().enabled = false;
        DeckManager.deckManager.description.GetComponent<Image>().enabled = false; 
    }
}
