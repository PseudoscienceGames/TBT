using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour
{
	public GameObject selection;

	//Check for mouse being over GUI
	public bool mouseOverGUI = false;
	public void MouseOverGUI() { mouseOverGUI = true; }
	public void MouseNotOverGUI() { mouseOverGUI = false; }

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();


		if (!mouseOverGUI && Physics.Raycast(ray, out hit))
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (hit.transform.GetComponent<Pawn>() != null)
				{
					selection = hit.transform.gameObject;
					selection.GetComponent<CapsuleCollider>().enabled = false;
				}
			}
			if(Input.GetMouseButton(0))
			{
				selection.transform.position = hit.point;
				selection.GetComponent<CapsuleCollider>().enabled = true;
			}
		}
	}
}
