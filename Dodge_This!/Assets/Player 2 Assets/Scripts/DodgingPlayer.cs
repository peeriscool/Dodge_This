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
        // Get movement & jump input
        if (playerHP.playerDead == false && levelManager.levelActive == true)
        {
            //Multiple controller input
            GetMoveInputForEachPlayer();
            GetJumpInputsForEachPlayer();
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
    }
    void GetMoveInputForEachPlayer()
    {
        if (playerIndex == 0)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }
        else if (playerIndex == 1)
        {
            horizontal = Input.GetAxisRaw("Horizontal1");
            vertical = Input.GetAxisRaw("Vertical1");
        }
        else if (playerIndex == 2)
        {
            horizontal = Input.GetAxisRaw("Horizontal2");
            vertical = Input.GetAxisRaw("Vertical2");
        }
        else if (playerIndex == 3)
        {
            horizontal = Input.GetAxisRaw("Horizontal3");
            vertical = Input.GetAxisRaw("Vertical3");
        }
    }

    void GetJumpInputsForEachPlayer()
    {
        if (playerIndex == 0 && Input.GetButtonDown("Jump"))
        {
            Jump();
            print(playerIndex + " Jump, isGrounded =" + isGrounded);
        } else if (playerIndex == 1 && Input.GetButtonDown("Jump1"))
        {
            Jump();
            print(playerIndex + " Jump, isGrounded =" + isGrounded);
        } else if (playerIndex == 2 && Input.GetButtonDown("Jump2"))
        {
            Jump();
            print(playerIndex + " Jump, isGrounded =" + isGrounded);
        } else if (playerIndex == 3 && Input.GetButtonDown("Jump3"))
        {
            Jump();
            print(playerIndex + " Jump, isGrounded =" + isGrounded);
        }
    }
    void Jump()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
