using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellMenu : MonoBehaviour, iPlayerMenuTab
{
    public PlayerMenu playerMenu { get; private set; }
   
    public void hideProps()
    {

    }

    public void setPlayerMenu(PlayerMenu pm)
    {
        playerMenu = pm;
    }

    public void showProps()
    {
        playerMenu.setMenu(this);
    }
}
