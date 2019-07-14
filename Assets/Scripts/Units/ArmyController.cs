using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyController : MonoBehaviour
{
	public static ArmyController Instance;
	private void Awake() { Instance = this; }

	public int armyCount;
	public int initUnitCount;
	public List<Army> armies = new List<Army>();

	public void CalcArmies()
	{
		for (int i = 0; i < armyCount; i++)
		{
			armies.Add(new Army());
			if (i == 0)
				armies[0].isPlayer = true;
			armies[i].Init();
		}
		ArmyDisplay.Instance.DisplayArmy();
		ArmyDisplay.Instance.gameObject.SetActive(false);
	}
}
