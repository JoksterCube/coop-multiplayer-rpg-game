using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGeneratorTest : MonoBehaviour
{
    public Tile tilePrefab;
    public int ringRadius = 3;

    public Vector3Int spawnCoordinates;


    [ContextMenu("Spawn Tile")]
    public void SpawnNewTileTest()
    {
        SpawnTile(new Cube(spawnCoordinates), transform);
    }

    public Tile SpawnTile(Cube cube, Transform parent)
    {
        if (!cube.IsValidCube())
        {
            Debug.LogWarning("Cube is Invalid" + cube.ToString());
            return null;
        }

        Tile newTile = Instantiate(tilePrefab, parent) as Tile;
        newTile.SetTileCoordinates(cube);
        return newTile;
    }

    [ContextMenu("Spawn Ring")]
    public void SpwanHexRing()
    {
        List<Cube> ringCubes = CubeRing(Cube.Zero, ringRadius);

        foreach (Cube cube in ringCubes)
            SpawnTile(cube, transform);
    }

    [ContextMenu("Spawn Spiral")]
    public void SpwanHexSpiral()
    {
        List<Cube> spiralCubes = CubeSpiral(Cube.Zero, ringRadius);

        foreach (Cube cube in spiralCubes)
            SpawnTile(cube, transform);
    }


    public List<Cube> CubeRing(Cube center, int radius)
    {
        List<Cube> results = new List<Cube>();

        Cube cube = Cube.Add(center, Cube.Scale(Cube.Direction(4), radius));

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < radius; j++)
            {
                results.Add(cube);
                cube = Cube.Neighbour(cube, i);
            }
        }
        return results;
    }

    public List<Cube> CubeSpiral(Cube center, int radius)
    {
        List<Cube> results = new List<Cube>() { center };

        for (int i = 1; i <= radius; i++)
            results.AddRange(CubeRing(center, i));
        return results;
    }
}
