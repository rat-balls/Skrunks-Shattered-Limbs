using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventColliderBeginBossFight : MonoBehaviour
{
    public FogWall fogWall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Désactiver le collider du FogWall
            fogWall.GetComponent<Collider>().isTrigger = false;

            // Activer le FogWall
            fogWall.ActivateFogWall();

            // Activer le combat de boss
            FindObjectOfType<WordEventManager>().ActivateBossfight();
        }
    }
}