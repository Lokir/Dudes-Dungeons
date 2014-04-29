using UnityEngine;
using System.Collections;

public class TutorialHandler : MonoBehaviour {

	//Every GameObject in the scene
	GameObject player;
	GameObject dmgShrine;
	GameObject healShrine;
	GameObject invulShrine;
	GameObject exploShrine;
	GameObject shopGO;
	GameObject firstEnemy;
	//the players distance to the different GameObjects
	float exploShrineDistance, dmgShrineDistance, invulShrineDistance, healShrineDistance, shopDistance, firstEnemyDistance;
	//If the player is in a certain range the value of these change
	public bool exploClose, dmgClose, healClose, invulClose, shopClose, enemyClose;

	// Use this for initialization
	void Start () {
		if(GetComponent<GuiTest>().inTutorial)
		{
			//Finding the GameObjects with a certain tag
			player = GameObject.FindGameObjectWithTag("Player");
			dmgShrine = GameObject.FindGameObjectWithTag("DmgShrine");
			healShrine = GameObject.FindGameObjectWithTag("HealShrine");
			invulShrine = GameObject.FindGameObjectWithTag("InvulShrine");
			exploShrine = GameObject.FindGameObjectWithTag("ExploShrine");
			shopGO = GameObject.FindGameObjectWithTag("Shop");
			firstEnemy = GameObject.FindGameObjectWithTag("TutorialEnemy");
			//starts by saying that every object is not close to the player
			exploClose = false;
			dmgClose = false;
			healClose = false;
			invulClose = false;
			shopClose = false;
			enemyClose = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		//checks if the player is in the tutorial scene
		if(GetComponent<GuiTest>().inTutorial)
		{
			//checks if there isn't any explosion shrines at all, if there is one, make the distance between the player and the shrine
			if(exploShrine != null)
				exploShrineDistance = Vector3.Distance(exploShrine.transform.position, player.transform.position);

			//checks if there isn't any damage shrines at all, if there is one, make the distance between the player and the shrine
			if(dmgShrine != null)
				dmgShrineDistance = Vector3.Distance(dmgShrine.transform.position, player.transform.position);

			//checks if there isn't any invulnerbility shrines at all, if there is one, make the distance between the player and the shrine
			if(invulShrine != null)
				invulShrineDistance = Vector3.Distance(invulShrine.transform.position, player.transform.position);

			//checks if there isn't any healing shrines at all, if there is one, make the distance between the player and the shrine
			if(healShrine != null)
				healShrineDistance = Vector3.Distance(healShrine.transform.position, player.transform.position);

			//checks if there isn't any shops at all, if there is one, make the distance between the player and the shrine
			if(shopGO != null)
				shopDistance = Vector3.Distance(shopGO.transform.position, player.transform.position);

			//checks if there isn't any enemies at all, if there is one, make the distance between the player and the shrine
			if(firstEnemy != null)
				firstEnemyDistance = Vector3.Distance(firstEnemy.transform.position, player.transform.position);

			//checks if the player is within a certain range and if there is a explosion shrine
			if(exploShrineDistance <= 0.5f && exploShrine != null)
			{
				exploClose = true; //this variable is used to display with a GUI box what the player should do in order to activate the shrine
			}
			else
			{
				exploClose = false;
			}
			//all the next if-statements are similar to the previous one

			if(healShrineDistance <= 0.5f && healShrine != null)
			{
				healClose = true;
			}
			else
			{
				healClose = false;
			}

			if(dmgShrineDistance <= 1.0f && dmgShrine != null)
			{
				dmgClose = true;
			}
			else
			{
				dmgClose = false;
			}

			if(invulShrineDistance <= 0.5f && invulShrine != null)
			{
				invulClose = true;
			}
			else
			{
				invulClose = false;
			}

			if(shopDistance <= 1.0f && shopGO != null)
			{
				shopClose = true;
			}
			else
			{
				shopClose = false;
			}

			if(firstEnemyDistance <= 0.5f && firstEnemy != null)
			{
				enemyClose = true;
			}
			else
			{
				enemyClose = false;
			}

			//If the escape button is pressed the player will be sent back to the main menu
			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Application.LoadLevel(0);
				GetComponent<GuiTest>().inTutorial = false;
			}
		}
	}
	
}
