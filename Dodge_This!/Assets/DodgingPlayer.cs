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
    // Crouch variables
    void Start()
    {
        
    }

    void Update()
    {
        // Get movement input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        // Walking
        if (direction.magnitude >= 0.1)
        {
            characterController.Move(direction * speed * Time.deltaTime);
        }
        // Jumping
        // Crouching
    }
}
