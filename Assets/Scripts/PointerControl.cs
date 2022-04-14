using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerControl : MonoBehaviour
{
    bool isLeftMousePressed;

    Queue<InventoryCard> carriedCard;

    void Start()
    {
        isLeftMousePressed = false;
        carriedCard = new Queue<InventoryCard>();
        
    }

    void Update()
    {
        scanForMouseDown();
        scanForInteractable();
    }

    private void scanForMouseDown()
    {
        if (Input.GetMouseButtonDown(0) && !isLeftMousePressed)
        {
            isLeftMousePressed = true;
        }

        else if (Input.GetMouseButtonUp(0) && isLeftMousePressed)
        {
            isLeftMousePressed = false;
        }
    }

        private void scanForInteractable()
    {

        // this handles two kinds of input, I want to find a way where this only handles one kind of input or can interperet both kinds. 
        Vector2 v = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (EventSystem.current.IsPointerOverGameObject() )
          {
            PointerEventData pointerEvent = new PointerEventData(EventSystem.current);
            pointerEvent.position = v;
            if (pointerEvent.selectedObject != null)
            {
                if (pointerEvent.selectedObject.GetComponent<InventoryCard>() != null)
                {
                    if (isLeftMousePressed)
                    {
                        InventoryCard c = pointerEvent.selectedObject.GetComponent<InventoryCard>();
                        carriedCard.Enqueue(c);
                        c.OnCardClick(Input.mousePosition);
                    }
                    else
                    {
                        foreach (InventoryCard ic in carriedCard)
                        ic.MoveCardToLastPos();
                    }
                }
            }
           
                   
            }
    }
}
