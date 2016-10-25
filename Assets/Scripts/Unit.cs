using UnityEngine;
using System.Collections;
using System.Collections.Generic;
[System.Serializable]
public class Unit
{
	public string name;
	public int level;
	public unitClass myClass;
	public element myElement;

	public enum unitClass
	{
		BaseMelee,
		BaseRanged,
		Count
	}
	public enum element
	{
		Water,
		Fire,
		Electric,
		Count
	}
}
