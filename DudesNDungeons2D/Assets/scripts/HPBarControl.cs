using UnityEngine;
using System.Collections;

public class HPBarControl : MonoBehaviour {
	GameObject Player;
	GameObject enemyParent;
	float startingSize;
	float scaleY;
	float scaleZ;
	float minSize;
	// Use this for initialization
	void Start () {

		Player = GameObject.FindGameObjectWithTag("Player");
		startingSize = transform.localScale.x;
		scaleY = transform.localScale.y;
		scaleZ = transform.localScale.z;
		minSize = startingSize/10;

	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(Player.GetComponent<player>().pHp == Player.GetComponent<player>().HPCap)
		{
			transform.localScale = new Vector3((minSize*10), scaleY, scaleZ);
		}
		
		if(Player.GetComponent<player>().pHp <= Player.GetComponent<player>().HPCap*0.9 && Player.GetComponent<player>().pHp >= Player.GetComponent<player>().HPCap*0.8)
		{
			transform.localScale = new Vector3((minSize*9), scaleY, scaleZ);
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
