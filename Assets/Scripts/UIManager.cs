using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public GameObject _main;
    public GameObject _about;
    public GameObject _credits;

    public void OnActiveAbout()
    {
        _about.active = true;
        _main.active = false;
    }

    public void OnActiveCredits()
    {
        _credits.active = true;
        _main.active = false;
    }


    public void OnDisable()
    {
        _credits.active = false;
        _about.active = false;

        _main.active = true;
    }
}
