using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyDisplay : MonoBehaviour
{
	public static ArmyDisplay Instance;
	private void Awake() { Instance = this; }

	public LayerMask unitMask;
	public LayerMask groundMask;
	public GameObject selectedUnit;

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100, unitMask))
			{
				selectedUnit = hit.transform.gameObject;
			}
			else
			{
				if(hit.point.z > 0)

				selectedUnit = null;
				
			}
		}
		if(selectedUnit != null)
		{
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit, 100, groundMask))
				selectedUnit.transform.position = hit.point;
		}
	}

	public void DisplayArmy()
	{
		Army army = ArmyController.Instance.armies[0];
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
				currentObj.transform.parent = transform;
				foreach (int index in squad.units.Keys)
				{
					Vector3 newLoc = loc;
					if (index != 0)
						newLoc += HexGrid.GridToWorld(HexGrid.MoveTo(Vector2Int.zero, index - 1));
					currentObj = Instantiate(Resources.Load("UnitAvatar"), newLoc, Quaternion.identity) as GameObject;
					currentObj.transform.parent = transform;
					currentObj.GetComponent<UnitAvatar>().unit = squad.units[index];
					unitsLeft.Remove(squad.units[index]);
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

		dim *= 2;
		Vector3 start = new Vector3(-1, 0, 1.7325f);
		for(int i = 0; i < unitsLeft.Count; i++)
		{
			Vector3 loc = start + new Vector3(x * 2, 0, y * 1.7325f);
			GameObject currentObj = Instantiate(Resources.Load("UnitPlatform"), loc, Quaternion.identity) as GameObject;
			currentObj.transform.parent = transform;
			currentObj = Instantiate(Resources.Load("UnitAvatar"), loc, Quaternion.identity) as GameObject;
			currentObj.transform.parent = transform;
			x++;
			if (x >= dim)
			{
				x = 0;
				y++;
			}
		}
	}
}
