using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Player : MonoBehaviour
{
    private Movement movement;
    private void Awake()
    {
        movement = GetComponent<Movement>();
    }

    private void Update()
    {
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(inputVector.sqrMagnitude > 0)
            movement.SetInputVector(inputVector);
    }
}
