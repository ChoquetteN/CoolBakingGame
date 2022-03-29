using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public PlayerData(int month, int day, int hour, int minute, float gold, int[] storeItemID)
    {
        Month = month;
        Day = day;
        Hour = hour;
        Minute = minute;
        Gold = gold;
        storeItems = storeItemID;
        Debug.Log("Loaded with store data");
    }

    public PlayerData(int month, int day, int hour, int minute, float gold)
    {
        Month = month;
        Day = day;
        Hour = hour;
        Minute = minute;
        Gold = gold;
        Debug.Log(" not Loaded with store data");
    }

    public int Month;
    public int Day;
    public int Hour;
    public int Minute;
    public float Gold;
    public int[] storeItems;
    
}
