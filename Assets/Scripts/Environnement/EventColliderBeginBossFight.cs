using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventColliderBeginBossFight : MonoBehaviour
{
    WordEventManager worldEventManager;

    private void Awake()
    {
        worldEventManager = FindObjectOfType<WordEventManager>();
    }   

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            worldEventManager.ActivateBossfight();
        }
    }
}
