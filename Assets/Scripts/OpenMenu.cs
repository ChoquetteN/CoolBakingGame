using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : iCommand
{
    PlayerMenu menuToOpen;

    public OpenMenu(PlayerMenu menu)
    {
        menuToOpen = menu;
    }

    public void Execute()
    {
        Debug.Log("Menu open");
        menuToOpen.OpenMenu();
    }
}
