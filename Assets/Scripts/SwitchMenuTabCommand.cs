using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchMenuTabCommand : iCommand
{
    iPlayerMenuTab TabToSwitchTo;
    public SwitchMenuTabCommand(iPlayerMenuTab tabToSwitchTo)
    {
        TabToSwitchTo = tabToSwitchTo;
    }
    public void Execute()
    {
        Debug.Log(TabToSwitchTo.ToString());
        TabToSwitchTo.showProps();
    }
}
