using System;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{

    public Rigidbody2D playerRB;
    public float moveSpeed = 5;
    public float velocity;
    public float drag = 0.9f;
    public bool grounded;
    private Vector2 moveDirection;
    // Update is called once per frame
    void Update()
    {
        ProcessInputs();

    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs() {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        // using .normalized to ensure diagonal movement is not faster than vertical and horizontal movement

        if (Mathf.Abs(moveDirection.x) > 0.1) {
            playerRB.linearVelocity = new Vector2(moveDirection.x * moveSpeed, playerRB.linearVelocity.y);
        }

        if (Math.Abs(moveDirection.y) > 0.1) {
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, moveDirection.y * moveSpeed);
        }
    }

    void Move() {
        checkGround();

        if (grounded) {
            playerRB.linearVelocity *= drag;
        }
    }

    void checkGround() {
        
    }
}
