using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RecipeLoader : JsonLoader<Recipe>
{
    List<Recipe> recipes = new List<Recipe>();
    FoodLoader fl;

    public RecipeLoader()
    {
        fl = new FoodLoader();
        Init("Assets/Scripts/Json/RecipeItems.json");
    }

    public override void Init(string filePath)
    {
        base.Init(filePath);

        foreach (Recipe r in GetObjectListFromFilePathByString("Recipe"))
        {
            r.FoodCreated = fl.GetFoodByName(r.Name);
            recipes.Add(r);
        }
    }

    public Food GetFoodFromId(int id)
    {
        return fl.GetFoodById(id);
    }

    public Food GetFoodFromRecipe(List<Food> heldFood) // may need to switch return type to food or list of food
    {
        for (int j = 0; j < recipes.Count; j++)
        {
            if (recipes[j].CanCraftFood(heldFood))
            {
                // Look This up for bake button
                //SpaceContextualActions.Add(new CraftFood(this, character, recipiesThatCanBeCreated[j]));
                return recipes[j].FoodCreated;
            }
        }
        return null;

    }
}


