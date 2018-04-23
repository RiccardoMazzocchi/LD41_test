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
            if (DragHandler.itemBeingDragged.GetComponent<Card>().cardData.cardType == CardData.CardType.Action && this.gameObject.tag == "ActionSlot"  && !GameManager.Instance.sm.cardAllowed ||
                DragHandler.itemBeingDragged.GetComponent<Card>().cardData.cardType == CardData.CardType.Movement && this.gameObject.tag == "MovementSlot" && GameManager.Instance.sm.cardAllowed ||
                this.gameObject.tag == "EmptySlot")
            {
                DragHandler.itemBeingDragged.transform.SetParent(transform);
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
        else if (item && !GameManager.Instance.sm.cardInPlay && !GameManager.Instance.sm.cardHasPlayed)
        {
            DragHandler.itemBeingDragged.transform.SetParent(transform);

            if (gameObject.transform.childCount > 1)
            {
                foreach (Slot slot in GameManager.Instance.sm.slots)
                {
                    if (slot.gameObject.tag == "EmptySlot" && slot.transform.childCount == 0)
                    {
                        gameObject.transform.GetChild(0).SetParent(slot.transform);
                        return;
                    }
                }
            }
        }

         else if (item && 
                 DragHandler.itemBeingDragged.GetComponent<Card>().cardData.cardType == CardData.CardType.Movement &&
                 this.gameObject.tag == "MovementSlot" && 
                 !GameManager.Instance.sm.cardAllowed && 
                 !GameManager.Instance.sm.cardInPlay &&
                 GameManager.Instance.sm.cardHasPlayed)
         {
             Destroy(this.gameObject.transform.GetChild(0).gameObject);
             DragHandler.itemBeingDragged.transform.SetParent(transform);
             GameManager.Instance.sm.cardHasPlayed = false;
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
