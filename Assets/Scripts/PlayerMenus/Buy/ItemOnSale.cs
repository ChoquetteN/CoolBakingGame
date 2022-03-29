using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOnSale : MonoBehaviour
{
    [SerializeField]
    Text ItemName;

    [SerializeField]
    Text ItemCost;

    [SerializeField]
    Image ItemImage;

    [SerializeField]
    Button buyButton;

    public void ShowItem(Food f)
    {
        this.gameObject.SetActive(true);
        ItemName.text = f.Name;
        ItemCost.text = f.Buy.ToString();
        ItemImage.sprite = SpriteHolder.instance.GetFoodArtFromIDNumber(f.ID);
        
    }

    public void HideItem()
    {
        this.gameObject.SetActive(false);
    }

    public Button getBuyButton()
    {
        return buyButton;
    }
}
