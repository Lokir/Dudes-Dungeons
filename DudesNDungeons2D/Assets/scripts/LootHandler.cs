using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootHandler : MonoBehaviour {
	
	public Body lootedBody = new Body();

	int lootChance = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}
	public void lootBody(GameObject enemyDeadBody)
	{
		lootChance = Random.Range(0, 101); //gives a random number from 0-100
		
		lootedBody = enemyDeadBody.GetComponent<Enemy>().eCurrBody;
		
		if(lootChance <= 75 && GetComponent<GearHandler>().Backpack.Count < 6) //we give the player 75% chance of getting loot from the enemy
		{
			GetComponent<GearHandler>().Backpack.Add(lootedBody);
			Debug.Log ("Loot");
		}
		else
		{
			Debug.Log ("Burn Body");
		}
	}
}
