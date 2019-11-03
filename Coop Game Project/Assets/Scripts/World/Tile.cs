using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Tile : MonoBehaviour
{
    public Cube Coordinates { get; set; }

    private Vector3 coordPosition;

    public Tile() => Coordinates = new Cube();
    public Tile(Cube coordinates) => Coordinates = coordinates;


    public void Awake()
    {
        SetTileCoordinates(Coordinates);
    }

    public void Start()
    {

    }

    public void SetTileCoordinates(int x, int y, int z)
    {
        Coordinates.SetValues(x, y, z);
        transform.position = coordPosition = Cube.PositionFromCubeCoordinates(Coordinates, Constants.HexTileOrientationPointy);
    }

    public void SetTileCoordinates(Cube c) => SetTileCoordinates(c.X, c.Y, c.Z);
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
        if (Coordinates != null)
            Handles.Label(transform.position, Coordinates.ToString());
    }
}
