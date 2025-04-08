using System;
using UnityEngine;

public class playerMovementScript : MonoBehaviour
{

    public Rigidbody2D playerRB;
    public BoxCollider2D groundCheck;
    public LayerMask groundMask;
    public float moveSpeed = 5;
    public float jumpSpeed = 8;
   public CollectLetter cm;
    [Range(0f, 1f)]
    public float groundDecay = 0.5f;
    public bool grounded;
    private float moveX;
    private float moveY;
    
    // Update is called once per frame
    void Update()
    {
        GetInputs();
        HandleJump();
    }

    void FixedUpdate()
    {
        CheckGround();
        ApplyFriction(); 
        MoveWithInput();
    }

    void GetInputs() {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
    }

    void MoveWithInput() {
        if (Mathf.Abs(moveX) > 0) {
            playerRB.linearVelocity = new Vector2(moveX * moveSpeed, playerRB.linearVelocity.y);

            float playerDirection = Mathf.Sign(moveX);
            transform.localScale = new Vector3(playerDirection, 1, 1);
        }
    }

    void HandleJump() {
        if (moveY > 0 && grounded) {
            playerRB.linearVelocity = new Vector2(playerRB.linearVelocity.x, jumpSpeed);
        }
    }

    void CheckGround() {
        grounded = Physics2D.OverlapAreaAll(groundCheck.bounds.min, groundCheck.bounds.max, groundMask).Length > 0;
    }

    void ApplyFriction() {
        if (grounded && moveX == 0 && moveY == 0) {
            playerRB.linearVelocity *= groundDecay;
        }
    }

   private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Collectible")) {
            Destroy(other.gameObject);
        }
    }
}
