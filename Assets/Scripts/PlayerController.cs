using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameManager GM;

    Dictionary<KeyCode, iCommand> _optionsMapping;

    private void Start()
    {
        _optionsMapping = new Dictionary<KeyCode, iCommand>();
        _optionsMapping.Add(KeyCode.Escape, new QuitCommand(GM));
    }

    private void Update()
    {
        foreach (KeyValuePair<KeyCode, iCommand> keyValue in _optionsMapping)
        {
            if (Input.GetKey(keyValue.Key))
            {
                keyValue.Value.Execute();
            }
        }
    }
}
