using UnityEngine;

[System.Serializable]
public class Cube
{
    public static Cube Zero => new Cube(Vector3Int.zero);
    public static Cube One => new Cube(Vector3Int.one);

    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    private static Cube[] CubeDirections { get; } = {
        new Cube(+1, -1, 0),
        new Cube(+1, 0, -1),
        new Cube(0, +1, -1),
        new Cube(-1, +1, 0),
        new Cube(-1, 0, +1),
        new Cube(0, -1, +1)
    };

    public void SetValues(int x, int y, int z)
    {
        if (IsValidCube(x, y, z))
        {
            X = x;
            Y = y;
            Z = z;
        }
        else
        {
            Debug.LogWarning("Invalid Cube " + (new Vector3Int(x, y, z).ToString()));
            X = 0;
            Y = 0;
            Z = 0;
        }
    }
    public void SetValues(Cube c)
    {
        if (c != null)
            SetValues(c.X, c.Y, c.Z);
        else
            Debug.LogWarning("Cube is null.");
    }
    public void SetValues(Vector3Int v) => SetValues(v.x, v.y, v.z);

    public Vector3Int CubeVector() => new Vector3Int(X, Y, Z);

    public Cube() => SetValues(Zero);
    public Cube(int x, int y, int z)
    {
        if (IsValidCube(x, y, z))
            SetValues(x, y, z);
        else
        {
            Debug.LogWarning("Invalid cube " + (new Vector3Int(x, y, z).ToString()));
            SetValues(Zero);
        }
    }
    public Cube(Cube c) : this(c.X, c.Y, c.Z) { }
    public Cube(Vector3Int v) : this(v.x, v.y, v.z) { }

    public bool IsValidCube() => X + Y + Z == 0;
    public static bool IsValidCube(Cube c) => IsValidCube(c.X, c.Y, c.Z);
    public static bool IsValidCube(Vector3Int v) => IsValidCube(v.x, v.y, v.z);
    public static bool IsValidCube(int x, int y, int z) => x + y + z == 0;

    public override string ToString() => CubeVector().ToString();


    //TODO
    public static Cube CubeCoordinatesFromPosition(Vector3 position)
    {
        NearestPositionCoordinates(position);
        return Zero;
    }

    public static Vector3 PositionFromCubeCoordinates(int x, int y, int z, bool pointy)
    {
        if (!IsValidCube(x, y, z))
        {
            Debug.LogWarning("Invalid Cube" + (new Vector3Int(x, y, z).ToString()));
            return Vector3.zero;
        }

        float w = Mathf.Sqrt(3) * Constants.HexTileRadiusWithOffset;
        float h = 2 * Constants.HexTileRadiusWithOffset;

        if (!pointy)
            Utilities.Swap(ref w, ref h);

        int q = x;
        int r = z;

        float newX;
        float newZ;

        if (pointy)
        {
            newX = .5f * w * r + w * q;
            newZ = -.75f * h * r;
        }
        else
        {
            newX = .75f * w * q;
            newZ = -.5f * h * q + -h * r;
        }

        return new Vector3(newX, Constants.TileMapHeight, newZ);
    }
    public static Vector3 PositionFromCubeCoordinates(Cube c, bool pointy) => PositionFromCubeCoordinates(c.X, c.Y, c.Z, pointy);
    public static Vector3 PositionFromCubeCoordinates(Vector3Int v, bool pointy) => PositionFromCubeCoordinates(v.x, v.y, v.z, pointy);


    public static Cube NearestPositionCoordinates(Vector3 position)
    {
        return Zero;
    }




    public static float Distance(Cube a, Cube b)
    {
        if (a != null && b != null)
            return (Mathf.Abs(a.X - b.X) + Mathf.Abs(a.Y - b.Y) + Mathf.Abs(a.Z - b.Z)) / 2;
        else
            Debug.LogWarning("One or more of the cubes are nulls.");
        return 0;
    }

    public static Cube Add(Cube a, Cube b) => new Cube(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    public static Cube Scale(Cube a, int b) => new Cube(a.X * b, a.Y * b, a.Z * b);
    public static Cube Direction(int direction) => CubeDirections[direction];
    public static Cube Neighbour(Cube cube, int direction) => Add(cube, Direction(direction));
}
