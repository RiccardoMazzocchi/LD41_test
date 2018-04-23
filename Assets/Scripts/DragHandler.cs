using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public static GameObject itemBeingDragged;
    Vector3 startPosition;
    Transform startParent;
    Vector3 screenPoint;


    public void OnBeginDrag(PointerEventData eventData)
    {
        if (GameManager.Instance.sm.cardInPlay && this.gameObject.transform.parent.tag == "MovementSlot")
        {
            return;
        }
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
}
