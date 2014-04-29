using UnityEngine;
using System.Collections;

public class HPBarControl : MonoBehaviour {
	GameObject Player;
	float startingSize;
	float scaleY;
	float scaleZ;
	float minSize;
	// Use this for initialization
	void Start () {

		Player = GameObject.FindGameObjectWithTag("Player"); // find player to get coordinates and health.
		startingSize = transform.localScale.x; // get starting size X
		scaleY = transform.localScale.y; // Y
		scaleZ = transform.localScale.z; // Z
		minSize = startingSize/10; // Set the minimum size... This is based on %  10 different sizes one for each 10% uptill 100%

	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(Player.GetComponent<player>().pHp == Player.GetComponent<player>().HPCap) // if player at 100% size 100%
		{
			transform.localScale = new Vector3((minSize*10), scaleY, scaleZ);
		}
		
		if(Player.GetComponent<player>().pHp <= Player.GetComponent<player>().HPCap*0.9 && Player.GetComponent<player>().pHp >= Player.GetComponent<player>().HPCap*0.8) // if player health is between 90 and 80% display 90 % health. and so on downwards.
		{
			transform.localScale = new Vector3((minSize*9), scaleY, scaleZ); // transform scale to make it fit 90% of max size on X axis.
		}
		
		if(Player.GetComponent<player>().pHp <= Player.GetComponent<player>().HPCap*0.8 && Player.GetComponent<player>().pHp >= Player.GetComponent<player>().HPCap*0.7)
		{
			transform.localScale = new Vector3((minSize*8), scaleY, scaleZ);
		}
		
		if(Player.GetComponent<player>().pHp <= Player.GetComponent<player>().HPCap*0.7 && Player.GetComponent<player>().pHp >= Player.GetComponent<player>().HPCap*0.6)
		{
			transform.localScale = new Vector3((minSize*7), scaleY, scaleZ);
		}
		
		if(Player.GetComponent<player>().pHp <= Player.GetComponent<player>().HPCap*0.6 && Player.GetComponent<player>().pHp >= Player.GetComponent<player>().HPCap*0.5)
		{
			transform.localScale = new Vector3((minSize*6), scaleY, scaleZ);
		}
		
		if(Player.GetComponent<player>().pHp <= Player.GetComponent<player>().HPCap*0.5 && Player.GetComponent<player>().pHp >= Player.GetComponent<player>().HPCap*0.4)
		{
			transform.localScale = new Vector3((minSize*5), scaleY, scaleZ);
		}
		
		if(Player.GetComponent<player>().pHp <= Player.GetComponent<player>().HPCap*0.4 && Player.GetComponent<player>().pHp >= Player.GetComponent<player>().HPCap*0.3)
		{
			transform.localScale = new Vector3((minSize*4), scaleY, scaleZ);
		}
		
		if(Player.GetComponent<player>().pHp <= Player.GetComponent<player>().HPCap*0.3 && Player.GetComponent<player>().pHp >= Player.GetComponent<player>().HPCap*0.2)
		{
			transform.localScale = new Vector3((minSize*3), scaleY, scaleZ);
		}
		
		if(Player.GetComponent<player>().pHp <= Player.GetComponent<player>().HPCap*0.2 && Player.GetComponent<player>().pHp >= Player.GetComponent<player>().HPCap*0.1)
		{
			transform.localScale = new Vector3((minSize*2), scaleY, scaleZ);
		}
		
		if(Player.GetComponent<player>().pHp <= Player.GetComponent<player>().HPCap*0.1 && Player.GetComponent<player>().pHp >= Player.GetComponent<player>().HPCap*0.0 )
		{
			transform.localScale = new Vector3((minSize*1), scaleY, scaleZ);
		}
	}
}
