// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class EventCollider : MonoBehaviour
// {

//     WordEventManager worldEventManager;

//     private void Awake()
//     {
//         WordEventManager = FindObjectOfType<WordEventManager>();
//     }

//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.tag == "Player")
//         {
//             worldEventManager.ActivateBossFight();
//         }
//     }

// }
