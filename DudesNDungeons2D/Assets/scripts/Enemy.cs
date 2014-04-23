using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int eHp, eInte, eDex, eStr, eDamage = 0; //current player stats
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
	public bool loadEGear = false; // if this is true then we load the gear.
	void Update () 
	{
		if(loadEGear == true)// load gear.
		{
			int randG, randStr, randDex, randInt;

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
				randG = Random.Range (0,100);
				randStr = Random.Range (0, 11);
				randDex = Random.Range (0, 11);
				randInt = Random.Range (0, 11);
				if(randG <= 49)
				{
					eInte += randInt;
					eStr += randStr;
					eDex+= randDex;
				}
				if(randG >= 50) 
				{
					eInte -= randInt;
					eStr -= randStr;
					eDex -= randDex;
				}
			}
			Debug.Log (eCurrBody.name);
			Debug.Log ("Int "+eInte+" Str "+eStr+" Dex "+eDex);

		}
		if(buildEnemy == true)
		{
			enemyRandomizer();
			buildEnemy = false;
		}

	}
	void enemyRandomizer()
	{
		int randB, q = 0;
		randB = Random.Range(0,100);

		if(randB >= 0 && randB <= 24)
		{
			q = 0;
		}
		else if(randB >= 25 && randB <= 49)
		{
			q = 1;
		}
		else if(randB >= 50 && randB <= 74)
		{
			q = 2;
		}
		else
		{
			q = 3;
		}
		eCurrBody = gear.GetComponent<GearHandler>().Bodies[q];
		loadEGear = true;
		Debug.Log ("Before Int "+ eInte+" Str "+eStr+" Dex "+eDex);
	}
}
