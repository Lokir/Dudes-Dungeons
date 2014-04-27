using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stab : MonoBehaviour {
	
	GameObject PlayStat;
	public bool stabStabStab;
	
	public Sprite SCone1; // Stab animation
	public Sprite SCone2;
	public Sprite SCone3;
	public Sprite SCone4;
	public Sprite SCone5;
	public Sprite SCone6;
	public Sprite SCone7;
	public Sprite SCone8;
	public Sprite SCone9;
	public Sprite SCone10;

	public Sprite RSCone1; // reverse Stab Animation.
	public Sprite RSCone2;
	public Sprite RSCone3;
	public Sprite RSCone4;
	public Sprite RSCone5;
	public Sprite RSCone6;
	public Sprite RSCone7;
	public Sprite RSCone8;
	public Sprite RSCone9;
	public Sprite RSCone10;

	public Sprite none; // no image.
	
	public bool left; // moving left.
	
	public List<Sprite> ConeStab = new List<Sprite>(); // lists to load all the images.
	public List<Sprite> RConeStab = new List<Sprite>(); // list to load all inversed images.
	// Use this for initialization
	void Start () {
		PlayStat = GameObject.FindGameObjectWithTag("Player"); // find player.
		
		for(int i = 0; i < 4; i++) // load in needed data. for loops only run once.
		{
			ConeStab.Add (SCone1);
			RConeStab.Add (RSCone1);
		}
		for(int i = 0; i < 4; i++)
		{
			ConeStab.Add (SCone2);
			RConeStab.Add (RSCone2);
		}
		for(int i = 0; i < 4; i++)
		{
			ConeStab.Add (SCone3);
			RConeStab.Add (RSCone3);
		}
		for(int i = 0; i < 4; i++)
		{
			ConeStab.Add (SCone4);
			RConeStab.Add (RSCone4);
		}
		for(int i = 0; i < 4; i++)
		{
			ConeStab.Add (SCone5);
			RConeStab.Add (RSCone5);
		}
		for(int i = 0; i < 4; i++)
		{
			ConeStab.Add (SCone6);
			RConeStab.Add (RSCone6);
		}
		for(int i = 0; i < 4; i++)
		{
			ConeStab.Add (SCone7);
			RConeStab.Add (RSCone7);
		}
		for(int i = 0; i < 4; i++)
		{
			ConeStab.Add (SCone8);
			RConeStab.Add (RSCone8);
		}
		for(int i = 0; i < 4; i++)
		{
			ConeStab.Add (SCone9);
			RConeStab.Add (RSCone9);
		}
		for(int i = 0; i < 4; i++)
		{
			ConeStab.Add (SCone10);
			RConeStab.Add (RSCone10);
		}

			
	}
	// Update is called once per frame
	int C = 0; // variable to determine position in list.
	
	void Update () 
	{
		if(PlayStat.GetComponent<player>().currBody.sneakyAbil == true) // if sneaky Body is equipped (only one who can use this abil)
		{
			if(PlayStat.GetComponent<player>().left == true) // if moving left
			{
				transform.position = new Vector3(PlayStat.transform.position.x-2,PlayStat.transform.position.y,0); // move left.
			}
			else 
			{
				transform.position = new Vector3(PlayStat.transform.position.x+2,PlayStat.transform.position.y,0); // else move right.
			}
			
			if(stabStabStab == false) // if inactive load no image.
			{
				GetComponent<SpriteRenderer>().sprite = none;
				C = 0; // reset animation.
			}
			
			if(stabStabStab == true) // if active load animation.
			{
				if(PlayStat.GetComponent<player>().left == true) // moving left laod inverse.
					GetComponent<SpriteRenderer>().sprite = RConeStab[C];
				else
					GetComponent<SpriteRenderer>().sprite = ConeStab[C]; // moving right, load standard.
				if(C >= 19) // make sure list parameters are not broken.
					C=0; // reset C
				C++;
			}
		}
	}
}
