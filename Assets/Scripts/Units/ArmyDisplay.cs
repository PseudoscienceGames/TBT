using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyDisplay : MonoBehaviour
{
	public static ArmyDisplay Instance;
	private void Awake() { Instance = this; }

	public Army army;
	public List<UnitAvatar> avatars = new List<UnitAvatar>();
	private void Start()
	{
		army.StartPlayerArmy();
		DisplayArmy();
		gameObject.SetActive(false);
	}

	public void DisplayArmy()
	{
		List<Unit> unitsLeft = new List<Unit>(army.units);
		int dim = Mathf.CeilToInt(Mathf.Sqrt(army.squads.Count));
		int x = 0;
		int y = 0;
		foreach (Squad squad in army.squads)
		{
			if (army.squads.IndexOf(squad) != 0)
			{
				Vector3 loc = new Vector3(x * 4f, 0, (-y * 3.5f) - 1.7325f);
				GameObject currentObj = Instantiate(Resources.Load("SquadPlatform"), loc, Quaternion.identity) as GameObject;
				currentObj.transform.parent = transform.Find("Platforms");
				foreach (Unit unit in squad.units)
				{
					int index = unit.squadPos;
					Vector3 newLoc = loc;
					if (index != 0)
						newLoc += HexGrid.GridToWorld(HexGrid.MoveTo(Vector2Int.zero, index - 1));
					currentObj = Instantiate(Resources.Load("UnitAvatar"), newLoc, Quaternion.identity) as GameObject;
					currentObj.transform.parent = transform.Find("Units");
					currentObj.GetComponent<UnitAvatar>().unit = unit;
					avatars.Add(currentObj.GetComponent<UnitAvatar>());
					unitsLeft.Remove(unit);
				}
				x++;
				if (x >= dim)
				{
					x = 0;
					y++;
				}
			}
		}
		x = 0; y = 0;

		dim = Mathf.CeilToInt(Mathf.Sqrt(army.units.Count));
		Vector3 start = new Vector3(-1, 0, 1.7325f);
		for(int i = 0; i < unitsLeft.Count; i++)
		{
			Vector3 loc = start + new Vector3(x * 2, 0, y * 1.7325f);
			GameObject currentObj = Instantiate(Resources.Load("UnitPlatform"), loc, Quaternion.identity) as GameObject;
			currentObj.transform.parent = transform.Find("Platforms");
			currentObj = Instantiate(Resources.Load("UnitAvatar"), loc, Quaternion.identity) as GameObject;
			currentObj.transform.parent = transform.Find("Units");
			avatars.Add(currentObj.GetComponent<UnitAvatar>());
			x++;
			if (x >= dim)
			{
				x = 0;
				y++;
			}
		}
	}

	public void Sort()
	{
		avatars = new List<UnitAvatar>();
		List<GameObject> toDestroy = new List<GameObject>();
		foreach(Transform t in transform.Find("Platforms"))
		{
			toDestroy.Add(t.gameObject);
		}
		foreach (Transform t in transform.Find("Units"))
		{
			toDestroy.Add(t.gameObject);
		}
		for (int i = 0; i < toDestroy.Count; i++)
		{
			DestroyImmediate(toDestroy[i]);
		}
		DisplayArmy();
	}
}
