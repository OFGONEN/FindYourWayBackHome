using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public bool _can_Interact;
    public bool _state;

    public virtual void ActionOn()
    {
        Debug.Log("Action On");
    }

    public virtual void ActionOff()
    {
        Debug.Log("Action Off");
    }

    public virtual void Interact()
    {
        Debug.Log("Interact");
    }
}
