using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatHandler : MonoBehaviour {

	//List<Body> enemyList;

	GameObject[] enemies;
	GameObject player;
	GameObject eToAttack;
	bool canAttack;
	float attackSpeed = 1.0f;

	// Use this for initialization
	void Start () 
	{
		canAttack = true;
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
		enemies = GameObject.FindGameObjectsWithTag("Enemy");

		if(enemies.Length > 0 && Input.GetMouseButtonDown(0) && canAttack == true)
		{
			player.GetComponent<AnimHandler>().attackBool = true;
			player.GetComponent<AnimHandler>().q = 0;
			canAttack = false;
			StartCoroutine("attackCooldown");
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



	void playerAttack(GameObject eToAttack)
	{
		//iniate Attack Animation.
		eToAttack.GetComponent<Enemy>().eHp -= player.GetComponent<player>().pDamage;
		if(player.transform.position.x > eToAttack.transform.position.x)
			player.GetComponent<AnimHandler>().leftAttackBool = true;
		else
			player.GetComponent<AnimHandler>().leftAttackBool = false;
		Debug.Log ("Enemy HP in function: "+eToAttack.GetComponent<Enemy>().eHp+"name: "+eToAttack.GetComponent<Enemy>().eCurrBody.name);
		eToAttack.GetComponent<Enemy>().eCurrBody.name = "Strudel";
		if(eToAttack.GetComponent<Enemy>().eHp <= 0)
			Destroy (eToAttack);
	}
	IEnumerator attackCooldown()
	{
		yield return new WaitForSeconds(attackSpeed);
		canAttack = true;
		StopCoroutine ("attackCooldown");
	}
}
