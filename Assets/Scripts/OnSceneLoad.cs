using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneLoad : MonoBehaviour
{
	public static OnSceneLoad instance;

	ProbLoader _probLoader;

	public bool _loaded_room1;
	public bool _loaded_room2;

	private void Awake()
	{
		if(instance == null )
		{
			instance = this;
		}
		else if(instance != this )
		{
			Destroy( gameObject );
		}

		_probLoader = GetComponent<ProbLoader>();
	}

	void Start()
    {
        DissolveEffect.instance.FindCamera();
        DissolveEffect.instance.FadeIn();
    }

	public void SceneLoaded(int number )
	{
		if( number == 1 )
			_loaded_room1 = true;
		else
			_loaded_room2 = true;

		if(_loaded_room1 && _loaded_room2 )
		{
			_probLoader.AddRooms();
		}
	}




}
