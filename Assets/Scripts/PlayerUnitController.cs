using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Math;

public class PlayerUnitController : MonoBehaviour
{
	private Team playerTeam;
	public GameObject pawnPrefab;
	public GameObject tilePrefab;
	public GameObject squadPrefab;
	public float gap;

	public Dictionary<Vector3, int> units = new Dictionary<Vector3, int>();

	public void DisplayUnits()
	{
		playerTeam = GameObject.FindGameObjectWithTag("PlayerTeam").GetComponent<Team>();
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
		GameObject currentPawn = Instantiate(pawnPrefab, pos, Quaternion.AngleAxis(180, Vector3.up)) as GameObject;
		units.Add(GridCalc.WorldToGrid(pos), unitIndex);
		currentPawn.GetComponent<Pawn>().unit = playerTeam.units[unitIndex];
		currentPawn.name = playerTeam.units[unitIndex].name;
		currentPawn.transform.parent = transform;
	}

	public void MoveUnit(Vector3 oldGridLoc, Vector3 newGridLoc)
	{
		units.Add(newGridLoc, units[oldGridLoc]);
		units.Remove(oldGridLoc);
		CheckForSquads(newGridLoc);
	}

	public void CheckForSquads(Vector3 gridLoc)
	{
		bool hasSquad = false;
		for(int dir = 0; dir < 6; dir++)
		{
			Vector3 adjLoc = GridCalc.MoveTo(gridLoc, dir);
            if (units.ContainsKey(adjLoc))
			{
				Debug.Log(units[adjLoc]);
				if (GetComponent<Team>().units[units[adjLoc]].squad != null)
					GetComponent<Team>().units[units[gridLoc]].squad = GetComponent<Team>().units[units[adjLoc]].squad;
				else
				{
					GameObject squad = CreateNewSquad();
					GetComponent<Team>().units[units[gridLoc]].squad = squad.GetComponent<Squad>();
					GetComponent<Team>().units[units[adjLoc]].squad = squad.GetComponent<Squad>();
				}
				hasSquad = true;
			}
		}
		//if (!hasSquad)
		//	units[gridLoc].squad = null;
    }

	public GameObject CreateNewSquad()
	{
		return Instantiate(squadPrefab);
	}


}
