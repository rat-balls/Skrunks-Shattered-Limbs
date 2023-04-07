using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventColliderBeginBossFight : MonoBehaviour
{
    public AudioSource source;
    private bool hasPlayed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            // Activer tous les Fog Walls
            foreach (FogWall fogWall in FindObjectOfType<WordEventManager>().fogWalls)
            {
                fogWall.GetComponent<Collider>().isTrigger = false;
                fogWall.ActivateFogWall();
            }

            source.Play();
            hasPlayed = true;

            // Activer le combat de boss
            FindObjectOfType<WordEventManager>().ActivateBossfight();
        }
    }
}
