using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Stab : MonoBehaviour {
	
	GameObject PlayStat;
	
	public Sprite SCone1;
	public Sprite SCone2;
	public Sprite SCone3;
	public Sprite SCone4;
	public Sprite SCone5;
	public Sprite SCone6;
	public Sprite SCone7;
	public Sprite SCone8;
	public Sprite SCone9;
	public Sprite SCone10;

	public Sprite RSCone1;
	public Sprite RSCone2;
	public Sprite RSCone3;
	public Sprite RSCone4;
	public Sprite RSCone5;
	public Sprite RSCone6;
	public Sprite RSCone7;
	public Sprite RSCone8;
	public Sprite RSCone9;
	public Sprite RSCone10;

	public Sprite none;
	
	public bool left;
	
	public List<Sprite> ConeStab = new List<Sprite>();
	public List<Sprite> RConeStab = new List<Sprite>();
	// Use this for initialization
	void Start () {
		PlayStat = GameObject.FindGameObjectWithTag("Player");
		
		for(int i = 0; i < 4; i++)
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
	int C = 0;
	
	void Update () 
	{
		if(PlayStat.GetComponent<player>().currBody.sneakyAbil == true)
		{
			if(PlayStat.GetComponent<player>().left == true)
			{
				transform.position = new Vector3(PlayStat.transform.position.x-2,PlayStat.transform.position.y,0);
			}
			else 
			{
				transform.position = new Vector3(PlayStat.transform.position.x+2,PlayStat.transform.position.y,0);
			}
			
			if(Input.GetKeyUp (KeyCode.R))
			{
				GetComponent<SpriteRenderer>().sprite = none;
				C = 0;
			}
			
			if(Input.GetKey (KeyCode.R))
			{
				if(PlayStat.GetComponent<player>().left == true)
					GetComponent<SpriteRenderer>().sprite = RConeStab[C];
				else
					GetComponent<SpriteRenderer>().sprite = ConeStab[C];
				if(C >= 19)
					C=0;
				C++;
			}
		}
	}
}
