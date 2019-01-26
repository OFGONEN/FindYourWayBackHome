using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{

    public static Loader instance;

    public int _scene_to_load;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    public void LoadMainHall()
    {
        Debug.Log("Load Main Hall Scene");
        _scene_to_load = 1;
        DissolveEffect.instance.FadeOut();
    }

    public void LoadEndGame()
    {
        // End Game Scene
        Debug.Log("Load End Game Scene");
        _scene_to_load = 5;
        DissolveEffect.instance.FadeOut();
    }

    public void LoadSideScene(int value)
    {
        Debug.Log("Load Side Scene: " + value);
        _scene_to_load = value;
        DissolveEffect.instance.FadeOut();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(_scene_to_load);
    }


}

