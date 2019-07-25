using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Unit
{
	public int myArmy;
	public int mySquad;
	public string myName;
	public ClassTitle title;
	public int squadPos;
	public List<Vector2Int> classLevels = new List<Vector2Int>();
	public List<float> stats = new List<float>();
	public List<Wound> wounds = new List<Wound>();
	public Vector2 hp;
	public Vector2 fp;
	public Vector2 rp;
	public Vector2 ap;
	public float init;
	public float ath;
	public float dodge;
	public float block;
	public float attack;

	public float weaponRange;
	public float attackCost;

	public void CalcStats()
	{
		stats = new List<float> { 0, 0, 0, 0, 0, 0 };
		for (int i = 0; i < 30; i++)
		{
			stats[Random.Range(0, 6)]++;
		}
		hp = Vector2.one * (stats[(int)Stats.BRN] * 0.75f + stats[(int)Stats.END] * 0.25f);
		fp = Vector2.one * (stats[(int)Stats.BRN] * 0.25f + stats[(int)Stats.END] * 0.5f + stats[(int)Stats.DEX] * 0.25f);
		rp = Vector2.one * (stats[(int)Stats.WIT] * 0.75f + stats[(int)Stats.END] * 0.25f);
		ap = Vector2.one * (stats[(int)Stats.DEX] * 0.75f + stats[(int)Stats.BRN] * 0.25f);
		init = stats[(int)Stats.DEX] * 0.5f + stats[(int)Stats.AWR] * 0.5f;
		ath = stats[(int)Stats.DEX] * 0.5f + stats[(int)Stats.BRN] * 0.5f;
		dodge = stats[(int)Stats.DEX] * 0.5f + stats[(int)Stats.AWR] * 0.5f;
		block = stats[(int)Stats.BRN] * 0.5f + stats[(int)Stats.END] * 0.5f;
		attack = stats[(int)Stats.BRN];
	}
	public void ChangeStat(Stats s, float amt)
	{
		stats[(int)s] += amt;
	}
	public Dictionary<string, float> CalcCombatEffects()
	{
		Dictionary<string, float> effects = new Dictionary<string, float>();
		effects.Add("Attack", attack);
		if (dodge > block)
			effects.Add("Dodge", dodge);
		else
			effects.Add("Block", block);
		if (hp.x < hp.y * 0.25f)
			effects.Add("Blood Loss", -3);
		else if (hp.x < hp.y * 0.5f)
			effects.Add("Blood Loss", -2);
		else if (hp.x < hp.y * 0.75f)
			effects.Add("Blood Loss", -1);
		if (fp.x < fp.y * 0.25f)
			effects.Add("Fatigue", -3);
		else if (fp.x < fp.y * 0.5f)
			effects.Add("Fatigue", -2);
		else if (fp.x < fp.y * 0.75f)
			effects.Add("Fatigue", -1);
		if (rp.x < rp.y * 0.25f)
			effects.Add("Fear", -3);
		else if (rp.x < rp.y * 0.5f)
			effects.Add("Fear", -2);
		else if (rp.x < rp.y * 0.75f)
			effects.Add("Fear", -1);
		return effects;
	}

	public void CalcDamage()
	{
		foreach(Wound w in wounds)
		{
			if(w.type == InjuryType.Cut || w.type == InjuryType.Stab)
			{
				hp.x -= 0.01f * (w.severity + (0.1f *stats[(int)Stats.BRN]));
			}
		}
		if (hp.x <= 0)
			Die();
		if (fp.x <= 0)
			Faint();
		if (rp.x <= 0)
			Panic();
	}
	void Die()
	{
		Debug.Log("Die");
	}
	void Faint()
	{
		Debug.Log("Faint");
	}
	void Panic()
	{
		Debug.Log("Panic");
	}
}

public enum Stats { BRN, END, DEX, AWR, INT, WIT };
public enum ClassTitle { Fighter, Mage, Cook, Blacksmith, Count};

public enum BodyPart { Head, Chest, Gut, LArm, LForearm, LHand, LLeg, LUpperLeg, LLowerLeg, LFoot, RArm, RForearm, RHand, RLeg, RUpperLeg, RLowerLeg, RFoot, Count };

public enum InjuryType { Cut, Stab, Crush, Count}
[System.Serializable]
public class Wound
{
	public BodyPart part;
	public InjuryType type;
	public int severity;

	public Wound(BodyPart part, InjuryType type, int severity)
	{
		this.part = part;
		this.type = type;
		this.severity = severity;
	}
}
