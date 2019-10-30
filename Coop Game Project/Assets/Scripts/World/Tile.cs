using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tile : MonoBehaviour
{
    [ReadOnly]
    public Cube coordinates;

    public void Awake()
    {

    }


    void FixedUpdate()
    {
        CheckCoordinates();
        CheckPosition();
    }

    void CheckCoordinates()
    {

    }

    void CheckPosition()
    {

    }

    private void OnDrawGizmos() => Handles.Label(transform.position, coordinates.ToString());
}
