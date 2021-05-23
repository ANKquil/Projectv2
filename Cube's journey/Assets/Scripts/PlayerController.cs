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
    public float JumpForce = 1;
    public float SpeedForce = 100;

    private void Awake()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
    }

    void Start()
    {
        
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
        _rb.AddForce(Vector3.up * JumpForce);
    }
}
