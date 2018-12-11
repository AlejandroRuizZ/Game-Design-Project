using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float moveAmount;
    public float forceAmount;
    public Rigidbody rb;
    public float JumpAmount;
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
            rb.AddForce(new Vector3(0, JumpAmount, 0), ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector3(forceAmount, 0, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector3(-forceAmount, 0, 0));
        }
        if (Input.GetKey(KeyCode.W))
            {
            rb.AddForce(new Vector3(0, 0, forceAmount));
        }
        if (Input.GetKey(KeyCode.S))
            {
            rb.AddForce(new Vector3(0, 0, -forceAmount));
        }
    }
}