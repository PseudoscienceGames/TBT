using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Screen : MonoBehaviour {

	public GameObject worldMode;
	public GameObject battleMode;
	public GameObject unitMode;

	public void WorldMode()
	{
		worldMode.SetActive(true);
		battleMode.SetActive(false);
		unitMode.SetActive(false);
	}

	public void BattleMode()
	{
		worldMode.SetActive(false);
		battleMode.SetActive(true);
		unitMode.SetActive(false);
	}

	public void UnitMode()
	{
		worldMode.SetActive(false);
		battleMode.SetActive(false);
		unitMode.SetActive(true);
	}
}
