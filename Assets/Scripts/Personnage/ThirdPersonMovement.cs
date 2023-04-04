using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{   
    [Header("Character")]
    public CharacterController controller;
    public Transform cam; 
    
    [Space(10)]
    [Header("Ledge Grab")]
    public LayerMask ledgeMask;
    public Transform ledgeCheck;
    public float ledgeDistance = 0.4f;
    public bool isLedged;
    [Space(10)]
    [Header("Gravity")]
    public LayerMask groundMask;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public bool isGrounded;
    [Space(10)]
    [Header("Speed")]
    public float walkSpeed = 10f;
    public float sprintSpeed = 21f;
    [Space(10)]
    float speed = 10f;
    float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    bool isRunning = false;


    Vector3 velocity;

    private void Start() 
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {
        
        // Ledge Shenanigans
            if(Input.GetKeyDown(KeyCode.E) && Physics.CheckSphere(ledgeCheck.position, ledgeDistance, ledgeMask))
            {
                isLedged = true;
            }

            if(Input.GetKeyUp(KeyCode.E))
            
            {
                isLedged = false;
            }

            if(isLedged)
            {   
                velocity.y = 0f;
            } else 
            {
                velocity.y += gravity * Time.deltaTime;
            }
        
        // Gravity Stuff

            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
            

            if(isGrounded && velocity.y < 0)
            {
                velocity.y = -2f;
            }

            controller.Move(velocity * Time.deltaTime);


        // Basic Movement
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            if (Input.GetKeyDown(KeyCode.Q))
            {
                isRunning = true;
                speed = sprintSpeed;
            }

            if (Input.GetKeyUp(KeyCode.Q))
            {
                isRunning = false;
                speed = walkSpeed;
            }

            if(Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            if (direction.magnitude >= 0.1f && !isLedged)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                controller.Move(moveDir.normalized * speed * Time.deltaTime);
            }

    }
}
