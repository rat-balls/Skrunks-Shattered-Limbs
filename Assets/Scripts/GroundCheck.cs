using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    
    [SerializeField] public bool isGrounded = false;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float dist;


    private void Update() {
        
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(ray, out hit, dist, groundLayer)){
            isGrounded = true;
        } else {
            isGrounded = false;
        }
    }
}
