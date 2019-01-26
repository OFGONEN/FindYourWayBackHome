using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProbLoader : MonoBehaviour
{
    RoomManager roomManager;
    int _challenge1, _challenge2;

    void Awake()
    {
        _challenge1 = PlayerPrefs.GetInt("Challenge1");
        _challenge2 = PlayerPrefs.GetInt("Challenge2");
    }



    void Start()
    {
        roomManager = GetComponent<RoomManager>();

        if (_challenge1 == 0)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
            roomManager.AddRoom(1, "LoadedRoom1Portal");
        }
        else
        {
            SceneManager.LoadScene(3, LoadSceneMode.Additive);
            roomManager.AddRoom(1, "LoadedRoom1Normal");
        }

        if (_challenge2 == 0)
        {
            SceneManager.LoadScene(4, LoadSceneMode.Additive);
            roomManager.AddRoom(2, "LoadedRoom2Portal");
        }
        else
        {
            SceneManager.LoadScene(5, LoadSceneMode.Additive);
            roomManager.AddRoom(2, "LoadedRoom2Normal");
        }

        //Unlock the unlocable!
        if (_challenge1 == 1 && _challenge2 == 1)
            return;
    }
}
