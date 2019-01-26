using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trophy : Interactable
{

    public int _number;
    void Awake()
    {
        _can_Interact = true;
        _state = false;
        Debug.Log("This Trophy is number: " + _number);
    }
    public override void ActionOn()
    {
        Debug.Log("Trophy ActiveON ");
        PlayerPrefs.SetInt("Challenge" + _number, 1);
        Loader.instance.LoadMainHall();
    }

    public override void ActionOff()
    {
        Debug.Log("Trophy ActiveOff");
    }

    public override void Interact()
    {
        Debug.Log("Trophy Interact");
        if (_can_Interact)
        {
            if (_state)
            {
                ActionOff();
            }
            else
            {
                ActionOn();
                _can_Interact = false;
            }
        }
    }
}
