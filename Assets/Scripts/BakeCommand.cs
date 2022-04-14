using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeCommand : iCommand
{
    CraftMenu craftMenu;
    public void Execute()
    {
        craftMenu.Bake();
    }

    public BakeCommand(CraftMenu cm)
    {
        craftMenu = cm;
    }
}
