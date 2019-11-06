using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Cube currentPositionCube = Cube.Zero;
    Cube lastPositionCube;

    float cooldown = 1;
    float cooldownTime = 0;

    private void Awake()
    {
        lastPositionCube = currentPositionCube;
    }
    private void Start()
    {

    }

    private void Update()
    {
        if(Time.time >= cooldownTime)
        { 
            Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (inputVector.sqrMagnitude > 0)
            {
                MoveToVector(inputVector);
                cooldownTime = Time.time + cooldown;
            }
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

    public void MoveToVector(Vector2 directionVector)
    {
        Cube newPositionCubeCoordinate = Cube.Neighbour(currentPositionCube, directionVector);
        MoveToCube(newPositionCubeCoordinate);
    }
    public void MoveToDirection(int direction)
    {
        Cube newPositionCubeCoordinate = Cube.Neighbour(currentPositionCube, direction);
        MoveToCube(newPositionCubeCoordinate);
    }
    
    public void MoveToCube(Cube newPositionCubeCoordinate)
    {
        lastPositionCube = currentPositionCube;
        currentPositionCube = newPositionCubeCoordinate;
    }    
}
