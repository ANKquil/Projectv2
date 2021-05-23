using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Main
    public GameObject gameController;

    // Components
    Rigidbody rb;

    // Setting
    public float JumpForce = 1;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * JumpForce);
    }
}
