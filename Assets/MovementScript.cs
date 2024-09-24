using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;        // Hastighed for at gå til venstre og højre
    public float jumpForce = 5f;       // Kraften ved hop
    public LayerMask groundLayer;       // Angiv hvilket lag der betragtes som "ground"
    public Transform groundCheck;       // Tjekker om spilleren er på jorden
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private bool isTouchingGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation; // Freeze rotation in 2D
    }

    void Update()
    {
        // Tjek om spilleren er på jorden
        bool isGrounded = isTouchingGround;

        // Få input fra venstre/højre pile eller "A" og "D" tasterne
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (Input.GetKeyDown(KeyCode.D))
        {
            spriteRenderer.flipX = false;  // Face right (default direction)
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            spriteRenderer.flipX = true;   // Face left (flipped direction)
        }

        // Flyt spilleren horisontalt
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Hop, hvis "W"-tasten trykkes, og spilleren er på jorden
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.constraints = RigidbodyConstraints2D.None;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Tjek om vi rammer en collider på groundLayer
        if ((groundLayer & (1 << collision.gameObject.layer)) != 0)
        {
            Debug.Log("Står på jorden");
            isTouchingGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Tjek om vi forlader en collider på groundLayer
        if ((groundLayer & (1 << collision.gameObject.layer)) != 0)
        {
            isTouchingGround = false;
            Debug.Log("Står ikke på jorden");
        }
    }
}