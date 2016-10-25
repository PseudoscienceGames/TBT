using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Math;

public class Squad : MonoBehaviour
{
	public Team myTeam;
	public List<int> units = new List<int>();
	public List<Vector3> spawnLocs = new List<Vector3>();

	public bool spawn;

	public GameObject pawnPrefab;

	void Update()
	{
		if(spawn)
		{
			SpawnUnits();
			spawn = false;
		}
	}

	public void SpawnUnits()
	{
		FindSpawnLocs();
		for(int i = 0; i < units.Count; i++)
		{
			GameObject currentPawn = Instantiate(pawnPrefab, GridCalc.GridToWorld(spawnLocs[i]), Quaternion.identity) as GameObject;
			currentPawn.transform.parent = transform;
			currentPawn.GetComponent<Pawn>().unit = myTeam.units[i];
		}
	}

	public void FindSpawnLocs()
	{
		for(int i = 0; i < units.Count; i++)
		{
			spawnLocs.Add(new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2)));
		}
	}
}
