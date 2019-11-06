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

}
