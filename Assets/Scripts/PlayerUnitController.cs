using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Math;

public class PlayerUnitController : MonoBehaviour
{
	private Team playerTeam;
	public GameObject pawnPrefab;
	public GameObject tilePrefab;
	public float gap;

	void Start()
	{
		playerTeam = GameObject.FindGameObjectWithTag("PlayerTeam").GetComponent<Team>();
	}

	public void DisplayUnits()
	{
		int unitIndex = 0;
		AddUnit(Vector3.zero, unitIndex);

		int maxRadius = 1;

		for (int fRadius = 1; fRadius <= maxRadius; fRadius++)
		{
			//Set initial hex grid location
			Vector3 gridLoc = new Vector3(fRadius, 0, -fRadius);

			int dir = 2;
			//Find data for each hex in the ring (each ring has 6 more hexes than the last)
			for (int fHex = 0; fHex < 6 * fRadius; fHex++)
			{
				//Finds next hex in ring
				gridLoc = GridCalc.MoveTo(gridLoc, dir);
				//gridLoc.y = -unitIndex;
				unitIndex++;
				if(unitIndex < playerTeam.units.Count)
					AddUnit(gridLoc, unitIndex);
				Debug.Log(unitIndex);
				if (gridLoc.x == 0 || gridLoc.z == 0 || gridLoc.x == -gridLoc.z)
				{
					dir++;
				}
			}
			if(unitIndex <= playerTeam.units.Count)
			{
				maxRadius++;
			}
		}
	}
	void AddUnit(Vector3 gridLoc, int unitIndex)
	{
		Vector3 pos = GridCalc.GridToWorld(gridLoc) * gap;
		pos.y = pos.z / 4f;
		GameObject currentTile = Instantiate(tilePrefab, pos, Quaternion.identity) as GameObject;
		currentTile.transform.parent = transform.parent.FindChild("Tiles");
		GameObject currentPawn = Instantiate(pawnPrefab, pos, Quaternion.AngleAxis(180, Vector3.up)) as GameObject;
		currentPawn.GetComponent<Pawn>().unit = playerTeam.units[unitIndex];
		currentPawn.name = playerTeam.units[unitIndex].name;
		currentPawn.transform.parent = transform;
	}
}
