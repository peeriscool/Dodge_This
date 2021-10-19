using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingPlayer : MonoBehaviour
{
    // References
    public CharacterController characterController;
    // Walk variables
    public float speed;
    // Jump variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    public static bool isGrounded;
    public float jumpHeight = 5f;
    public float gravity = -9.81f;
    // Crouch variables
    public bool isCrouching = false;
    // Invisible walls
    public bool isInInvisibleWall = false;
    public bool cantWalkForward = false;
    void Start()
    {
        // Lock cursor
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Get movement input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        // Gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        // Walking
        if (direction.magnitude >= 0.1)
        {
            //  When in inviswall
            if (isInInvisibleWall == true && cantWalkForward == true && direction.z <= 0) // If in frontwall & not going forward
            {
                characterController.Move(direction * speed * Time.deltaTime); // Move
            } 
            else if (isInInvisibleWall == true && cantWalkForward == false && direction.z >= 0) // If in backwall & not going backward
            {
                characterController.Move(direction * speed * Time.deltaTime); // Move
            }
            // When out of wall
            else if (isInInvisibleWall == false) 
            {
                characterController.Move(direction * speed * Time.deltaTime); // Move
            }
        }
        // Jumping
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump"))
        {
            if (isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }
        }
        // Crouching
    }
}
