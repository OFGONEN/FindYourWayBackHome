using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneLoad : MonoBehaviour
{

    void Start()
    {
        DissolveEffect.instance.FindCamera();
        DissolveEffect.instance.FadeIn();
    }


}
