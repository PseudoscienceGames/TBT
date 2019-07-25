using UnityEngine;
using System.Collections;

public class ASCursor : MonoBehaviour
{
	public Transform selection;

	//Check for mouse being over GUI
	public bool mouseOverGUI = false;
	public void MouseOverGUI() { mouseOverGUI = true; }
	public void MouseNotOverGUI() { mouseOverGUI = false; }
	public Vector2Int oldGridLoc;
	public Vector2Int newGridLoc;
	public LayerMask unitMask;
	public LayerMask groundMask;
	public LayerMask tileMask;

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();



		if (Input.GetMouseButtonDown(0))
		{
			if (!mouseOverGUI && Physics.Raycast(ray, out hit, 50, unitMask))
			{
				if (hit.transform.GetComponent<UnitAvatar>() != null)
				{
					selection = hit.transform;
					selection.GetComponent<SphereCollider>().enabled = false;
					oldGridLoc = HexGrid.RoundToGrid(hit.point);
				}
			}
		}
		if (Input.GetMouseButton(0))
		{
			if (!mouseOverGUI && Physics.Raycast(ray, out hit, 50, groundMask) && selection != null)
			{
				selection.transform.position = hit.point;
				newGridLoc = HexGrid.RoundToGrid(hit.point);
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			if (selection != null)
			{
				if (Physics.Raycast(ray, out hit, 50, groundMask))
				{
					if (hit.point.z >= 0)
					{
						if (HexGrid.GridToWorld(oldGridLoc).z >= 0)
						{
							selection.transform.position = HexGrid.GridToWorld(oldGridLoc);
						}
						else
						{

						}
					}
					else
					{
						if (Physics.Raycast(ray, out hit, 50, tileMask))
						{

						}
						else
						{
							Unit unit = selection.GetComponent<UnitAvatar>().unit;
							ArmyDisplay.Instance.army.AddSquad(unit);
						}
					}	
				}
				if (selection != null)
				{
					selection.GetComponent<SphereCollider>().enabled = true;
					selection = null;
				}
			}
		}
		
	}
}
