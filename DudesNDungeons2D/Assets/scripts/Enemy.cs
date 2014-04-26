using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int eHp, eInte, eDex, eStr, eDamage = 0; //current enemy stats
	public int HPCap; // HP max
	public bool eLeft; // moving left.
	public float dodge, crit;

	GameObject gear;
	bool buildEnemy = true;
	public Body eCurrBody = new Body(); // this body is the current body that we can load other bodies into.
	// Use this for initialization
	void Start () 
	{
		// default stat Values
		eHp = 30;
		eInte = 10;
		eDex = 10;
		eStr = 10;
		HPCap = eHp;
		eDamage = 0;

		// default Currbody Values.
		gear = GameObject.FindGameObjectWithTag("Player");

	}
	// Update is called once per frame
	public bool loadEGear = true; // if this is true then we load the gear.
	void Update () 
	{
		if(loadEGear == true)
		{
			enemyRandomizer();
			GetComponent<SpriteRenderer>().sprite = eCurrBody.skin;
			loadEGear = false;
		}
	}
	void enemyRandomizer()
	{
		int randB, k = 0;
		randB = Random.Range(0,100);

		if(randB >= 0 && randB <= 24)
		{
			k = 0;
		}
		else if(randB >= 25 && randB <= 49)
		{
			k = 1;
		}
		else if(randB >= 50 && randB <= 74)
		{
			k = 2;
		}
		else
		{
			k = 3;
		}
		eCurrBody = gear.GetComponent<GearHandler>().Bodies[k];

		int randStr, randDex, randInt;
		
		eHp = eCurrBody.gHp; // sHP is stat HP and gHP is Gear HP.
		eInte = eCurrBody.gInte;
		eDex = eCurrBody.gDex;
		eStr = eCurrBody.gStr;
		eDamage = eCurrBody.gDamage; // temporary system for calculating damage... Dam+ 30% of strength.
		HPCap = eCurrBody.gHp;
		loadEGear = false; // set to false so we don't continously load gear when it is unnecessary.
		
		dodge = (float)eDex;
		crit = (float)(eDex/2);
		eDamage += ((int)(eStr*0.33))+1;
		eHp += ((int)(eStr*0.2))+1;
		HPCap = eHp;
		
		if(eCurrBody.name != "Default")
		{
			randStr = Random.Range (-11, 11);
			randDex = Random.Range (-11, 11);
			randInt = Random.Range (-11, 11);
			
			eInte += randInt;
			eStr += randStr;
			eDex+= randDex;
		}
		Debug.Log (eCurrBody.name);
		Debug.Log ("Int "+eInte+" Str "+eStr+" Dex "+eDex);
		Debug.Log ("Before Int "+ eInte+" Str "+eStr+" Dex "+eDex+" "+ gear.GetComponent<GearHandler>().Bodies.Count + " " + k);
	}
}
