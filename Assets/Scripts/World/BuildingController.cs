using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
	public static BuildingController Instance;
	private void Awake() { Instance = this; }

	public List<Vector2Int> flatLand = new List<Vector2Int>();
	public Dictionary<Vector2Int, Building> buildings = new Dictionary<Vector2Int, Building>();
	public List<Mesh> meshes = new List<Mesh>();

	public void AddBuilding()
	{
		Vector2Int loc = RandomFlatTile();
		while(buildings.ContainsKey(loc))
			loc = RandomFlatTile();
		Vector3 worldLoc = HexGrid.GridToWorld(loc, Mathf.RoundToInt(WorldData.Instance.worldTiles[loc].h / HexGrid.tileHeight));

		GameObject currentBuilding = Instantiate(Resources.Load("Building"), worldLoc, Quaternion.Euler(0, Random.Range(0, 5) * 60, 0)) as GameObject;
		currentBuilding.transform.parent = transform;
		buildings.Add(loc, currentBuilding.GetComponent<Building>());
		currentBuilding.GetComponentInChildren<MeshFilter>().mesh = meshes[Random.Range(0, meshes.Count)];
	}

	public Vector2Int RandomFlatTile()
	{
		return flatLand[Random.Range(0, flatLand.Count)];
	}
}
