using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    Animator _anim;

    public bool _is_onLoop;
    public float _activasion_interval;
    float _next_activasion;

    bool _can_activate;
    void Awake()
    {
        _anim = GetComponent<Animator>();
        if (_is_onLoop)
            _can_activate = false;
    }

    void Update()
    {
        if (_can_activate && Time.time > _next_activasion)
        {
            _next_activasion = Time.time + _activasion_interval;
            ActionOn();
        }

    }

    public void ActionOn()
    {
        //Variable Config
        _anim.SetTrigger("Open");
        if (_is_onLoop)
            _can_activate = true;
        else
            _can_activate = false;
    }

    public void ActionOff()
    {
        //Variable Config
        _anim.SetTrigger("Close");
    }

    public void ActionTimer()
    {
        _next_activasion = Time.time + _activasion_interval;
        _can_activate = true;
    }
}
