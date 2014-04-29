using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShadowPartner : MonoBehaviour {

	public bool spAttackBool;
	public bool spCanAttack = true;
	public bool spLeftAttackBool;
	GameObject[] fEnemy;
	GameObject player;
	GameObject shadeling;
	public float spDistance;
	float spSpeed = 0.04f;
	public bool followingL = false;
	public bool followingR = false;
	public bool hasTarget;
	int attackCount;
	int attackCap;
	float sAttackSpeed = 0.5f;

	// Use this for initialization
	void Start () {
		hasTarget = false;
		fEnemy = GameObject.FindGameObjectsWithTag("Enemy");
		player = GameObject.FindGameObjectWithTag("Player");
		shadeling = GameObject.FindGameObjectWithTag("Shadeling");

		attackCount = 1;
		attackCap = 2;
	}
	
	// Update is called once per frame
	public int sq = 0;
	void Update () {
		shadowPartnerAI();

		if(sq >=29)
			sq = 0;
		sq++;
	}

	void shadowPartnerAI()
	{
		foreach(GameObject e in fEnemy)
		{
			if(e != null)
			{
				spDistance = Vector3.Distance (transform.position, e.transform.position);
				if(spDistance <= 3.0f && spDistance >= 0.5f)
				{
					hasTarget = true;
					shadowPartnerAIFollow(e);
					if(hasTarget == true && spDistance <=0.6f)
					{
						shadowPartnerAIAttack(e);
						StartCoroutine ("shadelingTimer");
						spFighting();
					}
				}
			}
			if(!hasTarget)
			{
				Debug.Log("has no target "+spDistance);
				StartCoroutine ("shadelingTimer");
			}
		}
	}
	void shadowPartnerAIFollow(GameObject e)
	{
		if(e != null)
		{
			if(e.transform.position.x < transform.position.x)  //these two if-statements are to see if the player is either on one site or the other
			{	
				transform.position += new Vector3(-spSpeed, 0, 0);//and the enemy has to move in that direction - left
				spWalking();
				spLeftAttackBool = true;
				followingL = true;
				followingR = false;
			}
			else if(e.transform.position.x > transform.position.x)
			{
				transform.position += new Vector3(spSpeed, 0, 0); //right
				spWalking();
				spLeftAttackBool = false;
				followingR = true;
				followingL = false;
			}
		}
		else
		{
			hasTarget = false;
		}
	}
	void shadowPartnerAIAttack(GameObject e)
	{
		spCanAttack = false;

		if(player.GetComponent<AbilHandler>().sSLevel == 1)
		{
			attackCap = 1;
			if(attackCount <= attackCap)
			{
				Debug.Log ("Shadowling dealing dmg");
				e.GetComponent<Enemy>().eHp -= (int)(player.GetComponent<player>().pDamage*0.5);
				attackCount++;
			}
		}
		if(player.GetComponent<AbilHandler>().sSLevel == 3)
		{
			attackCap = 1;
			if(attackCount <= attackCap)
			{
				e.GetComponent<Enemy>().eHp -= (int)(player.GetComponent<player>().pDamage*0.6);
				attackCount++;
			}
		}
		if(player.GetComponent<AbilHandler>().sSLevel == 5)
		{
			attackCap = 2;
			if(attackCount <= attackCap)
			{
				e.GetComponent<Enemy>().eHp -= (int)(player.GetComponent<player>().pDamage*0.6);
				attackCount++;
			}
		}
	}
	IEnumerator shadelingTimer()
	{
		yield return new WaitForSeconds(sAttackSpeed);
		Destroy(shadeling);

	}
	void spWalking()
	{
		if(followingR == true)
			GetComponent<SpriteRenderer>().sprite = player.GetComponent<AnimHandler>().sneakyList[sq];
		if(followingR == false)
			GetComponent<SpriteRenderer>().sprite = player.GetComponent<AnimHandler>().sneakyListR[sq];
	}
	void spFighting()
	{
		if(spLeftAttackBool == true)
		{
			//Attack to the left animations for the specific body
			GetComponent<SpriteRenderer>().sprite = player.GetComponent<AnimHandler>().sneakyAtkListR[sq];

		}
		if(spLeftAttackBool == false)
		{
			//Attack to the right animations for the specific body
			GetComponent<SpriteRenderer>().sprite = player.GetComponent<AnimHandler>().sneakyAtkList[sq];
		}
	}
}
