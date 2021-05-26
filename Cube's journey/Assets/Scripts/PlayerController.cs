using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    // Main
    public bool active = false;
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
        if (active)
            transform.position = Vector3.Lerp(transform.position, 
                new Vector3(transform.position.x, transform.position.y, transform.position.z + 1), 
                Time.fixedDeltaTime * SpeedForce);
    }

    public void Jump()
    {
        if (_isGrounded && active)
        {
            _rb.AddForce(Vector3.up * JumpForce);
            _isGrounded = false;
        }
    }

    public void Stop()
    {
        active = false;
    }
    public void Go()
    {
        active = true;
    }

    public void Down()
    {
        if (!_isGrounded && active)
        {
            _rb.AddForce(-Vector3.up * JumpForce * 1.9f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}