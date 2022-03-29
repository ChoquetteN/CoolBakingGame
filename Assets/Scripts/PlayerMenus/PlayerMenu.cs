using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMenu : MonoBehaviour
{

    [SerializeField]
    Button CraftMenuTab;

    [SerializeField]
    Button BuyMenuTab;

    [SerializeField]
    Button SellMenuTab;

    [SerializeField]
    CraftMenu craftMenu;

    [SerializeField]
    BuyMenu buyMenu;

    [SerializeField]
    SellMenu sellMenu;

    FoodLoader foodLoader;

    public Action<int> OnItemPurchase;

    public iPlayerMenuTab curMenu { get; private set; }

    void initMenu()
    {
        BuyMenuTab.onClick.AddListener(new SwitchMenuTabCommand(buyMenu).Execute);
        buyMenu.setPlayerMenu(this);
        SellMenuTab.onClick.AddListener(new SwitchMenuTabCommand(sellMenu).Execute);
        sellMenu.setPlayerMenu(this);
        CraftMenuTab.onClick.AddListener(new SwitchMenuTabCommand(craftMenu).Execute);
        craftMenu.setPlayerMenu(this);
        curMenu = craftMenu;
    }

    public void CloseMenu()
    {
        this.gameObject.SetActive(false);
    }

    public void OpenMenu()
    {
        this.gameObject.SetActive(true);
        if (curMenu == null) { initMenu(); }
        curMenu.showProps();
    }

    public void setMenu(iPlayerMenuTab newMenu)
    {
        curMenu.hideProps();
        curMenu = newMenu;
    }

    public void rollNewShop()
    {
        foodLoader = new FoodLoader();
        buyMenu.AddFoodToShopList(foodLoader.GetRandomFood());
        buyMenu.AddFoodToShopList(foodLoader.GetRandomFood());
        buyMenu.AddFoodToShopList(foodLoader.GetRandomFood());
        buyMenu.AddFoodToShopList(foodLoader.GetRandomFood());
    }

    public void loadShopData(int[] shopItemID)
    {
        foodLoader = new FoodLoader();
        foreach (int id in shopItemID)
        {
            buyMenu.AddFoodToShopList(foodLoader.GetFoodById(id));
        }
    }

    public List<Food> GetBuyMenuItems()
    {
        return buyMenu.ItemsInShop;
    }
}
