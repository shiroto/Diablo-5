using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stuff : MonoBehaviour
{

    static Dictionary<string, KeyCode> buttons;
    public static Plane world;

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

    public static Vector3 Intersect()
    {

        // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        // Does the ray intersect any objects excluding the player layer
        if (Physics.Raycast(r.origin, r.direction, out RaycastHit hit, Mathf.Infinity, layerMask))
        {
            var h = r.GetPoint(hit.distance);
            return h;
        }
        else
        {
            return Vector3.negativeInfinity;
        }
    }

    public static bool ApproxEqual(Vector3 v1, Vector3 v2, float bound = 0.5f)
    {
        if ((v1.x - v2.x) * (v1.x - v2.x) + (v1.z - v2.z) * (v1.z - v2.z) <= bound)
            return true;
        return false;
    }
}
