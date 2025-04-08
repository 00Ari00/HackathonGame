using System;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{

    public Rigidbody2D playerRB;
    public float moveSpeed = 5;
    public float velocity;
    private Vector2 moveDirection;
    private float moveX;
    private float moveY;

    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        // Move();

    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs() {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
        // using .normalized to ensure diagonal movement is not faster than vertical and horizontal movement
    }

    void Move() {
        if (Mathf.Abs(moveDirection.x) > 0.1) {
            playerRB.linearVelocity = new Vector2(moveDirection.x * moveSpeed, playerRB.linearVelocity.y);
        }

        if (Math.Abs(moveDirection.y) > 0.1) {
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, moveDirection.y * moveSpeed);
        }
    }
}
