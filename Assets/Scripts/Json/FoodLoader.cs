using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodLoader : JsonLoader<Food>
{

    public List<Food> AllFoods { get; private set; }


    public FoodLoader()
    {
        AllFoods = new List<Food>();
        Init("Assets/Scripts/Json/Food.json");
    }

    public override void Init(string filePath)
    {
        base.Init(filePath);
        AllFoods = GetObjectListFromFilePathByString("Food");
    }

    public Food GetFoodByName(string nameOfFoodToFind)
    {
        for (int i = 0; i < AllFoods.Count; i++)
        {
            if (nameOfFoodToFind == AllFoods[i].Name)
            {
                return AllFoods[i];
            }
        }
        Debug.Log($"Food named {nameOfFoodToFind} not found in loader");
        return null;
    }

    public Food GetRandomFood()
    {
        Food debugFood = AllFoods[Random.Range(0, AllFoods.Count)];
        return debugFood;
    }

    public Food GetFoodById(int idToFind)
    {
        int index = AllFoods.FindIndex(item => item.ID == idToFind);
        if (index >= 0)
        {
            return AllFoods[index];
        }
        else
            Debug.Log("Item with index" + idToFind + "Does Not exist in our list");
        return null;
    }

    //Season of food?
    //public Food RandomOfType(string TypeOfFoodToFind)
    //{

    //    var match = AllFoods.FindAll(item => item.TypeOfFood.Contains(TypeOfFoodToFind));
    //    if (match == null)
    //    {
    //        Debug.Log($"Type {TypeOfFoodToFind} could not be found");
    //    }

    //    return match[Random.Range(0, match.Count)];
    //}
}
