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
        AddFood(new Food("Flour", 1, 0), 5);
        AddFood(new Food("Butter", 1, 1), 5);
        LabelCards();
    }

    public void LoadInventory(Dictionary<Food, int> LoadedDictionary)
    {
        FoodPlayerOwns = LoadedDictionary;
    }

    void LabelCards()
    {
        Debug.Log(FoodPlayerOwns.Count);
        foreach(KeyValuePair<Food,int> kv in FoodPlayerOwns)
        {
            InventoryCard myCard = Instantiate(inventoryCardPrefab);
            myCard.CreateCard(kv.Key);
            myCard.UpdateNumberOfGood(kv.Value);
            myCard.transform.parent = this.transform;
            myCard.OffsetCard(inventoryCards.Count);
            inventoryCards.Add(myCard);
        }
    }

    public void AddFood(Food food,int amnt)
    {
        foreach(Food f in FoodPlayerOwns.Keys)
        {
            if (food.ID == f.ID)
            {
                FoodPlayerOwns[f] += amnt;
                return;
            }
        }
        FoodPlayerOwns.Add(food, amnt);
    }

    public void SubTractFoof(Food food, int amnt)
    {
        foreach (Food f in FoodPlayerOwns.Keys)
        {
            if (food.ID == f.ID)
            {
                FoodPlayerOwns[f] -= amnt;
                //if(FoodPlayerOwns[f] -= amnt == 0)
                //{
                    
                //}
            }
        }
    }




}
