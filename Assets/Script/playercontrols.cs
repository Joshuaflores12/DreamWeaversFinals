using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    private float playerSpeed;
    public Rigidbody2D rigidBody;
    private Vector2 movementInput;
    public Animator anim;

    private bool isGrounded;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        playerSpeed = moveSpeed;
    }

    void Update()
    {
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        anim.SetFloat("X", movementInput.x);
        anim.SetFloat("Y", movementInput.y);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);

        // Check for jump input and if the player is grounded
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        // Perform grounded check
        GroundedCheck();

        // Player movement
        rigidBody.velocity = new Vector2(movementInput.x * playerSpeed, rigidBody.velocity.y);
    }


 


    void Jump()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
    }

    void GroundedCheck()
    {
        // Perform a simple grounded check using a Raycast
        // Adjust the length of the Raycast depending on your character's size and the ground setup
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);
    }

  
}