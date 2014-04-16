using UnityEngine;
using System.Collections;

public class FollowPlayerAI : MonoBehaviour {

	//Variables for the enemy detecting the player
	Transform playerFound;
	Transform enemyLocation;
	float aiSpeed = 0.05f;
	
	// Use this for initialization
	void Start () {
		playerFound = GameObject.FindGameObjectWithTag("Player").transform;
		enemyLocation = GameObject.FindGameObjectWithTag ("EnemyLocation").transform;
	}
	
	// Update is called once per frame
	void Update () {
		enemyAI();
	}

	void enemyAI(){
		if(Vector3.Distance(transform.position, playerFound.position) <= 5.0f && Vector3.Distance(transform.position, playerFound.position) >= 1.5f){
			enemyAIFollow();
		}

		if(Vector3.Distance(transform.position, playerFound.position) == 1.5f){
			enemyAIAttack();
		}
	}

	void enemyAIFollow(){
		transform.position += new Vector3(-aiSpeed, 0, 0);
	}

	void enemyAIAttack(){
		
	}
}
