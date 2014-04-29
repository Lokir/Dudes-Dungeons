using UnityEngine;
using System.Collections;

public class TutorialHandler : MonoBehaviour {

	GameObject player;
	GameObject dmgShrine;
	GameObject healShrine;
	GameObject invulShrine;
	GameObject exploShrine;
	GameObject shopGO;
	GameObject firstEnemy;
	float exploShrineDistance, dmgShrineDistance, invulShrineDistance, healShrineDistance, shopDistance, firstEnemyDistance;
	public bool exploClose, dmgClose, healClose, invulClose, shopClose, enemyClose;

	// Use this for initialization
	void Start () {
		if(GetComponent<GuiTest>().inTutorial)
		{
			player = GameObject.FindGameObjectWithTag("Player");
			dmgShrine = GameObject.FindGameObjectWithTag("DmgShrine");
			healShrine = GameObject.FindGameObjectWithTag("HealShrine");
			invulShrine = GameObject.FindGameObjectWithTag("InvulShrine");
			exploShrine = GameObject.FindGameObjectWithTag("ExploShrine");
			shopGO = GameObject.FindGameObjectWithTag("Shop");
			firstEnemy = GameObject.FindGameObjectWithTag("TutorialEnemy");
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
		if(GetComponent<GuiTest>().inTutorial)
		{
			if(exploShrine != null)
				exploShrineDistance = Vector3.Distance(exploShrine.transform.position, player.transform.position);

			dmgShrineDistance = Vector3.Distance(dmgShrine.transform.position, player.transform.position);
			invulShrineDistance = Vector3.Distance(invulShrine.transform.position, player.transform.position);
			healShrineDistance = Vector3.Distance(healShrine.transform.position, player.transform.position);
			shopDistance = Vector3.Distance(shopGO.transform.position, player.transform.position);

			if(firstEnemy != null)
				firstEnemyDistance = Vector3.Distance(firstEnemy.transform.position, player.transform.position);

			if(exploShrineDistance <= 0.5f && exploShrine != null)
			{
				exploClose = true;
			}
			else
			{
				exploClose = false;
			}

			if(healShrineDistance <= 0.5f && healShrine != null)
			{
				healClose = true;
			}
			else
			{
				healClose = false;
			}

			if(dmgShrineDistance <= 0.5f && dmgShrine != null)
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

			if(Input.GetKeyDown(KeyCode.Escape))
			{
				Application.LoadLevel(0);
			}
		}
	}
	
}
