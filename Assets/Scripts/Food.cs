using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food
{
    public string Name { get; private set; }

    public int Buy { get; private set; }

    public int Sell { get; private set; }

    public Sprite ObjectSprite { get; private set; }

    public int ID;

    public Food(string Name, int Buy, int Sell, int ID)
    {
        this.Name = Name;
        this.Buy = Buy;
        this.Sell = Sell;
        this.ID = ID;
    }
}

