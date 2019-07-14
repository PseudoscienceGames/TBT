using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Army
{
	public string myName;
	public bool isPlayer;
	public List<Squad> squads = new List<Squad>();
	public List<Unit> units = new List<Unit>();
	public List<Vector2Int> land = new List<Vector2Int>();

	public void Init()
	{
		Vector2Int initLand = BuildingController.Instance.RandomFlatTile();
		while(BuildingController.Instance.buildings.ContainsKey(initLand))
			initLand = BuildingController.Instance.RandomFlatTile();
		land.Add(initLand);
		BuildingController.Instance.AddBuilding(this, initLand);
		for (int i = 0; i < ArmyController.Instance.initUnitCount; i++)
		{
			units.Add(new Unit());
			units[i].CalcStats();
		}
		squads.Add(new Squad(ArmyController.Instance.armies.IndexOf(this)));
		for (int i = 0; i < units.Count; i++)
		{
			squads[0].AddUnit(units[i]);
			
		}
	}

	public void DeploySquad(Squad squad)
	{
		SquadController.Instance.SpawnSquad(this, squad, land[0]);
	}
}
