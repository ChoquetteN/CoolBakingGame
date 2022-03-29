using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : MonoBehaviour, iPlayerMenuTab
{
    public PlayerMenu playerMenu { get; private set; }

   public List<Food> ItemsInShop { get; private set; }

    [SerializeField]
    ItemOnSale[] itemsOnSale;


    public void hideProps()
    {
        foreach(ItemOnSale item in itemsOnSale)
        {
            item.HideItem();
        }
    }

    public void setPlayerMenu(PlayerMenu pm)
    {
        playerMenu = pm;
    }

    public void showProps()
    {
        playerMenu.setMenu(this);
        labelAllStoreItems();
        for( int i = 0; i < itemsOnSale.Length; i++)
        {
            int price = ItemsInShop[i].Buy;
            itemsOnSale[i].getBuyButton().onClick.AddListener(delegate { Debug.Log(i); playerMenu.OnItemPurchase.Invoke(price); });
        }
    }

    public void AddFoodToShopList( Food food)
    {
        if(ItemsInShop == null)
        ItemsInShop = new List<Food>();
        ItemsInShop.Add(food);
    }

    void labelAllStoreItems()
    {
        for(int i = 0; i < itemsOnSale.Length; i++)
        {
            if (ItemsInShop.Count > i)
                itemsOnSale[i].ShowItem(ItemsInShop[i]);
            else
                Debug.Log("Item in shop exceds no of slots");
        }
    }

    // A way to load the players daily shop
}
