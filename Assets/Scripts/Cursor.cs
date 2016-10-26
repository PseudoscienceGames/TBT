using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour
{
	public GameObject selection;

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();


		if (Physics.Raycast(ray, out hit))
		{
			if (Input.GetMouseButtonDown(0))
			{
				if (hit.transform.GetComponent<Pawn>() != null)
					selection = hit.transform.gameObject;
			}
			if(Input.GetMouseButton(0))
			{
				selection.transform.position = hit.point;
			}
		}
	}
}
