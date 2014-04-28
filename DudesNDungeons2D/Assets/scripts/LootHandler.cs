using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootHandler : MonoBehaviour {
	
	public Body lootedBody = new Body();
	public GameObject camFound;

	int lootChance = 0;
	int potionChance = 0;
	public bool hasLooted = false;

	// Use this for initialization
	void Start () {
		camFound = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {

	}
	public void lootBody(GameObject enemyDeadBody)
	{
		lootChance = Random.Range(0, 101); //gives a random number from 0-100
		potionChance = Random.Range(0, 101); //gives a random number from 0-100

		
		lootedBody = enemyDeadBody.GetComponent<Enemy>().eCurrBody;
		
		if(lootChance <= 50) //we give the player 50% chance of getting loot from the enemy
		{
			int h = 0;

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

		if(potionChance <= 25)
		{
			Debug.Log("Yay, potion");
			camFound.GetComponent<GuiTest>().potionAmount++;
		}
		else
		{
			Debug.Log ("Damn, no potion");
		}
	}
}
