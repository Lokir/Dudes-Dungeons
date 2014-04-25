using UnityEngine;
using System.Collections;

public class FollowPlayerAI : MonoBehaviour 
{
	bool eAttackBool;
	bool eLeftAttackBool;
	//Variables for the enemy detecting the player
	Transform fPlayer;
	Vector3 ePosition;
	float eDistance;
	float eSpeed = 0.04f;
	bool followingL = false;
	bool followingR = false;
	bool eCanAttack = true;
	float eAttackSpeed = 0.9f;
	
	// Use this for initialization
	void Start () 
	{
		fPlayer = GameObject.FindGameObjectWithTag("Player").transform; //locates an object with the tag Player
		ePosition = transform.position; //saves the position of the object this script is attached to
	}
	// Update is called once per frame
	int q = 0;
	void Update () 
	{
		if(eAttackBool)
			fighting();

		eDistance = Vector3.Distance(transform.position, fPlayer.position); //This is the distance between the player and the enemy, it currently
																			//isn't looking for any specific distance
		enemyAI();
		if(q >=29)
			q = 0;
		q++;
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
		}
	}
	void enemyAIFollow()
	{
		if(fPlayer.position.x < transform.position.x) //these two if-statements are to see if the player is either on one site or the other
		{	transform.position += new Vector3(-eSpeed, 0, 0);//and the enemy has to move in that direction - left
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
	void enemyAIAttack()
	{
		if(eCanAttack == true)
		{

			eCanAttack = false;
			eAttackBool = true;
			fPlayer.GetComponent<AnimHandler>().q = 0;
			fPlayer.GetComponent<player>().pHp -= GetComponent<Enemy>().eCurrBody.gDamage;
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
		Debug.Log("Enemy attack");
		StopCoroutine ("eAttackCooldown");
	}
	void returnToStart()
	{
		if(transform.position.x < ePosition.x)//if the enemy cannot see the player and is not at his origin he will return to his origin
		{
			transform.position += new Vector3(eSpeed, 0, 0);
			walking();
			followingL = false; 
			followingR = true; //because it has to go right to get back
		}

		else if(transform.position.x > ePosition.x)
		{
			transform.position += new Vector3(-eSpeed, 0, 0);
			walking();
			followingR = false; 
			followingL = true; //because it has to go left to get back
		}
	}
	void walking()
	{

		if(GetComponent<Enemy>().eCurrBody.name == "Default" && followingR == true)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().defList[q];
		if(GetComponent<Enemy>().eCurrBody.name == "Default" && followingR == false)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().defListR[q];

		if(GetComponent<Enemy>().eCurrBody.name == "Brute" && followingR == true)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().bruteList[q];
		if(GetComponent<Enemy>().eCurrBody.name == "Brute" && followingR == false)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().bruteListR[q];

		if(GetComponent<Enemy>().eCurrBody.name == "Sneaky" && followingR == true)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().sneakyList[q];
		if(GetComponent<Enemy>().eCurrBody.name == "Sneaky" && followingR == false)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().sneakyListR[q];

		if(GetComponent<Enemy>().eCurrBody.name == "Magus" && followingR == true)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().mageList[q];
		if(GetComponent<Enemy>().eCurrBody.name == "Magus" && followingR == false)
			GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().mageListR[q];
	}
	void fighting()
	{
		if(eLeftAttackBool == true)
		{
			//Attack to the left animations for the specific body
			if(GetComponent<Enemy>().eCurrBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().defAtkListR[q];
			
			if(GetComponent<Enemy>().eCurrBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().bruteAtkListR[q];
			
			if(GetComponent<Enemy>().eCurrBody.name == "Sneaky")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().sneakyAtkListR[q];
			
			if(GetComponent<Enemy>().eCurrBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().mageAtkListR[q];
		}
		if(eLeftAttackBool == false)
		{
			int q = fPlayer.GetComponent<AnimHandler>().q;
			//Attack to the right animations for the specific body
			if(GetComponent<Enemy>().eCurrBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().defAtkList[q];
			
			if(GetComponent<Enemy>().eCurrBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().bruteAtkList[q];
			
			if(GetComponent<Enemy>().eCurrBody.name == "Sneaky")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().sneakyAtkList[q];
			
			if(GetComponent<Enemy>().eCurrBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = fPlayer.GetComponent<AnimHandler>().mageAtkList[q];
		}
	}
}
