using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSwitch : MonoBehaviour
{
    void Update()
    {
		if (Input.GetButtonDown("ToggleArmyScreen"))
		{
			if (!ArmyDisplay.Instance.gameObject.activeSelf)
			{
				WorldData.Instance.gameObject.SetActive(false);
				ArmyDisplay.Instance.gameObject.SetActive(true);
			}
			else
			{
				WorldData.Instance.gameObject.SetActive(true);
				ArmyDisplay.Instance.gameObject.SetActive(false);
			}
		}
    }
}
