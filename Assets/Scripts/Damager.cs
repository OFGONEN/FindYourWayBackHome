using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Damager Triggered by Player");
            Interaction.instance.Frezee();
            Loader.instance.LoadMainHall();
        }
    }

}
