using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixTargetToGround : MonoBehaviour
{    
    [SerializeField] private LayerMask groundLayer;
    
    private void Update() {
        transform.position = DetectGroundHeight(transform.position);
    }

    public Vector3 DetectGroundHeight(Vector3 position){
        
        position.y = 100; //Make sure this value is higher that your tallest bit of ground
        RaycastHit hit = new RaycastHit();
        Ray ray = new Ray(position, Vector3.down);
        
        if(Physics.Raycast(ray, out hit, 1000, groundLayer)){
            return hit.point;
        } else {
            return position;
        }
 }
}
