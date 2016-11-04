using UnityEngine;
using System.Collections;

namespace Math
{
	public static class GridCalc
	{
		public static float hexRadius = 1 / Mathf.Sqrt(3);
		public static float hexHeight = 1;

		//Finds distance in number of hexes between the hex at grid location fromLoc and the hex at toLoc
		public static int FindDistance(Vector3 fromLoc, Vector3 toLoc)
		{
			int tempFromZ = (int)(0 - (fromLoc.x + fromLoc.z));
			int tempToZ = (int)(0 - (toLoc.x + toLoc.z));
			int distance = (int)(Mathf.Abs(fromLoc.x - toLoc.x) + Mathf.Abs(fromLoc.z - toLoc.z) + Mathf.Abs(tempFromZ - tempToZ)) / 2;
			return distance;
		}

		//Takes grid location and converts it to world location
		public static Vector3 GridToWorld(Vector3 gridLoc)
		{
			int tempZ = (int)(0 - (gridLoc.x + gridLoc.z));
			Vector3 worldPos = new Vector3(0.5f * (gridLoc.z - tempZ) * Mathf.Sqrt(3) * hexRadius, gridLoc.y * hexHeight, 1.5f * gridLoc.x * hexRadius);
			return worldPos;
		}

		//Takes world location and converts it to grid location
		public static Vector3 WorldToGrid(Vector3 worldLoc)
		{
			Vector3 gridLoc;
			gridLoc.x = Mathf.Round(worldLoc.z / (hexRadius * 1.5f));
			gridLoc.y = Mathf.Round(worldLoc.y / hexHeight);
			gridLoc.z = Mathf.Round(worldLoc.x - (gridLoc.x / 2));

			return gridLoc;
		}

		//Fixes moveDir
		public static int MoveDirFix(int moveDir)
		{
			while (moveDir > 5)
			{
				moveDir -= 6;
			}

			while (moveDir < 0)
			{
				moveDir += 6;
			}
			return moveDir;
		}

		//Returns the grid location of the hex adjacent to the one at gridLoc in direction moveDir
		public static Vector3 MoveTo(Vector3 gridLoc, int moveDir)
		{
			moveDir = MoveDirFix(moveDir);
			Vector3 moveTo = gridLoc;
			if (moveDir == 0)
			{
				moveTo.x++;
				moveTo.z--;
			}
			if (moveDir == 1)
			{
				moveTo.x++;
			}
			if (moveDir == 2)
			{
				moveTo.z++;
			}
			if (moveDir == 3)
			{
				moveTo.x--;
				moveTo.z++;
			}
			if (moveDir == 4)
			{
				moveTo.x--;
			}
			if (moveDir == 5)
			{
				moveTo.z--;
			}
			return moveTo;
		}

		public static int GridToIndex(Vector3 gridLoc)
		{
			int index = Mathf.RoundToInt((gridLoc.x * 1000000) + (gridLoc.y * 1000) + gridLoc.z);

			Debug.Log(gridLoc + " " + index);
			return index;
		}

		public static Vector3 IndexToGrid(int index)
		{
			Vector3 gridLoc;
			gridLoc.x = Mathf.RoundToInt(index / 1000000f);
			gridLoc.y = Mathf.RoundToInt((index - gridLoc.x) / 1000f);
			gridLoc.z = Mathf.RoundToInt((index - (gridLoc.x + gridLoc.y)));
			return gridLoc;


			return gridLoc;
		}
	}
}
