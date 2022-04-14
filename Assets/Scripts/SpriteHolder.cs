using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpriteHolder : MonoBehaviour
{

    public static SpriteHolder instance { get; private set; }

    [System.Serializable]
    public struct NamedImages
    {
        public string name;
        public Sprite characterIcon;
        public List<Sprite> sprites;
        public RuntimeAnimatorController animations;
    }

    [SerializeField]
    Sprite[] FoodArt;

    private void Awake()
    {
        instance = this;
    }

    public int CountOfFoodArt()
    {
        return FoodArt.Length - 1;
    }

    public Sprite GetFoodArtFromIDNumber(int index)
    {
        if (FoodArt.Length > index-1 )
        {
            return FoodArt[index];
        }
        Debug.Log("Missing art at index " + index);
        return FoodArt[FoodArt.Length-1];
    }
}

