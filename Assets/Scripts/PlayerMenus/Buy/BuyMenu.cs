using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMenu : MonoBehaviour, iPlayerMenuTab
{
    public PlayerMenu playerMenu { get; private set; }

   public List<Food> ItemsInShop { get; private set; }

    [SerializeField]
    ItemOnSale[] itemsOnSale;

    void Start()
    {
        for (int i = 0; i < itemsOnSale.Length; i++)
        {
            Food food = ItemsInShop[i];
            itemsOnSale[i].getBuyButton().onClick.AddListener(delegate { if (playerMenu.OnItemPurchase.Invoke(food.Buy)) { playerMenu.addFoodToInventory(food, 1); { if(!playerMenu.hasCardForFood(food)) playerMenu.CreateCard(food, 1); } } });
        }
    }

    public void hideProps()
    {
        this.gameObject.SetActive(false);
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
        this.gameObject.SetActive(true);
        labelAllStoreItems();
        //for( int i = 0; i < itemsOnSale.Length; i++)
        //{
        //    Food food = ItemsInShop[i];
        //    itemsOnSale[i].getBuyButton().onClick.AddListener(delegate { if (playerMenu.OnItemPurchase.Invoke(food.Buy)) { playerMenu.addFoodToInventory(food, 1); } });
        //}
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
