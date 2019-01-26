using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionEnabler : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Interaction.instance.EnableInteract();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            Interaction.instance.DisableInteract();
    }
}
