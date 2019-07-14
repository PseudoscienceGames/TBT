using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Squad
{
	public int myArmy;
	public Dictionary<int, Unit> units = new Dictionary<int, Unit>();

	public Squad(int army)
	{
		myArmy = army;
	}

	public void AddUnit(Unit unit)
	{
		unit.mySquad = ArmyController.Instance.armies[myArmy].squads.IndexOf(this);
		int slot = 0;
		while(units.ContainsKey(slot))
		{
			slot++;
		}
		units.Add(slot, unit);
	}
}
