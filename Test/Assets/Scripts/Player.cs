using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    [Header("Speed Settings")]
    public float maxGroundSpeed;
    public float maxAirSpeed;
    private bool facingRight = true;

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundCheckLayers;
    private bool isStandingOnGround = false;

    [Header("Jumping Settings")]
    public float simpleJumpForce;
    public float fallMultiplier = 2.5f;
    public float jumpMultiplier = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        SimpleJump();
    }

    void FixedUpdate()
    {
        RunningMovement();
    }
    void LateUpdate()
    {
        CheckIfOnGround();
    }
    void RunningMovement()
    {
        float move = Input.GetAxis("Horizontal");
        float maxSpeed = maxAirSpeed;
        if (isStandingOnGround)
            maxSpeed = maxGroundSpeed;
        float speedMove = move * maxSpeed * Time.fixedDeltaTime;
        rb.velocity = new Vector2(speedMove, rb.velocity.y);

        anim.SetFloat("Speed", rb.velocity.x);
    }
    


    void CheckIfOnGround()
    {
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = false;
        Collider2D[] results = new Collider2D[2];
        isStandingOnGround = false;
        if (Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, filter, results) > 0)
        {
            foreach (Collider2D c in results)
                if (c != null && c.attachedRigidbody != rb)
                    isStandingOnGround = true;
        }
    }
    void SimpleJump()
    {
        if (isStandingOnGround && Input.GetButtonDown("Jump"))
            rb.velocity = new Vector2(0, simpleJumpForce);
    }
}