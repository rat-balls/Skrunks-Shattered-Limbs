using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidbodyMovement : MonoBehaviour
{   
    private Vector3 playerMovementInput;
    private Vector2 playerMouseInput;
    private float xRot;

    [SerializeField] private Transform playerCam;
    [SerializeField] private Rigidbody playerBody;
    [Space]
    [SerializeField] private float speed;
    [SerializeField] private float sensitivity;
    [SerializeField] private float jumpStrength;

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        playerMouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        if(playerMovementInput.magnitude >= 0.1f){
            playerBody.MoveRotation(Quaternion.Euler(0f, playerCam.eulerAngles.y, 0f));
        }
    }

    private void FixedUpdate() 
    {
        movePlayer();
    }

    private void movePlayer()
    {   
    
        Vector3 moveVector = transform.TransformDirection(playerMovementInput) * speed;
        playerBody.velocity = new Vector3(moveVector.x, playerBody.velocity.y, moveVector.z);
        

        if(Input.GetKeyDown(KeyCode.Space))
        {
            playerBody.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }
    }
}
