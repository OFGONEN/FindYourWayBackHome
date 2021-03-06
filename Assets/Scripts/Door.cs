﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Shader _replacement;

	public bool _portal_door;

    Renderer[] _renderers;
    Animator _anim;
    RoomManager roomManager;
    int _number_of_door;
    void Awake()
    {
        _can_Interact = true;
        _state = false;
        _anim = GetComponent<Animator>();
        _number_of_door = Convert.ToInt32(gameObject.name[4]) - 48;
        Debug.Log("This Door's Number is: " + _number_of_door);
    }

    void Start()
    {
        _renderers = transform.GetComponentsInChildren<Renderer>();
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
        Debug.Log("Door Interact " + _can_Interact + " - " + _state);
        if (_can_Interact)
        {
            if (_state)
            {
                ActionOff();
            }
            else
            {
                ActionOn();
            }
        }
    }

    public void ChangeState(int state)
    {
        if (state == 1)
            _state = true;
        else
            _state = false;
    }

    public void HideRooms()
    {
		if( _portal_door )
		{
			Debug.Log( "Door Closes Hide Every Other Room for Door: " + _number_of_door );
			ChangeMaterialsInAllChildren();
			_can_Interact = false;
			roomManager.HideRooms( _number_of_door );
		}
    }

    private void ChangeMaterialsInAllChildren()
    {
        foreach (Renderer r in _renderers)
        {
            List<Material> i = new List<Material>();
            r.GetMaterials(i);

            foreach (Material k in i)
            {

                k.shader = _replacement;
            }

        }
    }

}
