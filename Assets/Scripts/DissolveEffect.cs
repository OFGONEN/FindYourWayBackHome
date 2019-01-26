using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{

    public Material _mat;

    [Range(0, 1)]
    public float _effect_value;


    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, _mat);
    }

    // Update is called once per frame
    void Update()
    {
        _mat.SetFloat("_NoiseThreshold", _effect_value);

    }
}
