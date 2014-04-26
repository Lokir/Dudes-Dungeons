using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FollowPlayerAI : MonoBehaviour 
{
	bool eAttackBool;
	bool eLeftAttackBool;
	//Variables for the enemy detecting the player
	Transform fPlayer;
	public Vector3 ePosition;
	public float eDistance;
	float eSpeed = 0.04f;
	public bool followingL = false;
	public bool followingR = false;
	public bool eCanAttack = true;
	float eAttackSpeed = 0.9f;
	public bool eCanFollow = true;
	
	// Use this for initialization
	void Start () 
	{
		fPlayer = GameObject.FindGameObjectWithTag("Player").transform; //locates an object with the tag Player
		ePosition = transform.position; //saves the position of the object this script is attached to
	}
	// Update is called once per frame
	public int eq = 0;
	void Update () 
	{
		if(eAttackBool)
			fighting();

		eDistance = Vector3.Distance(transform.position, fPlayer.position); //This is the distance between the player and the enemy, it currently
																			//isn't looking for any specific distance
		enemyAI();
		if(eq >=29)
			eq = 0;
		eq++;
	}
	void enemyAI(){
		if(eDistance <= 2 && eDistance >= 0.3f) //here we use the eDistance to make the enemy follow the player if he is within a certain range
												//and stop if he comes to close to the player
		{
			enemyAIFollow();
		}
		else if(eDistance <= 0.3f) //If the enemy is close to the player he will call the attack function
		{
			enemyAIAttack();
		}
		else // return to origin
		{
			if(transform.position != ePosition)
				returnToStart ();
			else
				standardSprite();
		}
	}
	void enemyAIFollow()
	{
		if(eCanFollow == true)
		{
			if(fPlayer.position.x < transform.position.x) 		 //these two if-statements are to see if the player is either on one site or the other
			{	
				transform.position += new Vector3(-eSpeed, 0, 0);//and the enemy has to move in that direction - left
				walking();
				eLeftAttackBool = true;
				followingL = true;
				followingR = false;
			}

			else if(fPlayer.position.x > transform.position.x)
			{
				transform.position += new Vector3(eSpeed, 0, 0); //right
				walking();
				eLeftAttackBool = false;
				followingR = true;
				followingL = false;
			}
		}
	}
	void enemyAIAttack()
	{
		if(eCanAttack == true)
		{
			eCanAttack = false;
			eAttackBool = true;
			if(!fPlayer.GetComponent<player>().invulnerable)
				fPlayer.GetComponent<player>().pHp -= GetComponent<Enemy>().eCurrBody.gDamage;
			Debug.Log ("Damage");
			StartCoroutine("eAttackCooldown");
		}

		if(fPlayer.GetComponent<player>().pHp <= 0)
		{
			fPlayer.gameObject.collider2D.enabled = false;
		}
	}
	IEnumerator eAttackCooldown()
	{
		yield return new WaitForSeconds(eAttackSpeed);
		eCanAttack = true;
		StopCoroutine ("eAttackCooldown");
	}
	void returnToStart()
	{
		if(transform.position.x < ePosition.x)//if the enemy cannot see the player and is not at his origin he will return to his origin
		{
			eCanAttack = true;
			transform.position += new Vector3(eSpeed, 0, 0);
			walking();
			followingL = false; 
			followingR = true; //because it has to go right to get back
			if(transform.position.x >= ePosition.x - 0.15f && transform.position.x <= ePosition.x - 0.01f)
			{
				transform.position = ePosition;
				standardSprite();
			}
		}

		else if(transform.position.x > ePosition.x)
		{
			transform.position += new Vector3(-eSpeed, 0, 0);
			walking();
			followingR = false; 
			followingL = true; //because it has to go left to get back
			if(transform.position.x >= ePosition.x + 0.01f && transform.position.x <= ePosition.x + 0.15f)
			{
				transform.position = ePosition;
				standardSprite();
			}

		}
	}
	void walking()
	{
		if(GetComponent<Enemy>().eCurrBody.name == "Default" && followingR == true)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().defList[eq];
		if(GetComponent<Enemy>().eCurrBody.name == "Default" && followingR == false)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().defListR[eq];

		if(GetComponent<Enemy>().eCurrBody.name == "Brute" && followingR == true)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().bruteList[eq];
		if(GetComponent<Enemy>().eCurrBody.name == "Brute" && followingR == false)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().bruteListR[eq];

		if(GetComponent<Enemy>().eCurrBody.name == "Sneaky" && followingR == true)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().sneakyList[eq];
		if(GetComponent<Enemy>().eCurrBody.name == "Sneaky" && followingR == false)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().sneakyListR[eq];

		if(GetComponent<Enemy>().eCurrBody.name == "Magus" && followingR == true)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().mageList[eq];
		if(GetComponent<Enemy>().eCurrBody.name == "Magus" && followingR == false)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().mageListR[eq];
	}
	void fighting()
	{
		if(eLeftAttackBool == true)
		{
			//Attack to the left animations for the specific body
			if(GetComponent<Enemy>().eCurrBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().defAtkListR[eq];
			
			if(GetComponent<Enemy>().eCurrBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().bruteAtkListR[eq];
			
			if(GetComponent<Enemy>().eCurrBody.name == "Sneaky")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().sneakyAtkListR[eq];
			
			if(GetComponent<Enemy>().eCurrBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().mageAtkListR[eq];
		}
		if(eLeftAttackBool == false)
		{
			//Attack to the right animations for the specific body
			if(GetComponent<Enemy>().eCurrBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().defAtkList[eq];
			
			if(GetComponent<Enemy>().eCurrBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().bruteAtkList[eq];
			
			if(GetComponent<Enemy>().eCurrBody.name == "Sneaky")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().sneakyAtkList[eq];
			
			if(GetComponent<Enemy>().eCurrBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().mageAtkList[eq];
		}
	}
	void standardSprite()
	{
		eAttackBool = false;
		if(GetComponent<Enemy>().eCurrBody.name == "Default")
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().walk1R;
		
		if(GetComponent<Enemy>().eCurrBody.name == "Brute")
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().bruteWalk1R;
		
		if(GetComponent<Enemy>().eCurrBody.name == "Sneaky")
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().sneakyWalk1R;
		
		if(GetComponent<Enemy>().eCurrBody.name == "Magus")
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().mageWalk1R;
	}
}
