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

	public void StartPlayerArmy()
	{
		squads.Add(new Squad(this));
		for (int i = 0; i < 9; i++)
		{
			AddUnit();
		}
	}

	public void AddUnit()
	{
		Unit unit = new Unit();
		units.Add(unit);
		unit.CalcStats();
		squads[0].AddUnit(unit);
		unit.mySquad = 0;
	}
	public void AddSquad(Unit unit)
	{
		squads.Add(new Squad(this, unit));

		MoveUnit(unit, squads.Count - 1);
		ArmyDisplay.Instance.Sort();
	}

	public void MoveUnit(Unit unit, int squad)
	{
		Debug.Log(unit.mySquad);
		squads[unit.mySquad].RemoveUnit(unit);
		squads[squad].AddUnit(unit);
		unit.mySquad = squad;
	}
}
