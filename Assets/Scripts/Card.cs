using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Card : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    Vector3 screenPoint;


 
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

    public void OnBeginDrag(PointerEventData eventData)
    {
        
        itemBeingDragged = gameObject;
        startPosition = transform.position;
        startParent = transform.parent;
        GetComponent<CanvasGroup>().blocksRaycasts = false;

        if (itemBeingDragged.transform.parent.tag == "MovementSlot")
            GameManager.Instance.sm.cardAllowed = true;

    }

    public void OnDrag(PointerEventData eventData)
    {
        screenPoint = Input.mousePosition;
        screenPoint.z = 1f;
        transform.position = Camera.main.ScreenToWorldPoint(screenPoint);

    }

    public void OnEndDrag(PointerEventData eventData)
    {
       
        itemBeingDragged = null;
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        if (transform.parent == startParent)
        {
            transform.position = startPosition;
        }

    }

    //   public void OnPointerDown(PointerEventData eventData)
    //   {
    //       cardData.CardFunction();
    //       cardData = null;
    //       img.sprite = GameManager.Instance.cm.noCard;
    //   }
}
