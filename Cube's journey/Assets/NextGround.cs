using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextGround : MonoBehaviour
{
    public GameObject gameController;
    private GameController controller;

    void Start()
    {
        controller = gameController.GetComponent<GameController>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider Player)
    {
        controller.TriggerActive();
    }
}