using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    Dictionary<Food, int> FoodPlayerOwns; 

    List<InventoryCard> inventoryCards;

    [SerializeField]
    InventoryCard inventoryCardPrefab;

    void Start()
    {
        inventoryCards = new List<InventoryCard>();
        FoodPlayerOwns = new Dictionary<Food, int>();
    }

    public void LoadInventory(Dictionary<Food, int> LoadedDictionary)
    {
        FoodPlayerOwns = LoadedDictionary;
    }

    void LabelCards()
    {
        foreach(KeyValuePair<Food,int> kv in FoodPlayerOwns)
        {
            CreateCard(kv.Key, kv.Value);
        }
    }

    public void AddFoodToInventory(Food food,int amnt)
    {
        foreach(Food f in FoodPlayerOwns.Keys)
        {
            if (food.ID == f.ID)
            {
                FoodPlayerOwns[f] += amnt;
                inventoryCards[inventoryCards.FindIndex(card => card.idForFood == f.ID)].UpdateNumberOfGood(FoodPlayerOwns[f]);
                return;
            }
        }
        FoodPlayerOwns.Add(food, amnt);

       // InventoryCard myCard = CreateCard(food, amnt);
       // addCardToListOfCards(myCard);
    }

    public void addFoodToFoodPlayerOwns(Food f, int amnt)
    {
        FoodPlayerOwns.Add(f,amnt);
    }

     public InventoryCard CreateCard(Food f , int amnt )
    {
        InventoryCard myCard = Instantiate(inventoryCardPrefab);
        myCard.CreateCard(f);
        myCard.UpdateNumberOfGood(amnt);
        myCard.transform.parent = this.transform;
        myCard.OffsetCard(inventoryCards.Count);
        addCardToListOfCards(myCard); // added
        return myCard;
    }

    public bool HasCardForFood(Food f)
    {
        return inventoryCards.Exists(card => card.idForFood == f.ID);
    }

    void addCardToListOfCards(InventoryCard myCard)
    {
        inventoryCards.Add(myCard);
    }

    public void SubtractFood(Food food, int amnt)
    {
        foreach (Food f in FoodPlayerOwns.Keys)
        {
            if (food.ID == f.ID)
            {
                FoodPlayerOwns[f] -= amnt;

                inventoryCards[inventoryCards.FindIndex(card => card.idForFood == f.ID)].UpdateNumberOfGood(FoodPlayerOwns[f]);
                if (FoodPlayerOwns[f] == 0)
                {
                   inventoryCards[inventoryCards.FindIndex(card => card.idForFood == f.ID)].gameObject.SetActive(false); 
                }
                return;
            }
        }


    }




}
