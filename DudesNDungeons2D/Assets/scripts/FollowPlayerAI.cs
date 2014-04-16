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
		fPlayer = GameObject.FindGameObjectWithTag("Player").transform;
		ePosition = transform.position;
	}
	// Update is called once per frame
	void Update () 
	{
		eDistance = Vector3.Distance(transform.position, fPlayer.position);
		enemyAI();
	}
	void enemyAI(){
		if(eDistance <= 10 && eDistance >= 1.5f)
		{
			enemyAIFollow();
		}
		else if(eDistance <= 1.5f)
		{
			enemyAIAttack();
		}
		else // return to origin.
		{
			if(transform.position != ePosition)
			returnToStart ();
		}
	}
	void enemyAIFollow()
	{
		if(fPlayer.position.x < transform.position.x)
			transform.position += new Vector3(-eSpeed, 0, 0);

		else if(fPlayer.position.x > transform.position.x)
			transform.position += new Vector3(eSpeed, 0, 0);
	}
	void enemyAIAttack()
	{
		Debug.Log ("ATTACK!");
	}
	void returnToStart()
	{
		if(transform.position.x < ePosition.x)
			transform.position += new Vector3(eSpeed, 0, 0);

		else if(transform.position.x > ePosition.x)
			transform.position += new Vector3(-eSpeed, 0, 0);
	}
}
