using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Math;

public class HexGrid : MonoBehaviour
{
	public int mapRadius;

	public GameObject tile;

	public List<Vector3> gridLocs = new List<Vector3>();

	void Start()
	{
		MapGen();
	}

	void MapGen()
	{
		AddGridLoc(Vector3.zero);

		for (int fRadius = 1; fRadius <= mapRadius; fRadius++)
		{
			//Set initial hex grid location
			Vector3 gridLoc = new Vector3(fRadius, 0, -fRadius);

			int dir = 2;
			//Find data for each hex in the ring (each ring has 6 more hexes than the last)
			for (int fHex = 0; fHex < 6 * fRadius; fHex++)
			{
				//Finds next hex in ring
				gridLoc = GridCalc.MoveTo(gridLoc, dir);
				AddGridLoc(gridLoc);

				if (gridLoc.x == 0 || gridLoc.z == 0 || gridLoc.x == -gridLoc.z)
				{
					dir++;
				}
			}
		}
	}

	void AddGridLoc(Vector3 gridLoc)
	{
		gridLocs.Add(gridLoc);
		GameObject currentTile = Instantiate(tile, GridCalc.GridToWorld(gridLoc), Quaternion.identity) as GameObject;
		currentTile.transform.parent = transform;
	}
}
