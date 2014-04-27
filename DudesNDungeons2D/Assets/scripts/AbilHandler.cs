using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AbilHandler : MonoBehaviour 
{
	Vector3 mousePos;
	Vector3 wantedPos;
	float rageDuration = 20.0f; // adjust this for rage duration.
	float shadowStabTimer = 20.0f;
	float regenTimer = 1.0f;
	float timeStunned = 1.0f;
	float TPCD = 10.0f;
	float tpStunTime = 1.0f;
	float shieldDuraTimer = 15.0f;
	float flameThrowerAS = 0.8f;
	public bool canUseAbilities;
	float distanceToEnemy;
	GameObject[] enemyFound;
	GameObject flame;
	GameObject stabstab;

	int HP;
	int Str;
	int HPCap;
	int Charge;
	int Damage;
	float Dodge;

	float hpMultiply, strMultiply, dmgMultiply , dodgeMultiply = 0;
	bool canRage;
	bool canTeleport;
	bool canShadowStab;
	bool canPush;
	bool canShield;
	bool canThrowFlame;
	public int regenerateLevel, rageLevel, groundSlamLevel = 0;
	public int tpLevel, sSLevel, eAndASLevel;
	public int knockbackLevel, shieldLevel, flameThrowerLevel;
	
	// Use this for initialization
	void Start () 
	{

		canUseAbilities = true;
		//Brutes ability levels
		regenerateLevel = 1;
		rageLevel = 1;
		groundSlamLevel = 1;

		//Sneaky ability levels
		tpLevel = 1;
		sSLevel = 1;
		eAndASLevel = 1;

		//Mages ability levels
		knockbackLevel = 1;
		shieldLevel = 1;
		flameThrowerLevel = 1;

		hpMultiply= 0;
		strMultiply = 0;
		dmgMultiply = 0;
		dodgeMultiply = 0;

		canRage = true;
		canTeleport = true;
		canPush = true;
		canShield = true;

		flame = GameObject.FindGameObjectWithTag("Flame");
	}
	// Update is called once per frame
	void Update () 
	{
		enemyFound = GameObject.FindGameObjectsWithTag("Enemy");
		if(canUseAbilities)
		{
			if(Input.GetMouseButtonDown (1) && canRage == true)
			{
				//rage ();
				//groundSlam(groundSlamLevel);
				//teleport ();
				//knockback();
				//absorb();
				flameThrower();
			}
		}
	}

	//Mage abilites
	public void knockback()
	{
		float distanceToEnemy = 1;
		List<GameObject> enemyList = new List<GameObject>();
		mousePos = Input.mousePosition;
		wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 3.54f));

		foreach(GameObject e in enemyFound)
		{
			distanceToEnemy = Vector3.Distance(transform.position, e.transform.position);

			if(distanceToEnemy <= 2.0f)
			{
				enemyList.Add(e);
				if(transform.position.x > wantedPos.x && canPush == true) //left
				{
					if(knockbackLevel == 1)
					{
						e.rigidbody2D.AddForce(new Vector2(-20,0));
						e.GetComponent<Enemy>().eHp -= 6;
						Debug.Log (e.GetComponent<Enemy>().eHp);
					}
					else if(knockbackLevel == 2)
					{
						e.rigidbody2D.AddForce(new Vector2(-23,0));
						e.GetComponent<Enemy>().eHp -= 12;
					}
					else if(knockbackLevel == 3)
					{
						e.rigidbody2D.AddForce(new Vector2(-26,0));
						e.GetComponent<Enemy>().eHp -= 18;
					}
					else if(knockbackLevel == 4)
					{
						e.rigidbody2D.AddForce(new Vector2(-29,0));
						e.GetComponent<Enemy>().eHp -= 36;
					}
					else if(knockbackLevel == 5)
					{
						e.rigidbody2D.AddForce(new Vector2(-32,0));
						e.GetComponent<Enemy>().eHp -= 45;
					}
					canPush = false;
				}
				else if(transform.position.x < wantedPos.x && canPush == true) //right
				{
					if(knockbackLevel == 1)
					{
						e.rigidbody2D.AddForce(new Vector2(20,0));
						e.GetComponent<Enemy>().eHp -= 3;
					}
					else if(knockbackLevel == 2)
					{
						e.rigidbody2D.AddForce(new Vector2(23,0));
						e.GetComponent<Enemy>().eHp -= 6;
					}
					else if(knockbackLevel == 3)
					{
						e.rigidbody2D.AddForce(new Vector2(26,0));
						e.GetComponent<Enemy>().eHp -= 9;
					}
					else if(knockbackLevel == 4)
					{
						e.rigidbody2D.AddForce(new Vector2(29,0));
						e.GetComponent<Enemy>().eHp -= 12;
					}
					else if(knockbackLevel == 5)
					{
						e.rigidbody2D.AddForce(new Vector2(32,0));
						e.GetComponent<Enemy>().eHp -= 20;
					}
					canPush = false;
				}

			}
		}
		StartCoroutine("pushbackCD");
	}
	public void absorb()
	{
		List<GameObject> EnemyList = new List<GameObject>();
		if(canShield)
		{
			foreach(GameObject e in enemyFound)
			{
				Damage = e.GetComponent<Enemy>().eDamage;
				EnemyList.Add(e);
				if(shieldLevel == 1)
				{
					e.GetComponent<Enemy>().eDamage = e.GetComponent<Enemy>().eDamage - (int)(Damage*0.15);
					Debug.Log ("Shielded");
				}
				else if(shieldLevel == 2)
				{
					e.GetComponent<Enemy>().eDamage = e.GetComponent<Enemy>().eDamage - (int)(Damage*0.25);
				}
				else if(shieldLevel == 3)
				{
					e.GetComponent<Enemy>().eDamage = e.GetComponent<Enemy>().eDamage - (int)(Damage*0.35);
					Debug.Log ("Shielded");
				}
				else if(shieldLevel == 4)
				{
					e.GetComponent<Enemy>().eDamage = e.GetComponent<Enemy>().eDamage - (int)(Damage*0.45);	
				}
				else if(shieldLevel == 5)
				{
					e.GetComponent<Enemy>().eDamage = e.GetComponent<Enemy>().eDamage - (int)(Damage*0.60);
				}
				canShield = false;
			}
		}
		StartCoroutine("absorbDuration", EnemyList);
	}
	public void flameThrower()
	{

		flame.GetComponent<FlameAnim>().throwFire = true;
		StartCoroutine("flameThrowerAttack");
	}

	//Sneaky abilities
	public void teleport()
	{
		mousePos = Input.mousePosition;
		wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 3.54f));
		float distanceToEnemy = 1;
		int z = 0;

			if(canTeleport == true)
			{
				transform.position = wantedPos;
				List<GameObject> EnemyList = new List<GameObject>();

				foreach(GameObject e in enemyFound)
				{
					distanceToEnemy = Vector3.Distance(transform.position, e.transform.position);
					if(distanceToEnemy <= 1.5f)
					{
						EnemyList.Add(e);
						if(tpLevel == 1)
						{
							TPCD = 10;
						}
						else if(tpLevel == 2)
						{
							TPCD = 8;
						}
						else if(tpLevel == 3)
						{
							TPCD = 6;
							EnemyList[z].GetComponent<Enemy>().eHp -= 10;
							tpStunTime = 1;
							EnemyList[z].GetComponent<FollowPlayerAI>().isStunned = true;
						}
						else if(tpLevel == 4)
						{
							TPCD = 4;
							EnemyList[z].GetComponent<FollowPlayerAI>().isStunned = true;
							EnemyList[z].GetComponent<Enemy>().eHp -= 15;
						}
						else if(tpLevel == 5)
						{
							TPCD = 3;
							EnemyList[z].GetComponent<Enemy>().eHp -= 20;
							tpStunTime = 2;
							EnemyList[z].GetComponent<FollowPlayerAI>().isStunned = true;

						}
						z++;
					}
					
				}
			StartCoroutine("teleportStun", EnemyList);
		}
		canTeleport = false;
		StartCoroutine("teleportCooldown");
	}
	void shadowStab()
	{
		Damage = GetComponent<player>().pDamage + (int)(GetComponent<player>().pDamage*0.1);
		canShadowStab = false;
		stabstab.GetComponent<Stab>().stabStabStab = true;
		StartCoroutine("shadowStabDuration");
	}

	//Brute abilities
	public void rage()
	{
		HP = GetComponent<player>().pHp;
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
	public void groundSlam(int groundSlamLevel)
	{
		if(GetComponent<LootHandler>().camFound.GetComponent<CombatHandler>().canAttack == true)
		{
			GetComponent<AnimHandler>().isGroundSlam = true;
			GetComponent<LootHandler>().camFound.GetComponent<CombatHandler>().canAttack = false;
			GetComponent<LootHandler>().camFound.GetComponent<CombatHandler>().StartCoroutine ("attackCooldown");
			GetComponent<AnimHandler>().attackBool = true;
			GetComponent<AnimHandler>().q = 0;
		}
		if(enemyFound.Length > 0)
		{
			float distanceToEnemy = 1;
			List<GameObject> EnemiesList = new List<GameObject>();
			foreach(GameObject e in enemyFound)
			{
				distanceToEnemy = Vector3.Distance (e.transform.position, transform.position);
				if(distanceToEnemy >= 0.1f && distanceToEnemy <= 2.0f)
				{
					//Debug.Log ("Stun me please");
					Debug.Log ("Enemy HP: "+ e.GetComponent<Enemy>().eHp);
					EnemiesList.Add(e);
					e.GetComponent<FollowPlayerAI>().isStunned = true;
					int enemyHP = e.GetComponent<Enemy>().eHp;
					if(groundSlamLevel == 1)
					{
						e.GetComponent<Enemy>().eHp -= 5;
						if(enemyHP-15 > 0)
							StartCoroutine("stunDuration", EnemiesList);
					}
					else if(groundSlamLevel == 2)
					{
						e.GetComponent<Enemy>().eHp -= 10;
						if(enemyHP-25 > 0)
							StartCoroutine("stunDuration", EnemiesList);
					}
					else if(groundSlamLevel == 3)
					{
						e.GetComponent<Enemy>().eHp -= 15;
						timeStunned = 2.0f;
						if(enemyHP-35 > 0)
							StartCoroutine("stunDuration", EnemiesList);
					}
					else if(groundSlamLevel == 4)
					{
						e.GetComponent<Enemy>().eHp -= 20;
						if(enemyHP-45 > 0)
							StartCoroutine("stunDuration", EnemiesList);
					}
					else if(groundSlamLevel == 5)
					{
						e.GetComponent<Enemy>().eHp -= 25;
						timeStunned = 3.0f;
						if(enemyHP-55 > 0)
							StartCoroutine("stunDuration", EnemiesList);
					}

				}
			}
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

	IEnumerator stunDuration(List<GameObject> enemy)
	{
			yield return new WaitForSeconds (timeStunned);
		foreach(GameObject e in enemy)
		{
			if(e != null)
				e.GetComponent<FollowPlayerAI>().isStunned = false;
			GetComponent<AnimHandler>().isGroundSlam = false;
		}
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
	IEnumerator teleportStun(List<GameObject> enemy)
	{
		yield return new WaitForSeconds(tpStunTime);
		foreach (GameObject e in enemy)
		{
			if(e != null)
			{
				e.GetComponent<FollowPlayerAI>().isStunned = false;
				Debug.Log ("hej");
			}
		}
		StopCoroutine("teleportStun");
	}

	IEnumerator shadowStabDuration()
	{
		yield return new WaitForSeconds(shadowStabTimer);
		GetComponent<player>().pDamage = Damage;
		canShadowStab = true;
		stabstab.GetComponent<Stab>().stabStabStab = false;
		StopCoroutine("shadowStabDuration");
	}

	//Mage timers
	IEnumerator pushbackCD()
	{
		yield return new WaitForSeconds(GetComponent<LootHandler>().camFound.GetComponent<CombatHandler>().attackSpeed);
		canPush = true;
		StopCoroutine("pushbackCD");
	}
	IEnumerator absorbDuration(List<GameObject> enemy)
	{
		yield return new WaitForSeconds(shieldDuraTimer);
		canShield = true;
		foreach(GameObject e in enemy)
			e.GetComponent<Enemy>().eDamage = Damage;
		Debug.Log("Shield removed");
		StopCoroutine("absorbDuration");
	}
	IEnumerator flameThrowerAttack()
	{
		yield return new WaitForSeconds(flameThrowerAS);
		canThrowFlame = true;
		flame.GetComponent<FlameAnim>().throwFire = false;
		StopCoroutine("flameThrowerAttack");
	}

	void OnTriggerEnter(Collider other)
	{      
		if(other.gameObject.name == "Enemy" && canThrowFlame == true)
			// if another gameobject specified Enemy. Hits this object.
		{
				if(flameThrowerLevel == 1)
				{
					other.GetComponent<Enemy>().eHp -= 20;
					Debug.Log(other.GetComponent<Enemy>().eHp);
				}
				else if(flameThrowerLevel == 2)
				{
					other.GetComponent<Enemy>().eHp -= 30;
				}
				else if(flameThrowerLevel == 3)
				{
					other.GetComponent<Enemy>().eHp -= 35;
				}
				else if(flameThrowerLevel == 4)
				{
					other.GetComponent<Enemy>().eHp -= 40;
				}
				else if(flameThrowerLevel == 5)
				{
					other.GetComponent<Enemy>().eHp -= 50;
				}
				canThrowFlame = false;
		}
	}
}