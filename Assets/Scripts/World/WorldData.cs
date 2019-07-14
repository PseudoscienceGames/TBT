﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(WorldMesh))]
public class WorldData : MonoBehaviour
{
	public static WorldData Instance;
	private void Awake(){ Instance = this; }

	public int worldSize;
	public List<Vector3Int> islandInfo = new List<Vector3Int>();
	public List<IslandData> islands = new List<IslandData>();
	public Dictionary<Vector2Int, WorldTile> worldTiles = new Dictionary<Vector2Int, WorldTile>();
	private List<Vector2Int> usedTiles = new List<Vector2Int>();

	private void Start()
	{
		GenWorldData();
		ArmyController.Instance.CalcArmies();
	}

	void GenWorldData()
	{
		
		foreach(Vector3Int v in islandInfo)
		{
			for (int i = 0; i < v.z; i++)
			{
				AddIsland(Random.Range(v.x, v.y));
			}
		}
		
		Debug.Log(usedTiles.Count);
		GetComponent<WorldMesh>().GenMesh();
	}

	void AddIsland(int islandSize)
	{
		if (islandSize < 2) islandSize = 2;
		List<Vector2Int> tiles = new List<Vector2Int>();
		List<Vector2Int> possTiles = new List<Vector2Int>();

		IslandData currentIsland = new IslandData();
		Vector2Int loc = Vector2Int.zero;
		int x = 0;
		while (usedTiles.Contains(loc))
		{
			if (x >= 10)
			{
				worldSize++;
				x = 0;
				Debug.Log("X");
			}
			Vector3 spot = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)) * worldSize;
			loc = HexGrid.RoundToGrid(spot);
			x++;
		}
		tiles.Add(loc);

		foreach (Vector2Int v in HexGrid.FindAdjacentGridLocs(loc))
		{
			if (!tiles.Contains(v) && !possTiles.Contains(v) && !usedTiles.Contains(v))
				possTiles.Add(v);
		}
		while (tiles.Count < islandSize && possTiles.Count > 0)
		{
			Vector2Int tile = possTiles[Random.Range(0, possTiles.Count)];
			foreach (Vector2Int v in HexGrid.FindAdjacentGridLocs(tile))
			{
				if (!tiles.Contains(v) && !possTiles.Contains(v) && !usedTiles.Contains(v))
					possTiles.Add(v);
			}
			possTiles.Remove(tile);
			tiles.Add(tile);
		}
        if (tiles.Count == islandSize)
        {
            foreach (Vector2Int v in HexGrid.FindOutline(tiles))
                tiles.Add(v);
            List<Vector2Int> remove = new List<Vector2Int>();
            remove.AddRange(tiles);
            remove.AddRange(HexGrid.FindOutline(remove));
            remove.AddRange(HexGrid.FindOutline(remove));
            remove.AddRange(HexGrid.FindOutline(remove));

            foreach (Vector2Int v in remove)
                usedTiles.Add(v);
            foreach (Vector2Int v in tiles)
            {
                currentIsland.tiles.Add(new WorldTile(v));
                currentIsland.gridLocs.Add(v);
            }
            foreach (Vector2Int v in tiles)
            {
                foreach (Vector2Int adj in HexGrid.FindAdjacentGridLocs(v))
                {
                    if (tiles.Contains(adj))
                        currentIsland.tiles[currentIsland.gridLocs.IndexOf(v)].connections.Add(adj);
                }
            }
            currentIsland.CalcHeights();
            islands.Add(currentIsland);
        }
        else
            AddIsland(islandSize);
	}
}
