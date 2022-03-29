using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    PlayerData curPlayer;
  //  public PlayerData CurPlayer { get { return curPlayer; } }

    [SerializeField]
    GoldCounter goldCounterUI;

    [SerializeField]
    Button OpenMenuButton;

    [SerializeField]
    PlayerMenu playerMenu;

    void Start()
    {
        if (SaveSystem.loadPlayerData() != null)
        {
            curPlayer = SaveSystem.loadPlayerData();
            DateTime startTime = new DateTime(DateTime.Now.Year, curPlayer.Month, curPlayer.Day, curPlayer.Hour, curPlayer.Minute, DateTime.Now.Second);
            DateTime endTime = DateTime.Now;

            TimeSpan span = endTime.Subtract(startTime);
            curPlayer.Gold += (float)rollTheDice((int)span.TotalMinutes / 5);
            goldCounterUI.DisplayGoldAmount((int)curPlayer.Gold);
            if (startTime.Day < endTime.Day || startTime.Month < endTime.Month) { playerMenu.rollNewShop(); }
            else
            {
                playerMenu.loadShopData(curPlayer.storeItems);
            }
        }
        else
        {
            curPlayer = new PlayerData(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            playerMenu.rollNewShop();
        }

        OpenMenuButton.onClick.AddListener(new OpenMenu(playerMenu).Execute);
        playerMenu.OnItemPurchase = curPlayerSubtractGold;
    }

    public PlayerData getLogOutData()
    {
        List<Food> foodItemsInShop = playerMenu.GetBuyMenuItems();
        int[] storeItemId = new int[foodItemsInShop.Count];
       for(int i = 0; i < storeItemId.Length; i++)
        {
            storeItemId[i] = foodItemsInShop[i].ID;
        }
        return new PlayerData(curPlayer.Month, curPlayer.Day, curPlayer.Hour, curPlayer.Minute, curPlayer.Gold, storeItemId);
    }

    double rollTheDice(int dice)
    {
        double gold = 0;
        for(double i = 0; i < dice; i++)
        {
            gold += (double)UnityEngine.Random.Range(1,7);
        }
        return gold;
    }

    public void curPlayerSubtractGold(int goldToSubtract)
    {
        curPlayer.Gold -= goldToSubtract;
        goldCounterUI.DisplayGoldAmount((int)curPlayer.Gold);
        Debug.Log("Subtract gold hit");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
