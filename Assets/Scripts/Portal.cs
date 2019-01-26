using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Interactable
{
    int _number_of_portal;
    void Awake()
    {
        _can_Interact = true;
        _state = false;
        _number_of_portal = Convert.ToInt32(gameObject.name[6]);
        Debug.Log("This Portal's Number is: " + _number_of_portal);

    }

    public override void ActionOn()
    {
        Debug.Log("Portal ActionOn");
        Loader.instance.LoadSideScene(_number_of_portal + 5);
    }

    public override void ActionOff()
    {
        Debug.Log("Portal ActionOff");
    }

    public override void Interact()
    {
        Debug.Log("Portal Interact");
        if (_can_Interact)
        {
            if (_state)
            {
                ActionOff();
            }
            else
            {
                ActionOff();
            }
        }

    }
}
