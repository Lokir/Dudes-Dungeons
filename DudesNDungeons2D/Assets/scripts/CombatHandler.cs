using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatHandler : MonoBehaviour {

	//List<Body> enemyList;

	GameObject[] enemies;
	public GameObject shadeling;
	GameObject player;
	GameObject eToAttack = null;
	GameObject stabstab;
	public Transform death;
	public bool canAttack;
	public bool missedEnemy;
	public bool showMiss;
	public float attackSpeed = 1.0f;
	public int attackCount;
	public int attackHitCap;
	public int enemyDodgeProcent;
	public int hitChance;

	// Use this for initialization
	void Start () 
	{
		attackHitCap = 2;
		attackCount = 0;
		canAttack = true;
		missedEnemy = false;
		player = GameObject.FindGameObjectWithTag("Player");
		stabstab = GameObject.FindGameObjectWithTag("Stab");
		hitChance = Random.Range(0, 101);
	}
	
	// Update is called once per frame
	void Update () 
	{
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		//Debug.Log ("hitChance = " + hitChance + " Enemydodgeprocent = " + enemyDodgeProcent + " missedEnemy = " + missedEnemy);
		if(enemies.Length > 0)
			foreach(GameObject e in enemies)
			{
				enemyDodgeProcent = e.GetComponent<Enemy>().eDex;//Enemy dogdechance
				if(e.GetComponent<Enemy>().eHp <= 0)
				{
					player.GetComponent<LootHandler>().lootBody(e);
					Instantiate (death, new Vector3(e.transform.position.x,e.transform.position.y,e.transform.position.z-1), Quaternion.identity);
					Destroy (e);
				}
			}
		if(Input.GetMouseButtonDown(0) && canAttack == true && player.GetComponent<AbilHandler>().canUseAbilities)
		{
			if(!player.GetComponent<AbilHandler>().canShadowStab)
			{
				if(player.GetComponent<AbilHandler>().sSLevel == 1)
					attackHitCap = 2;//every 4th stab - for the shadowstab ability
				else if(player.GetComponent<AbilHandler>().sSLevel == 2)
					attackHitCap = 1;//every 3rd stab - for the shadowstab ability
				else if(player.GetComponent<AbilHandler>().sSLevel == 4)
					attackHitCap = 0;//every 2nd stab - for the shadowstab ability

					if(attackCount <= attackHitCap)//if the player has not hit the cap before spawning a shardling, then add one to the counter
						attackCount++;
					else
					{
					//a bit buggy at the moment since the ability it self wont work, but this should spawn a shardling that would come from behind
					//and stab the enemy in the back once or twice, depending on the level of the skill
						float displacement;
						if(player.GetComponent<player>().left)
							displacement = -1.0f;
						else
							displacement = 1.0f;
						Instantiate(shadeling, new Vector3((player.transform.position.x+displacement),player.transform.position.y,player.transform.position.z), Quaternion.identity);
						attackCount = 0;

					}
			}
				canAttack = false;
				player.GetComponent<AnimHandler>().attackBool = true;
				player.GetComponent<AnimHandler>().q = 0;
				StartCoroutine("attackCooldown");//do the attack animation for the player
				stabstab.GetComponent<Stab>().stabStabStab = true;
				if(enemies.Length > 0)
				{
					float lastDistance = 0.8f;
					float currDistance = 1;
					foreach(GameObject e in enemies)
					{
						currDistance = Vector3.Distance (e.transform.position, player.transform.position);//take the distace between the player and 
																										  //enemy
						if(lastDistance > currDistance)
						{
							lastDistance = currDistance;
							eToAttack = e;
						}

					}
					if(lastDistance != 0.8f)//if in this range, the attack function is called
						playerAttack(eToAttack);
				}
		}
	
	}
	void playerAttack(GameObject eToAttack)
	{
		//see if the player misses or not, if miss show that he/she missed in a certain amount of time
		if(hitChance > enemyDodgeProcent)
		{
			missedEnemy = false;
		}
		else if(hitChance < enemyDodgeProcent)
		{
			missedEnemy = true;
			showMiss = true;
			StartCoroutine("showMissText");
		}

		if(!missedEnemy)//if not missed take the damage of the player from the enemy's health and then the player gains 5 in charge, which he/she
						//can use for abilities
		{
			eToAttack.GetComponent<Enemy>().eHp -= player.GetComponent<player>().pDamage;
			if(player.GetComponent<player>().pCharge +5 <= player.GetComponent<player>().chargeCap)
			player.GetComponent<player>().pCharge +=5;
		}
	}
	public IEnumerator showMissText()
	{
		float textTime = 0.8f;
		yield return new WaitForSeconds(textTime);
		showMiss = false;
	}
	public IEnumerator attackCooldown()//attack cooldown such that the player cannot attack at all time and instantly kill the enemy
	{
		yield return new WaitForSeconds(attackSpeed);
		canAttack = true;
		player.GetComponent<AnimHandler>().isGroundSlam = false;
		stabstab.GetComponent<Stab>().stabStabStab = false;
		hitChance = Random.Range(0, 101);
		Debug.Log("Im here");
		StopCoroutine ("attackCooldown");
	}
}
