using UnityEngine;

public class playerMovementScript : MonoBehaviour
{

    public Rigidbody2D playerRB;
    public float moveSpeed = 5;
    public float velocity;
    private Vector2 moveDirection;

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
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // using .normalized to ensure diagonal movement is not faster than vertical and horizontal movement
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move() {
        playerRB.linearVelocity = moveDirection * moveSpeed;
    }
}
