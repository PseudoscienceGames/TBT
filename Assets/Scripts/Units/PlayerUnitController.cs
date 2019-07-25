using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerUnitController : MonoBehaviour
{
	//public static PlayerUnitController Instance;
	//private void Awake() { Instance = this; }

	//private Army army;
	//public GameObject pawnPrefab;
	//public GameObject tilePrefab;
	//public GameObject squadPrefab;
	//public float gap;

	//public Dictionary<Vector2Int, int> units = new Dictionary<Vector2Int, int>();

	//public void DisplayUnits()
	//{
	//	army = ArmyDisplay.Instance.army;
	//	int unitIndex = 0;
	//	AddUnit(Vector2Int.zero, unitIndex);

	//	int maxRadius = 1;

	//	for (int fRadius = 1; fRadius <= maxRadius; fRadius++)
	//	{
	//		//Set initial hex grid location
	//		Vector2Int gridLoc = new Vector2Int(fRadius, -fRadius);

	//		int dir = 2;
	//		//Find data for each hex in the ring (each ring has 6 more hexes than the last)
	//		for (int fHex = 0; fHex < 6 * fRadius; fHex++)
	//		{
	//			//Finds next hex in ring
	//			gridLoc = HexGrid.MoveTo(gridLoc, dir);
	//			//gridLoc.y = -unitIndex;
	//			unitIndex++;
	//			if(unitIndex < army.units.Count)
	//				AddUnit(gridLoc, unitIndex);
	//			if (gridLoc.x == 0 || gridLoc.y == 0 || gridLoc.x == -gridLoc.y)
	//			{
	//				dir++;
	//			}
	//		}
	//		if(unitIndex <= army.units.Count)
	//		{
	//			maxRadius++;
	//		}
	//	}
	//}
	//void AddUnit(Vector2Int gridLoc, int unitIndex)
	//{
	//	Vector3 pos = HexGrid.GridToWorld(gridLoc) * gap;
	//	GameObject currentPawn = Instantiate(pawnPrefab, pos, Quaternion.AngleAxis(180, Vector3.up)) as GameObject;
	//	units.Add(gridLoc, unitIndex);
	//	currentPawn.GetComponent<UnitAvatar>().unit = army.units[unitIndex];
	//	currentPawn.name = army.units[unitIndex].myName;
	//	currentPawn.transform.parent = transform;
	//}

	//public void MoveUnit(Vector2Int oldGridLoc, Vector2Int newGridLoc)
	//{
	//	units.Add(newGridLoc, units[oldGridLoc]);
	//	units.Remove(oldGridLoc);
	//	CheckForSquads(newGridLoc);
	//}

	//public void CheckForSquads(Vector2Int gridLoc)
	//{
	//	bool hasSquad = false;
	//	for(int dir = 0; dir < 6; dir++)
	//	{
	//		Vector2Int adjLoc = HexGrid.MoveTo(gridLoc, dir);
 //           if (units.ContainsKey(adjLoc))
	//		{
	//			Unit movedUnit = army.units[units[gridLoc]];
	//			Unit adjUnit = army.units[units[adjLoc]];
	//			if (adjUnit.mySquad != 0)
	//			{
	//				movedUnit.mySquad = adjUnit.mySquad;
	//				army.squads[adjUnit.mySquad].AddUnit(army.units[units[gridLoc]]);
	//			}
	//			else
	//			{
	//				GameObject squad = CreateNewSquad();
	//				movedUnit.mySquad = army.squads.Count - 1;
	//				adjUnit.mySquad = army.squads.Count - 1;
	//				squad.GetComponent<Squad>().AddUnit(army.units[units[gridLoc]]);
	//				squad.GetComponent<Squad>().AddUnit(army.units[units[adjLoc]]);
	//			}
	//			hasSquad = true;
	//		}
	//	}
	//	//if (!hasSquad)
	//	//	units[gridLoc].squad = null;
 //   }

	//public GameObject CreateNewSquad()
	//{
	//	army.squads.Add(new Squad());
	//	return Instantiate(squadPrefab);
		
	//}


}
