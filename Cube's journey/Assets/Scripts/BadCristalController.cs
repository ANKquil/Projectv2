using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadCristalController : MonoBehaviour
{
    public GameObject gameController;
    GameController controller;

    void Start()
    {
        controller = gameController.GetComponent<GameController>();
    }

    private void OnTriggerEnter(Collider Player)
    {
        controller.Dead();
        Destroy(gameObject);
    }
}
