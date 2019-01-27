using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallControl : MonoBehaviour {

	public Material mat;


	
	// Update is called once per frame
	
	public void ChangeVertexPower(float i)
	{
		mat.SetFloat( "_NoiseMult", i );
	}

}
