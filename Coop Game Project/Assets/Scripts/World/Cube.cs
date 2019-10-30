using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Cube
{
    public int x;
    public int y;
    public int z;

    public static Cube Zero => new Cube(Vector3Int.zero);
    public static Cube One => new Cube(Vector3Int.one);

    public void SetValues(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }
    public void SetValues(Cube c) => SetValues(c.x, c.y, c.z);
    public void SetValues(Vector3Int v) => SetValues(v.x, v.y, v.z);

    public Vector3Int CubeVector() => new Vector3Int(x, y, z);
    public Vector3Int CubeVector(Cube c) => new Vector3Int(c.x, c.y, c.z);

    public Cube(int x, int y, int z)
    {
        if (IsValidCube(x, y, z))
            SetValues(x, y, z);
        else SetValues(Zero);
    }
    public Cube(Cube c) : this(c.x, c.y, c.z) { }
    public Cube(Vector3Int v) : this(v.x, v.y, v.z) { }

    public bool IsValidCube() => x + y + z == 0;
    public bool IsValidCube(Cube c) => IsValidCube(c.x, c.y, c.z);
    public bool IsValidCube(Vector3Int v) => IsValidCube(v.x, v.y, v.z);
    public bool IsValidCube(int x, int y, int z) => x + y + z == 0;


    public override string ToString() => CubeVector().ToString();
}
