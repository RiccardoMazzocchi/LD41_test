using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Card : MonoBehaviour
{

    public CardData cardData;
    public Image img;

    void Update()
    {
        if (cardData == null)
        {
            Color tempColor = img.color;
            tempColor.a = 0f;
            img.color = tempColor;
        }
    }

    public void SetCard()
    {
        img = GetComponent<Image>();
        img.sprite = cardData.cardImage;
        Color tempColor = img.color;
        tempColor.a = 1f;
        img.color = tempColor;
    }

}
