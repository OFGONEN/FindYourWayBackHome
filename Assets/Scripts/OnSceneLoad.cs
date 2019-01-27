using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneLoad : MonoBehaviour
{
    public static OnSceneLoad instance;
    public bool _fadein_onstart;

    ProbLoader _probLoader;

    public bool _loaded_room1;
    public bool _loaded_room2;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        _probLoader = GetComponent<ProbLoader>();
    }

    void Start()
    {
        DissolveEffect.instance.FindCamera();
        if (_fadein_onstart)
            DissolveEffect.instance.FadeIn();
    }

    public void SceneLoaded(int number)
    {
        if (number == 1)
            _loaded_room1 = true;
        else
            _loaded_room2 = true;

        if (_loaded_room1 && _loaded_room2)
        {
            _probLoader.AddRooms();
            DissolveEffect.instance.FadeIn();
        }
    }




}
