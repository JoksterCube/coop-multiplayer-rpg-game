using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tile : MonoBehaviour
{
    [ReadOnly]
    public Cube coordinates;
    public bool showLabels;

    private Vector3 coordPosition;

    public Tile() => coordinates = new Cube();
    public Tile(Cube coordinates) => this.coordinates = coordinates;


    public void Awake()
    {
        SetTileCoordinates(coordinates);
    }

    public void Start()
    {

    }

    public void SetTileCoordinates(int x, int y, int z)
    {
        coordinates.SetValues(x, y, z);
        transform.position = coordPosition = Cube.PositionFromCubeCoordinates(coordinates, Constants.HexTileOrientationPointy);
    }

    public void SetTileCoordinates(Cube c) => SetTileCoordinates(c.x, c.y, c.z);
    public void SetTileCoordinates(Vector3Int v) => SetTileCoordinates(v.x, v.y, v.z);


    void FixedUpdate()
    {
        CheckPosition();
    }

    void CheckPosition()
    {
        if (coordPosition != transform.position)
            transform.position = coordPosition;
    }

    private void OnDrawGizmos()
    {
        if (coordinates != null && showLabels)
            Handles.Label(transform.position, coordinates.ToString());
    }
}
