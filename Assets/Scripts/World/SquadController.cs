using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquadController : MonoBehaviour
{
	public static SquadController Instance;
	private void Awake() { Instance = this; }

	public List<SquadAvatar> squads = new List<SquadAvatar>();

	public void SpawnSquad(Army army, Squad squad, Vector2Int loc)
	{
		SquadAvatar squadAvi = (Instantiate(Resources.Load("SquadAvatar"),
								HexGrid.GridToWorld(loc, Mathf.RoundToInt(WorldData.Instance.worldTiles[loc].h / HexGrid.tileHeight)),
								Quaternion.identity) as GameObject).GetComponent<SquadAvatar>();
		squadAvi.transform.parent = transform;
		squadAvi.squad = squad;
		squadAvi.army = army;
	}
}
