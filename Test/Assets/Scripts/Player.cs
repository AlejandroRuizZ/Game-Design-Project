using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public Animator anim1;
    public Animator anim2;
    public bool checkground = true;

    private bool attack;

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
        HandleImput();

    }

    void FixedUpdate()
    {
        RunningMovement();
        Attacks();
        ResetValues();
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
        if ((move > 0 && !facingRight) || (move < 0 && facingRight))
            Flip();
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
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
        Debug.Log("JUmp is called");
        if (checkground)
        {
            if (isStandingOnGround && Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("input recieved");
                rb.velocity = new Vector2(0, simpleJumpForce);
            }
            if (Input.GetButtonDown("Jump"))
            {
                anim1.SetBool("IsJumping", true);
                anim1.SetTrigger("jump");
                checkground = false;
                StartCoroutine(jumpcooldown());
                Debug.Log("jump");
            }
            else
            {
                if (isStandingOnGround)
                    anim1.SetBool("IsJumping", false);

            }
        }

    }

    private void Attacks()
    {
        if (attack)
            anim2.SetTrigger("Attack");
    }

    private void HandleImput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            attack = true;
        }
    }
    private void ResetValues()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            attack = false;
        }
    }

    IEnumerator jumpcooldown()
    {
    yield return new WaitForSeconds(.2f);
    checkground = true;
    }

}