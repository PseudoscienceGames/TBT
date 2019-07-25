using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Squad
{
	public Army myArmy;
	public List<Unit> units = new List<Unit>();

	public Squad(Army army, Unit leader)
	{
		myArmy = army;
		AddUnit(leader);
	}
	public Squad(Army army)
	{
		myArmy = army;
	}
	public void AddUnit(Unit unit)
	{
		units.Add(unit);
	}
	public void RemoveUnit(Unit unit)
	{
		units.RemoveAt(units.IndexOf(unit));
	}
}
