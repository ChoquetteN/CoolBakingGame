using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitCommand : iCommand
{
    GameManager gm;
    public QuitCommand(GameManager _gm)
    {
        gm = _gm;
    }

    public void Execute()
    {
        Debug.Log("Application Quit");
        SaveSystem.SaveLogOutTime(gm.getLogOutData());

        
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();
#endif
    }
}
