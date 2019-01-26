using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlockable : MonoBehaviour
{

    Door door;
    void Start()
    {
        door = GetComponent<Door>();
        door._can_Interact = false;

        if (PlayerPrefs.GetInt("Challenge1") == 1 && PlayerPrefs.GetInt("Challenge2") == 1)
            door._can_Interact = true;
    }

}
