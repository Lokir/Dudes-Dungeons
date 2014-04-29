using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LootHandler : MonoBehaviour {
	
	public Body lootedBody = new Body();
	public GameObject camFound;

	int lootChance = 0;
	int potionChance = 0;
	public bool hasLooted = false;
	float displayTime = 0.8f;
	public bool DisplayText;

	// Use this for initialization
	void Start () {
		DisplayText = false;
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

			foreach (Body l in GetComponent<GearHandler>().Backpack)//if a body is dropped the player gets it into his/her backpack
			{
				if(l == null && !hasLooted)
				{
					GetComponent<GearHandler>().Backpack[h] = lootedBody;
					hasLooted = true;
					DisplayText = true;
					StartCoroutine("displayLootText");
				}
				h++;
			}
		}

		if(potionChance <= 25)//adds another potion if it drops, it has 25% chance of dropping
		{
			camFound.GetComponent<GuiTest>().potionAmount++;
		}
	}
	IEnumerator displayLootText()//timer to show if you got a body in your backpack
	{
		yield return new WaitForSeconds(displayTime);
		DisplayText = false;
	}
}
