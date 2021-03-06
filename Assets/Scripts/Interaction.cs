﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    public static Interaction instance;

    public bool _can_interact;

    GameObject _cash_object;
    Rigidbody rb;
    int _cash_type;
    RaycastHit hit;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        //_can_interact = false;
        _cash_object = null;
        _cash_type = -1;

        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward * 3, Color.red, 0.1f);
        if (_can_interact)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, 3f, 256))
            {
                if (_cash_object == null)
                {
                    Debug.Log("Cashed the object: " + hit.collider.name);
                    _cash_object = hit.collider.gameObject;
                    DecideType(_cash_object.tag);
                }
            }
            else
            {
				if( _cash_object != null )
					Debug.Log( "Decashed the object: " + _cash_object.name );
                _cash_object = null;
                _cash_type = -1;
            }
        }
        else
        {
            _cash_object = null;
            _cash_type = -1;
        }

        if (_can_interact && _cash_object != null && _cash_type != -1 && Input.GetKeyDown(KeyCode.E))
        {
            //Interact 
            Interact();
        }
    }

    void Interact()
    {
        Debug.Log("Interact By Player");

        if (_cash_type == 0)
        {
            _cash_object.GetComponent<Door>().Interact();
        }
        else if (_cash_type == 1)
        {
            _cash_object.GetComponent<Portal>().Interact();
        }
        else if (_cash_type == 2)
        {
            _cash_object.GetComponent<Trophy>().Interact();
        }
		else if(_cash_type == 3 )
		{

		}
    }
    void DecideType(string tag)
    {
        Debug.Log("DecideType: " + tag);

		if( tag == "Door" )
			_cash_type = 0;
		else if( tag == "Portal" )
			_cash_type = 1;
		else if( tag == "Trophy" )
			_cash_type = 2;
		else if( tag == "EndGame" )
			_cash_type = 3;
    }

    public void EnableInteract()
    {
        Debug.Log("EnableInteract");
        _can_interact = true;
        _cash_object = null;
        _cash_type = -1;
    }

    public void DisableInteract()
    {
        Debug.Log("DisableInteract");
        _can_interact = false;
        _cash_object = null;
        _cash_type = -1;
    }

    public void Frezee()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
    }
}
