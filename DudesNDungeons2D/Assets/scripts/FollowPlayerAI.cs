using UnityEngine;
using System.Collections;

public class FollowPlayerAI : MonoBehaviour 
{
	//Variables for the enemy detecting the player
	Transform fPlayer;
	Vector3 ePosition;
	float eDistance;
	float eSpeed = 0.05f;
	
	// Use this for initialization
	void Start () 
	{
		fPlayer = GameObject.FindGameObjectWithTag("Player").transform; //locates an object with the tag Player
		ePosition = transform.position; //saves the position of the object this script is attached to
	}
	// Update is called once per frame
	void Update () 
	{
		eDistance = Vector3.Distance(transform.position, fPlayer.position); //This is the distance between the player and the enemy, it currently
																			//isn't looking for any specific distance
		enemyAI();
	}
	void enemyAI(){
		if(eDistance <= 10 && eDistance >= 1.5f) //here we use the eDistance to make the enemy follow the player if he is within a certain range
												 //and stop if he comes to close to the player
		{
			enemyAIFollow();
		}
		else if(eDistance <= 1.5f) //If the enemy is close to the player he will call the attack function
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
			transform.position += new Vector3(-eSpeed, 0, 0);//and the enemy has to move in that direction

		else if(fPlayer.position.x > transform.position.x)
			transform.position += new Vector3(eSpeed, 0, 0);
	}
	void enemyAIAttack()
	{
		Debug.Log ("ATTACK!");
	}
	void returnToStart()
	{
		if(transform.position.x < ePosition.x)//if the enemy cannot see the player and is not at his origin he will return to his origin
			transform.position += new Vector3(eSpeed, 0, 0);

		else if(transform.position.x > ePosition.x)
			transform.position += new Vector3(-eSpeed, 0, 0);
	}
}
