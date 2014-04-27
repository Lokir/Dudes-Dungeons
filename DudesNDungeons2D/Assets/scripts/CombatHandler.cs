using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatHandler : MonoBehaviour {

	//List<Body> enemyList;

	GameObject[] enemies;
	GameObject player;
	GameObject eToAttack = null;
	public Transform death;
	public bool canAttack;
	public float attackSpeed = 0.5f;
	public int attackCount = 0;
	public int attackHitCap = 5;

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

		if(enemies.Length > 0)
			foreach(GameObject e in enemies)
			{
				if(e.GetComponent<Enemy>().eHp <= 0)
				{
					player.GetComponent<LootHandler>().lootBody(e);
					Instantiate (death, new Vector3(e.transform.position.x,e.transform.position.y,e.transform.position.z-1), Quaternion.identity);
					Destroy (e);
				}
			}


		if(Input.GetMouseButtonDown(0) && canAttack == true)
		{
			if(attackCount < attackHitCap)
				attackCount++;
			else
				attackCount = 0;

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
	void playerAttack(GameObject eToAttack)
	{
		//iniate Attack Animation.
		eToAttack.GetComponent<Enemy>().eHp -= player.GetComponent<player>().pDamage;
		//Debug.Log ("Enemy HP in function: "+eToAttack.GetComponent<Enemy>().eHp+"name: "+eToAttack.GetComponent<Enemy>().eCurrBody.name);
	}
	public IEnumerator attackCooldown()
	{
		yield return new WaitForSeconds(attackSpeed);
		canAttack = true;
		player.GetComponent<AnimHandler>().isGroundSlam = false;

		Debug.Log("Im here");
		StopCoroutine ("attackCooldown");
	}
}
