using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float jumpForce = 1000;
    [SerializeField]
    float walkSpeed = 50;

    [SerializeField]
    Transform groundChecker;

    [SerializeField]
    LayerMask groundLayer;
    float movementX = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       rb.linearVelocityX = movementX * walkSpeed;
    }
    
    void OnJump(InputValue Value)
    {
         if (Physics2D.OverlapPoint(groundChecker.position, groundLayer))
        {
            rb.AddForce(Vector2.up * jumpForce); 
        }
    }
    
    void OnMove(InputValue Value)
    {
        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        
        movementX = Value.Get<Vector2>().x;

        sr.flipX = movementX < 0;
    }
}

