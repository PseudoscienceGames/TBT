using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour
{
	public GameObject selection;

	//Check for mouse being over GUI
	public bool mouseOverGUI = false;
	public void MouseOverGUI() { mouseOverGUI = true; }
	public void MouseNotOverGUI() { mouseOverGUI = false; }
	public Vector3 lastTileWorldLoc;

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();



		if (Input.GetMouseButtonDown(0))
		{
			if (!mouseOverGUI && Physics.Raycast(ray, out hit, 50, 1 << LayerMask.NameToLayer("Unit")))
			{
				if (hit.transform.GetComponent<Pawn>() != null)
				{
					selection = hit.transform.gameObject;
					selection.GetComponent<CapsuleCollider>().enabled = false;
				}
			}
		}
		if (Input.GetMouseButton(0))
		{
			if (!mouseOverGUI && Physics.Raycast(ray, out hit, 50, 1 << LayerMask.NameToLayer("Tile")) && selection != null)
			{
				selection.transform.position = hit.point;
				lastTileWorldLoc = hit.transform.position;
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			//if (!mouseOverGUI && Physics.Raycast(ray, out hit, 50, 1 << LayerMask.NameToLayer("Tile")) && selection != null)
			//{
				selection.GetComponent<CapsuleCollider>().enabled = true;
				selection.transform.position = lastTileWorldLoc;
				selection = null;
			//}
		}
		
	}
}
