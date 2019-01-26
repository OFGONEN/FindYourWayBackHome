using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveEffect : MonoBehaviour
{
    public static DissolveEffect instance;

    public Material _mat;
    Animator _anim;
    Canvas _canvas;

    [Range(0, 1)]
    public float _effect_value;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        _anim = GetComponent<Animator>();
        _canvas = GetComponent<Canvas>();
    }
    void Update()
    {
        _mat.SetFloat("_NoiseThreshold", _effect_value);
    }

    public void FadeOut()
    {
        Debug.Log("FadeOut");
        _anim.SetTrigger("FadeOut");
    }

    public void FadeIn()
    {
        Debug.Log("FadeIn");
        _anim.SetTrigger("FadeIn");
    }

    public void FindCamera()
    {
        Debug.Log("FindCamera");
        _canvas.worldCamera = Camera.main;
    }
}
