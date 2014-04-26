using UnityEngine;
using System.Collections;

public class AbilHandler : MonoBehaviour 
{
	Vector3 mousePos;
	Vector3 wantedPos;
	float rageDuration = 20.0f; // adjust this for rage duration.
	float regenTimer = 1.0f;
	float timeStunned = 1.0f;
	float TPCD = 10.0f;

	float distanceToEnemy;
	Transform enemyFound;

	int HP;
	int Inte;
	int Str;
	int Dex;
	int HPCap;
	int Charge;
	int Damage;
	float Dodge;
	int regenerateLevel, rageLevel = 1, groundSlamLevel;
	float hpMultiply = 0, strMultiply = 0, dmgMultiply = 0, dodgeMultiply = 0;
	bool canRage;
	bool canTeleport;


	// Use this for initialization
	void Start () 
	{
		canRage = true;
		canTeleport = true;
		enemyFound = GameObject.FindGameObjectWithTag("Enemy").transform;
	}
	// Update is called once per frame
	void Update () 
	{
		distanceToEnemy = Vector3.Distance(transform.position, enemyFound.position);
		/*if(Input.GetMouseButtonDown(0) && canTeleport == true)
		{
			teleport ();
		}*/
		if(Input.GetMouseButtonDown (1) && canRage == true)
		{
			rage ();
		}
	}
	public void teleport()
	{
		mousePos = Input.mousePosition;
		wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 3.54f));
		transform.position = wantedPos;
		canTeleport = false;
		StartCoroutine("teleportCooldown");
	}

	//Brute abilities
	public void rage()
	{
		HP = GetComponent<player>().pHp;
		Inte = GetComponent<player>().pInte;
		Dex = GetComponent<player>().pDex;
		Str = GetComponent<player>().pStr;
		Charge = GetComponent<player>().pCharge;
		HPCap = GetComponent<player>().HPCap;
		Damage = GetComponent<player>().pDamage;
		Dodge = GetComponent<player>().dodge;
		Debug.Log ("First "+GetComponent<player>().pHp);


		if(rageLevel == 1)
		{
			hpMultiply = 0.03f;
			strMultiply = 0.05f;
			dmgMultiply = 0.07f;
			dodgeMultiply = 0.5f;
			GetComponent<player>().pHp += (int)(HP*hpMultiply);
			GetComponent<player>().pStr += (int)(Str*strMultiply);
			GetComponent<player>().HPCap = GetComponent<player>().pHp;
			GetComponent<player>().pDamage += (int)(Damage*dmgMultiply);
			GetComponent<player>().dodge -= (int)(Dodge*dodgeMultiply);
		}
		else if(rageLevel == 2)
		{
			hpMultiply = 0.06f;
			strMultiply = 0.12f;
			dmgMultiply = 0.16f;
			dodgeMultiply = 0.4f;
			GetComponent<player>().pHp += (int)(HP*hpMultiply);
			GetComponent<player>().pStr += (int)(Str*strMultiply);
			GetComponent<player>().HPCap = GetComponent<player>().pHp;
			GetComponent<player>().pDamage += (int)(Damage*dmgMultiply);
			GetComponent<player>().dodge -= (int)(Dodge*dodgeMultiply);
		}
		else if(rageLevel == 3)
		{
			hpMultiply = 0.09f;
			strMultiply = 0.15f;
			dmgMultiply = 0.21f;
			dodgeMultiply = 0.3f;
			GetComponent<player>().pHp += (int)(HP*hpMultiply);
			GetComponent<player>().pStr += (int)(Str*strMultiply);
			GetComponent<player>().HPCap = GetComponent<player>().pHp;
			GetComponent<player>().pDamage += (int)(Damage*dmgMultiply);
			GetComponent<player>().dodge -= (int)(Dodge*dodgeMultiply);
		}
		else if(rageLevel == 4)
		{
			hpMultiply = 0.12f;
			strMultiply = 0.18f;
			dmgMultiply = 0.25f;
			dodgeMultiply = 0.25f;
			GetComponent<player>().pHp += (int)(HP*hpMultiply);
			GetComponent<player>().pStr += (int)(Str*strMultiply);
			GetComponent<player>().HPCap = GetComponent<player>().pHp;
			GetComponent<player>().pDamage += (int)(Damage*dmgMultiply);
			GetComponent<player>().dodge -= (int)(Dodge*dodgeMultiply);
		}
		else if(rageLevel == 5)
		{
			hpMultiply = 0.15f;
			strMultiply = 0.20f;
			dmgMultiply = 0.3f;
			dodgeMultiply = 0.2f;
			GetComponent<player>().pHp += (int)(HP*hpMultiply);
			GetComponent<player>().pStr += (int)(Str*strMultiply);
			GetComponent<player>().HPCap = GetComponent<player>().pHp;
			GetComponent<player>().pDamage += (int)(Damage*dmgMultiply);
			GetComponent<player>().dodge -= (int)(Dodge*dodgeMultiply);
		}
		Debug.Log ("Second "+GetComponent<player>().pHp);

		canRage = false;
		StartCoroutine("rageDurationElapse");
		Debug.Log ("After Coroutine "+GetComponent<player>().pHp);
	}
	public void groundSlam()
	{
		if(distanceToEnemy >= 0.3f && distanceToEnemy <= 1.0f)
		{
			enemyFound.GetComponent<FollowPlayerAI>().isStunned = true;
			if(groundSlamLevel == 1)
			{
				enemyFound.GetComponent<Enemy>().eHp -= 15;
			}
			else if(groundSlamLevel == 2)
			{
				enemyFound.GetComponent<Enemy>().eHp -= 25;
			}
			else if(groundSlamLevel == 3)
			{
				enemyFound.GetComponent<Enemy>().eHp -= 35;
				timeStunned = 2.0f;
			}
			else if(groundSlamLevel == 4)
			{
				enemyFound.GetComponent<Enemy>().eHp -= 45;
			}
			else if(groundSlamLevel == 5)
			{
				enemyFound.GetComponent<Enemy>().eHp -= 55;
				timeStunned = 3.0f;
			}
			StartCoroutine("stunDuration");
		}
	}
	public void regenerate()
	{
		StopCoroutine("regenPerSecond");
		int regen = 0;
		if(regenerateLevel == 1)
		{
			regen = 1;
		}
		else if(regenerateLevel == 2)
		{
			regen = 2;
		}
		else if(regenerateLevel == 3)
		{
			regen = 4;
		}
		else if(regenerateLevel == 4)
		{
			regen = 8;
		}
		else if(regenerateLevel == 5)
		{
			regen = 16;
		}
		if(GetComponent<player>().pHp > GetComponent<player>().HPCap)
			GetComponent<player>().pHp = GetComponent<player>().HPCap;
		StartCoroutine("regenPerSecond", regen);
	}

	//Brute timers
	IEnumerator regenPerSecond(int regen)
	{
		while(true)
		{
			yield return new WaitForSeconds (regenTimer);
			GetComponent<player>().pHp += regen;
		}
	}
	IEnumerator stunDuration()
	{
			yield return new WaitForSeconds (timeStunned);
			enemyFound.GetComponent<FollowPlayerAI>().isStunned = false;
			StopCoroutine("stunDuration");
	}
	IEnumerator rageDurationElapse()
	{
			yield return new WaitForSeconds (rageDuration);
			GetComponent<player>().pHp -= (int)(HP*hpMultiply);
			GetComponent<player>().pStr -= (int)(Str*strMultiply);
			GetComponent<player>().HPCap = GetComponent<player>().pHp;
			GetComponent<player>().pDamage -= (int)(Damage*dmgMultiply);
			GetComponent<player>().dodge += (int)(Dodge*dodgeMultiply);
			Debug.Log ("in coroutine "+GetComponent<player>().pHp);
			canRage = true;
			StopCoroutine("rageDurationElapse");
	}

	//Sneaky timers
	IEnumerator teleportCooldown()
	{
		while(true)
		{
			yield return new WaitForSeconds (TPCD);
			canTeleport = true;
			StopCoroutine("teleportCooldown");
		}
	}
}
