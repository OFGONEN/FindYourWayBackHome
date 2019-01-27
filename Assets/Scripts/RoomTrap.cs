using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTrap : MonoBehaviour {

	public Door door;

	private void OnTriggerEnter( Collider other )
	{
		if(other.tag == "Player" )
		{
			door.ActionOff();
		}
	}
}
