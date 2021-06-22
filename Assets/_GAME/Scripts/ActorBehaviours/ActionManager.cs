using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionManager : MonoBehaviour
{
    List<ActionHandler> allActions;
    Dictionary<string, ActionHandler> pairedActions;


    private GameObject user;
    public void SetUser(GameObject u)
    {
        user = u;
        foreach (ActionHandler a in allActions)
        {
            a.SetUser(user);
        }
    }

    //is the player currently casting?
    private bool casting;
    public bool IsCasting()
    { return casting;  }
    //static Dictionary<GameObject, float> currentCooldowns;


    private IEnumerator AnimationLock(float time)
    {
        casting = true;
        yield return new WaitForSeconds(time);
        casting = false;
    }


    // Start is called before the first frame update
    void Awake()
    {
        allActions = new List<ActionHandler>();

        

        pairedActions = new Dictionary<string, ActionHandler>
        {
            ["Action1"] = allActions[0]
 
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool Use(string actionName)
    {
        if (!pairedActions.ContainsKey(actionName))
        {
            Debug.Log("Key not bound");
            return false;
        }
        if (!casting)
        {
            //on successful cast, start animationlock
            if (pairedActions[actionName].Instantiate())
            {
                StartCoroutine(AnimationLock(pairedActions[actionName].GetActionTime()));
                return true;
            }
        }

        //nothing used
        return false;
    }

    public void AddAction(ActionHandler ah)
    {
        ah.SetUser(user);
        allActions.Add(ah);
    }
}
