using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IDropHandler {
    public GameObject item
    {
        get
        {
            if (transform.childCount > 0)
            {
                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public bool hasCard;

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            if (Card.itemBeingDragged.GetComponent<Card>().cardData.cardType == CardData.CardType.Action && this.gameObject.tag == "ActionSlot"  && !GameManager.Instance.sm.cardAllowed ||
                Card.itemBeingDragged.GetComponent<Card>().cardData.cardType == CardData.CardType.Movement && this.gameObject.tag == "MovementSlot" && GameManager.Instance.sm.cardAllowed ||
                this.gameObject.tag == "EmptySlot")
            {
                Card.itemBeingDragged.transform.SetParent(transform);
                if (gameObject.tag == "MovementSlot")
                {
                    GameManager.Instance.sm.cardAllowed = false;
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            return;
        }
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            hasCard = false;
        }
        else if (transform.childCount > 0)
        {
            hasCard = true;
            if (this.gameObject.tag == "MovementSlot")
            {
                
            }
        }
    }


}
