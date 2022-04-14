using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CookingSlot : MonoBehaviour
{
    public InventoryCard cardInSlot { get; set; }

    public Action<InventoryCard> OnCardAdd;
    public Action<InventoryCard> OnCardRemove;

    void OnTriggerEnter2D(Collider2D col)
    {
       if (col.gameObject.GetComponent<InventoryCard>() != null)
        {
            if (cardInSlot != null)
            {
                cardInSlot.SetNewLastPos(col.gameObject.GetComponent<InventoryCard>().GetLastPos());
                OnCardRemove.Invoke(cardInSlot);
            }
            cardInSlot = col.gameObject.GetComponent<InventoryCard>();
            cardInSlot.SetNewLastPos(this.transform.position);
            OnCardAdd.Invoke(cardInSlot);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<InventoryCard>() != null && col.gameObject.GetComponent<InventoryCard>() == cardInSlot)
        {
             cardInSlot.SetToStartPos();
            OnCardRemove.Invoke(cardInSlot);
             cardInSlot = null;
        }
    }

}
