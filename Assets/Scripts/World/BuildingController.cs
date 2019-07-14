using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour
{
	public static BuildingController Instance;
	private void Awake() { Instance = this; }

	public List<Vector2Int> flatLand = new List<Vector2Int>();
	public Dictionary<Vector2Int, Building> buildings = new Dictionary<Vector2Int, Building>();

	public void AddBuilding(Army army, Vector2Int loc)
	{
		Vector3 worldLoc = HexGrid.GridToWorld(loc, Mathf.RoundToInt(WorldData.Instance.worldTiles[loc].h / HexGrid.tileHeight));

		GameObject currentBuilding = Instantiate(Resources.Load("Building"), worldLoc, Quaternion.identity) as GameObject;
		currentBuilding.transform.parent = transform;
		buildings.Add(loc, currentBuilding.GetComponent<Building>());
		currentBuilding.GetComponent<Building>().owner = ArmyController.Instance.armies.IndexOf(army);
	}

	public Vector2Int RandomFlatTile()
	{
		return flatLand[Random.Range(0, flatLand.Count)];
	}
}
