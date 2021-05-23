using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Main
    public GameObject gameController;

    // Components
    Rigidbody _rb;

    // Setting
    public bool _isGrounded;
    public float JumpForce = 1;
    public float SpeedForce = 100;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * SpeedForce * Time.fixedDeltaTime);
    }

    public void Jump()
    {
        if (_isGrounded)
        {
            _rb.AddForce(Vector3.up * JumpForce);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}
