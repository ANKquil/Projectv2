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
    public float SpeedForce = 15;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        Move();
    }

    void Move()
    {
        transform.position = Vector3.Lerp(transform.position, 
            new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), 
            Time.fixedDeltaTime * SpeedForce);
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