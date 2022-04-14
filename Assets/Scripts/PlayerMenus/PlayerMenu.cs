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

    [SerializeField]
    Inventory playerInventory;

    FoodLoader foodLoader;
    RecipeLoader recipeLoader;

    public Func<int,bool> OnItemPurchase;

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
        recipeLoader = new RecipeLoader();
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

    public void addFoodToInventoryById(int id, int amnt)
    {
        Food f = foodLoader.GetFoodById(id);
        addFoodToInventory(f,amnt);
    }

    public void addFoodToInventory(Food f, int amnt)
    {
        playerInventory.AddFoodToInventory(f, amnt);
    }

    public bool hasCardForFood(Food f)
    {
       return playerInventory.HasCardForFood(f);
    }

    public void subtractFoodFromInventory(Food f)
    {
        subtractFoodFromInventory(f, 1);
    }

    public void subtractFoodFromInventory(Food f, int amnt)
    {
        playerInventory.SubtractFood(f, amnt);
    }

    public Food getSpecificFood(int id)
    {
       return foodLoader.GetFoodById(id);
    }

    public InventoryCard CreateCard(Food f, int amnt)
    {
        return playerInventory.CreateCard(f, amnt);
    }

    public bool checkForRecipie(List<Food> foods, CookingOutputSlot cookingOutput)
    {
        recipeLoader = new RecipeLoader();
        Food f = recipeLoader.GetFoodFromRecipe(foods);
        if (f != null)
        {
            InventoryCard card = playerInventory.CreateCard(f, 1);
            card.transform.parent = cookingOutput.transform;
            card.transform.position = cookingOutput.transform.position;
            card.GetComponent<Button>().interactable = false;
            cookingOutput.storedCard = card;
            return true;

        }
        else if (cookingOutput.storedCard != null && !cookingOutput.storedCard.GetComponent<Button>().enabled)
        {
            cookingOutput.storedCard.gameObject.SetActive(false);
            cookingOutput.storedCard = null;
        }
        return false;
    }

}
