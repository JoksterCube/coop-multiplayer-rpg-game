using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Cube currentPositionCube = Cube.Zero;
    private Cube lastPositionCube;

    private Vector2 inputVector;
    private bool newInput = false;

    private float moveCooldown = .5f;
    private float nextMoveAwailable = 0f; 

    private void Awake()
    {
        lastPositionCube = currentPositionCube;
    }
    private void Update()
    {
        if(newInput)
        {
            MoveToVector(inputVector);
            newInput = false;
        }
    }


    private void FixedUpdate()
    {
        if(lastPositionCube != currentPositionCube)
        {
            transform.position = Cube.PositionFromCubeCoordinates(currentPositionCube, Constants.HexTileOrientationPointy);
            lastPositionCube = currentPositionCube;
        }
    }

    public void SetInputVector(Vector2 inputVector)
    {
        if (Time.time > nextMoveAwailable)
        {
            this.inputVector = inputVector;
            newInput = true;
        }
    }

    public void MoveToVector(Vector2 directionVector)
    {
        Cube newPositionCubeCoordinate = Cube.Neighbour(currentPositionCube, directionVector);
        MoveToCube(newPositionCubeCoordinate);
    }
    
    public void MoveToCube(Cube newPositionCubeCoordinate)
    {
        nextMoveAwailable = Time.time + moveCooldown;
        lastPositionCube = currentPositionCube;
        currentPositionCube = newPositionCubeCoordinate;
    }    
}
