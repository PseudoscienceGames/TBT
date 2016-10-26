using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Team : MonoBehaviour
{
	public int numOfStartingUnits;
	public List<Unit> units = new List<Unit>();

	void Start()
	{
		GenInitialUnits();
		GetComponent<PlayerUnitController>().DisplayUnits();
	}

	void GenInitialUnits()
	{
		for(int i = 0; i < numOfStartingUnits; i++)
		{
			Unit currentUnit = new Unit();
			currentUnit.name = Random.Range(1000, 9999).ToString();
			currentUnit.level = 1;
			currentUnit.myClass = (Unit.unitClass)Random.Range(0, (int)Unit.unitClass.Count);
			units.Add(currentUnit);
		}
	}
}
