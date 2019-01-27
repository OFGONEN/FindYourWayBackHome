using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefReset : MonoBehaviour
{
	public int number;

    void Start()
    {
        PlayerPrefs.SetInt("Challenge1", number);
        PlayerPrefs.SetInt("Challenge2", number);
    }
}
