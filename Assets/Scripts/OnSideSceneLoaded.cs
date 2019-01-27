using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSideSceneLoaded : MonoBehaviour {

	public int number;

	private void Start()
	{
		Debug.Log( "Side Scene " + gameObject.name + " Loaded" );
		OnSceneLoad.instance.SceneLoaded( number );
	}
}
