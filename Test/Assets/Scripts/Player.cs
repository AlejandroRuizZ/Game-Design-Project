using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveAmount;
    public float forceAmount;
    public Rigidbody2D rb;
    public float JumpAmount;
    public Animator anmim; 
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RigidbodyForce();
    }

    void RigidbodyForce()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, JumpAmount));
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(forceAmount, 0));

        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-forceAmount, 0));

        }

        anmim.SetFloat("Speed", rb.velocity.x);
    }
}
