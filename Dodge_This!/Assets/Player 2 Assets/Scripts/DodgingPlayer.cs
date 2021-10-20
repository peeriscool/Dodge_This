using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DodgingPlayer : MonoBehaviour
{
    // References
    public CharacterController characterController;
    public PlayerHP playerHP;
    public LevelManager levelManager;
    // Multiple players
    public int playerIndex = 0;
    // Walk variables
    float horizontal;
    float vertical;
    public float speed;
    // Jump variables
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    public static bool isGrounded;
    public float jumpHeight = 5f;
    // Gravity
    public float gravity = -9.81f;
    // Crouch variables
    public bool isCrouching = false;
    void Start()
    {

    }

    void Update()
    {
        // Get movement input
        if (playerHP.playerDead == false)
        {
            //Multiple controller input
            if (playerIndex == 1)
            {
                horizontal = Input.GetAxisRaw("Horizontal");
                vertical = Input.GetAxisRaw("Vertical");
            }
        }
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        // Gravity
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
        // Walking
        if (direction.magnitude >= 0.1)
        {
             characterController.Move(direction * speed * Time.deltaTime); // Move
        }
        // Jumping
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (playerHP.playerDead == false)
        {
            if (Input.GetButtonDown("Jump"))
            {
                if (isGrounded)
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
                }
            }
        }
        // Turning playerbody
    }
}
