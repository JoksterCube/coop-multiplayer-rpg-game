using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilities
{
    public static void NearestTile()
    {

    }

    public static Vector3Int CubeCoordinatesFromPosition(Vector3 position)
    {

        return Vector3Int.zero;
    }

    public static Vector3 PositionFromCubeCoordinates(Vector3Int cubeCoordnates)
    {

        return Vector3.zero;
    }

    public static float CubeDistance(Cube a, Cube b) => (Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z)) / 2;
}
