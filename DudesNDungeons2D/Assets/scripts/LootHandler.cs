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
		
		if(lootChance <= 75) //we give the player 75% chance of getting loot from the enemy
		{
			int h = 0;
			bool hasLooted = false;
			foreach (Body l in GetComponent<GearHandler>().Backpack)
			{
				if(l == null && !hasLooted)
				{
					GetComponent<GearHandler>().Backpack[h] = lootedBody;
					hasLooted = true;
				}
				h++;
			}
			if(hasLooted == true)
				Debug.Log ("Loot");
			else if(!hasLooted && lootChance > 75)
				Debug.Log ("backpack full");
		}
		else
		{
			Debug.Log ("Burn Body");
		}
	}
}
