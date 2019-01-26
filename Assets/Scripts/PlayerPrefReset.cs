using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefReset : MonoBehaviour
{

    void Start()
    {
        PlayerPrefs.SetInt("Challenge1", 0);
        PlayerPrefs.SetInt("Challenge2", 0);
    }
}
