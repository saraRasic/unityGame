using UnityEngine;

public class SafeRoomTrigger : MonoBehaviour
{
    public string normalniLayer = "WhatIsPlayer"; 
    public string skriveniLayer = "HiddenPlayer";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.layer = LayerMask.NameToLayer(skriveniLayer);
            Debug.Log("Player is safe");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.gameObject.layer = LayerMask.NameToLayer(normalniLayer);
            Debug.Log("Player left the safe room");
        }
    }
}