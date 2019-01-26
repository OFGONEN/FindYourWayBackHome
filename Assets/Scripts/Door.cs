using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    Animator _anim;
    RoomManager roomManager;
    int _number_of_door;
    void Awake()
    {
        _can_Interact = true;
        _state = false;
        _anim = GetComponent<Animator>();
        _number_of_door = Convert.ToInt32(gameObject.name[4]);
        Debug.Log("This Door's Number is: " + _number_of_door);
    }

    void Start()
    {
        roomManager = GameObject.FindWithTag("SceneManager").GetComponent<RoomManager>();
    }
    public override void ActionOn()
    {
        Debug.Log("Door ActionON");
        _anim.SetTrigger("Open");
    }

    public override void ActionOff()
    {
        Debug.Log("Door ActionOff");
        _anim.SetTrigger("Close");
    }

    public override void Interact()
    {
        Debug.Log("Door Interact");
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
    public void HideRooms()
    {
        Debug.Log("Door Closes Hide Every Other Room for Door: " + _number_of_door);
        roomManager.HideRooms(_number_of_door);
    }

}
