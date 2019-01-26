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
        Debug.Log("OnActiveAbout");
        _about.SetActive(true);
        _main.SetActive(false);
    }

    public void OnActiveCredits()
    {
        Debug.Log("OnActiveCredits");
        _credits.SetActive(true);
        _main.SetActive(false);
    }


    public void OnBackMenu()
    {
        Debug.Log("OnDisable");
        _credits.SetActive(false);
        _about.SetActive(false);

        _main.SetActive(true);
    }
}
