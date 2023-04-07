using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogWall2 : MonoBehaviour
{
    private bool hasPlayerPassed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasPlayerPassed)
        {
            hasPlayerPassed = true;
        }
    }

    public bool HasPlayerPassed()
    {
        return hasPlayerPassed;
    }

    public void ActivateFogWall()
    {
        gameObject.SetActive(true);
    }

    public void DeactivateFogWall()
    {
        if (!hasPlayerPassed)
        {
            return; // Do nothing if player hasn't passed the wall yet
        }
        
        gameObject.SetActive(false);
    }
}
