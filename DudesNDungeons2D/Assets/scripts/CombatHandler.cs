﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatHandler : MonoBehaviour {

	//List<Body> enemyList;

	GameObject[] enemies;
	public GameObject shadeling;
	GameObject player;
	GameObject eToAttack = null;
	public Transform death;
	public bool canAttack;
	public bool missedEnemy;
	public float attackSpeed = 1.0f;
	public int attackCount;
	public int attackHitCap;
	public int enemyDodgeProcent;
	public int hitChance;

	// Use this for initialization
	void Start () 
	{
		attackHitCap = 0;
		attackCount = 0;
		canAttack = true;
		missedEnemy = false;
		player = GameObject.FindGameObjectWithTag("Player");
		hitChance = Random.Range(0, 101);
	}
	
	// Update is called once per frame
	void Update () 
	{
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		Debug.Log ("hitChance = " + hitChance + " Enemydodgeprocent = " + enemyDodgeProcent + " missedEnemy = " + missedEnemy);
		if(enemies.Length > 0)
			foreach(GameObject e in enemies)
			{
				enemyDodgeProcent = e.GetComponent<Enemy>().eDex;
				if(e.GetComponent<Enemy>().eHp <= 0)
				{
					player.GetComponent<LootHandler>().lootBody(e);
					Instantiate (death, new Vector3(e.transform.position.x,e.transform.position.y,e.transform.position.z-1), Quaternion.identity);
					Destroy (e);
				}
			}


		if(Input.GetMouseButtonDown(0) && canAttack == true)
		{
			if(player.GetComponent<AbilHandler>().canUseAbilities && !player.GetComponent<AbilHandler>().canShadowStab)
			{
				if(attackCount <= attackHitCap)
					attackCount++;
				else
				{
					float displacement;
					if(player.GetComponent<player>().left)
						displacement = -1.0f;
					else
						displacement = 1.0f;
					Instantiate(shadeling, new Vector3((player.transform.position.x+displacement),player.transform.position.y,player.transform.position.z), Quaternion.identity);
					attackCount = 0;
				}
			}
			if(player.GetComponent<AbilHandler>().canUseAbilities)
			{
				canAttack = false;
				player.GetComponent<AnimHandler>().attackBool = true;
				player.GetComponent<AnimHandler>().q = 0;
				StartCoroutine("attackCooldown");
				if(enemies.Length > 0)
				{

					float lastDistance = 0.6f;
					float currDistance = 1;
					foreach(GameObject e in enemies)
					{
						currDistance = Vector3.Distance (e.transform.position, player.transform.position);
						if(lastDistance > currDistance)
						{
							lastDistance = currDistance;
							eToAttack = e;
							Debug.Log ("Enemy HP in foreach: "+e.GetComponent<Enemy>().eHp+"name: "+eToAttack.GetComponent<Enemy>().eCurrBody.name);
						}

					}
					if(lastDistance != 0.6f)
						playerAttack(eToAttack);
				}
			}

		}

	}
	void playerAttack(GameObject eToAttack)
	{
		//iniate Attack Animation.
		if(hitChance > enemyDodgeProcent){
			missedEnemy = false;
			Debug.Log ("Enemy not Missed");
		}
		else if(hitChance < enemyDodgeProcent)
		{
			missedEnemy = true;
			Debug.Log ("Enemy Missed");
		}

		if(!missedEnemy)
			eToAttack.GetComponent<Enemy>().eHp -= player.GetComponent<player>().pDamage;
		else
		{
			Debug.Log ("Enemy Missed");
		}
	}
	public IEnumerator attackCooldown()
	{
		yield return new WaitForSeconds(attackSpeed);
		canAttack = true;
		player.GetComponent<AnimHandler>().isGroundSlam = false;
		hitChance = Random.Range(0, 101);
		Debug.Log("Im here");
		StopCoroutine ("attackCooldown");
	}
}
