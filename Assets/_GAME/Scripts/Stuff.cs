using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuff : MonoBehaviour
{

    static Dictionary<string, KeyCode> buttons;

    void Start()
    {
        buttons = new Dictionary<string, KeyCode>
        {
            ["Hotkey1"] = KeyCode.Mouse0,
            ["Hotkey2"] = KeyCode.Mouse1,
            ["Hotkey3"] = KeyCode.Q,
            ["Hotkey4"] = KeyCode.W,
            ["Hotkey5"] = KeyCode.E,
            ["Hotkey6"] = KeyCode.R
        };
    }

    public static bool GetButtonDown(string buttonName)
    {
        if( !buttons.ContainsKey(buttonName))
        {
            return false;
        }
        return Input.GetKey(buttons[buttonName]);
    }
}
