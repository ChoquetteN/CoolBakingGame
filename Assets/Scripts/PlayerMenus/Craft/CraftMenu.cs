using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMenu : MonoBehaviour, iPlayerMenuTab
{
    [SerializeField]
    CookingSlot slotOne;

    [SerializeField]
    CookingSlot slotTwo;

    [SerializeField]
    CookingOutputSlot slotOut;

    public PlayerMenu playerMenu { get; private set; }

    public void OpenMenu()
    {
        this.gameObject.SetActive(true);
    }

    public void showProps()
    {
        playerMenu.setMenu(this);
        slotOne.gameObject.SetActive(true);
        slotTwo.gameObject.SetActive(true);
        slotOut.gameObject.SetActive(true);
    }

    public void hideProps()
    {
        slotOne.gameObject.SetActive(false);
        slotTwo.gameObject.SetActive(false);
        slotOut.gameObject.SetActive(false);
    }

    public void CloseMenu()
    {
        this.gameObject.SetActive(false);
    }

    public void setPlayerMenu(PlayerMenu pm)
    {
        playerMenu = pm;
    }
}
