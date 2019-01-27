using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProbLoader : MonoBehaviour
{
    RoomManager roomManager;
    int _challenge1, _challenge2;

    WallControl _wallControl;

    

    void Start()
    {

	_challenge1 = PlayerPrefs.GetInt( "Challenge1" );
	_challenge2 = PlayerPrefs.GetInt( "Challenge2" );

	Debug.Log( "Challenge " + _challenge1 + " - " + _challenge2 );

	roomManager = GetComponent<RoomManager>();

        _wallControl = GetComponent<WallControl>();

        if (_challenge1 == 0)
        {
            SceneManager.LoadScene(2, LoadSceneMode.Additive);
            roomManager.AddRoom(1, "Room1Portal");
        }
        else
        {
            SceneManager.LoadScene(3, LoadSceneMode.Additive);
            roomManager.AddRoom(1, "Room1Normal");
        }

        if (_challenge2 == 0)
        {
            SceneManager.LoadScene(4, LoadSceneMode.Additive);
            roomManager.AddRoom(2, "Room2Portal");
        }
        else
        {
            SceneManager.LoadScene(5, LoadSceneMode.Additive);
            roomManager.AddRoom(2, "Room2Normal");
        }

        if (_challenge1 == 1 && _challenge2 == 1)
            _wallControl.ChangeVertexPower(0f);
        else if (_challenge1 == 1 || _challenge2 == 1)
            _wallControl.ChangeVertexPower(0.5f);
    }

	public void AddRooms()
	{
		if( _challenge1 == 0 )
		{
			roomManager.AddRoom( 1, "Room1Portal" );
		}
		else
		{
			roomManager.AddRoom( 1, "Room1Normal" );
		}

		if( _challenge2 == 0 )
		{
			roomManager.AddRoom( 2, "Room2Portal" );
		}
		else
		{
			roomManager.AddRoom( 2, "Room2Normal" );
		}
	}
}
