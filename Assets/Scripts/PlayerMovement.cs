using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float      moveSpeed = 120.0f;
    [SerializeField] private float      jumpForce = 5.0f;
    [SerializeField] private float      coyoteTime = 0.1f;
    [SerializeField] private float      groundDetectorRadius = 2.0f;
    [SerializeField] private float      groundDetectorExtraRadius = 6.0f;
    [SerializeField] private int        maxJumps = 1;
    [SerializeField] private Transform  groundDetector;
    [SerializeField] private LayerMask  groundMask;
    [SerializeField] private Collider2D groundCollider;
    [SerializeField] private Collider2D airCollider;

    private bool        onGround = false;
    private float       speedX;
    private float       lastGroundTime;
    private float       lastJumpTime;
    private int         nJumps = 0;
    private string      currentState;
    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Update character horizontal velocity
        Vector2 currentVelocity = rb.velocity;
        speedX = Input.GetAxis("Horizontal");

        DetectGround();

        if (onGround)
        {
            lastGroundTime = Time.time;
        }
        if ((Time.time - lastGroundTime) <= coyoteTime)
        {
            if (currentVelocity.y <= 0)
            {
                nJumps = maxJumps;
            }
        }
        else
        {
            if (nJumps == maxJumps)
            {
                nJumps = 0;
            }
        }

        groundCollider.enabled = onGround;
        airCollider.enabled = !onGround;

        // Apply movement
        currentVelocity.x = speedX * moveSpeed;

        if (Input.GetButtonDown("Jump") && (nJumps > 0))
        {
            // Calculate the velocity needed to achieve the desired jump height
            currentVelocity.y = Mathf.Sqrt(2f * rb.gravityScale * jumpForce * rb.mass);
            // Apply gravity
            currentVelocity.y -= rb.gravityScale * Time.deltaTime;
            // Update jump variables
            lastJumpTime = Time.time;
            lastGroundTime = 0;
            nJumps--;
        }
        else
        {
            lastJumpTime = 0;
        }

        // Apply movement
        rb.velocity = currentVelocity;

        if ((currentVelocity.x < 0) && (transform.right.x > 0))
        {
            //spriteRenderer.flipX = true;
            //transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
            transform.rotation = Quaternion.Euler(0.0f, 180.0f, 0.0f);
        }
        else if ((currentVelocity.x > 0) && (transform.right.x < 0))
        {
            //spriteRenderer.flipX = false;
            //transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            transform.rotation = Quaternion.identity;
        }
    }

    void DetectGround()
    {
        Collider2D collider = Physics2D.OverlapCircle(groundDetector.position, groundDetectorRadius, groundMask);
        if (collider != null) onGround = true;
        else
        {
            collider = Physics2D.OverlapCircle(groundDetector.position - Vector3.right * groundDetectorExtraRadius, groundDetectorRadius, groundMask);
            if (collider != null) onGround = true;
            else
            {
                collider = Physics2D.OverlapCircle(groundDetector.position + Vector3.right * groundDetectorExtraRadius, groundDetectorRadius, groundMask);
                if (collider != null) onGround = true;
                else onGround = false;
            }
        }
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    private void OnDrawGizmos()
    {
        if (groundDetector == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(groundDetector.position, groundDetectorRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(groundDetector.position - Vector3.right * groundDetectorExtraRadius, groundDetectorRadius);
        Gizmos.DrawSphere(groundDetector.position + Vector3.right * groundDetectorExtraRadius, groundDetectorRadius);
    }
}