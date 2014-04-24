using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimHandler : MonoBehaviour {

	//The lists allow us to continously update target spriteRenderer, and create animations with code.
	public List<Sprite> defList = new List<Sprite>();
	public List<Sprite> defListR = new List<Sprite>();

	public List<Sprite> bruteList = new List<Sprite>();
	public List<Sprite> bruteListR = new List<Sprite>();

	public List<Sprite> sneakyList = new List<Sprite>();
	public List<Sprite> sneakyListR = new List<Sprite>();

	public List<Sprite> mageList = new List<Sprite>();
	public List<Sprite> mageListR = new List<Sprite>();

	public List<Sprite> defAtkList = new List<Sprite>();

	public bool rightBool; // These bools help define what animation to start.
	public bool leftBool;
	public bool idleBool;
	public bool attackBool;
	public bool leftAttackBool;

	public Sprite defAttack1;
	public Sprite defAttack2;
	public Sprite defAttack3;

	public Sprite walk1; // Default Animations
	public Sprite walk2;
	public Sprite walk3;
	public Sprite walk4;
	public Sprite walk5;
	public Sprite walk1R;
	public Sprite walk2R;
	public Sprite walk3R;
	public Sprite walk4R;
	public Sprite walk5R;
	public Sprite idle;

	public Sprite bruteWalk1; // BruteType Animations
	public Sprite bruteWalk2;
	public Sprite bruteWalk3;
	public Sprite bruteWalk4;
	public Sprite bruteWalk5;
	public Sprite bruteWalk1R;
	public Sprite bruteWalk2R;
	public Sprite bruteWalk3R;
	public Sprite bruteWalk4R;
	public Sprite bruteWalk5R;
	public Sprite bruteIdle;

	public Sprite sneakyWalk1; // Sneaky/Rogue type Animations.
	public Sprite sneakyWalk2;
	public Sprite sneakyWalk3;
	public Sprite sneakyWalk4;
	public Sprite sneakyWalk5;
	public Sprite sneakyWalk1R;
	public Sprite sneakyWalk2R;
	public Sprite sneakyWalk3R;
	public Sprite sneakyWalk4R;
	public Sprite sneakyWalk5R;
	public Sprite sneakyIdle;

	public Sprite mageWalk1; // Mage type Animations.
	public Sprite mageWalk2;
	public Sprite mageWalk3;
	public Sprite mageWalk4;
	public Sprite mageWalk5;
	public Sprite mageWalk1R;
	public Sprite mageWalk2R;
	public Sprite mageWalk3R;
	public Sprite mageWalk4R;
	public Sprite mageWalk5R;
	public Sprite mageIdle;

	// Use this for initialization
	void Start () 
	{

		for(int i = 0; i<4; i++)
		{
			defAtkList.Add(walk1);
		}
		for(int i = 0; i<8; i++)
		{
			defAtkList.Add(defAttack1);
		}
		for(int i = 0; i<3; i++)
		{
			defAtkList.Add(defAttack2);
		}
		defAtkList.Add(idle);

		for(int i = 0; i < 8; i++) // Load in 8 of each sprite to correspondent lists
		{
			defList.Add (walk1);
			defListR.Add (walk1R);

			bruteList.Add (bruteWalk1);
			bruteListR.Add (bruteWalk1R);

			sneakyList.Add (sneakyWalk1);
			sneakyListR.Add (sneakyWalk1R); // R is for Reverse or Inversed animations (rotations)

			mageList.Add (mageWalk1);
			mageListR.Add (mageWalk1R);

		}
		for(int i = 0; i < 8; i++) // Same as above, this gives us a two part animation movement.
		{
			defList.Add (walk2);
			defListR.Add (walk2R);

			bruteList.Add (bruteWalk2);
			bruteListR.Add (bruteWalk2R);
			
			sneakyList.Add (sneakyWalk2);
			sneakyListR.Add (sneakyWalk2R);
			
			mageList.Add (mageWalk2);
			mageListR.Add (mageWalk2R);
		}
		for(int i = 0; i < 8; i++) // Same as above, this gives us a two part animation movement.
		{
			defList.Add (walk3);
			defListR.Add (walk3R);
			
			bruteList.Add (bruteWalk3);
			bruteListR.Add (bruteWalk3R);
			
			sneakyList.Add (sneakyWalk3);
			sneakyListR.Add (sneakyWalk3R);
			
			mageList.Add (mageWalk3);
			mageListR.Add (mageWalk3R);
		}
		for(int i = 0; i < 8; i++) // Same as above, this gives us a two part animation movement.
		{
			defList.Add (walk4);
			defListR.Add (walk4R);
			
			bruteList.Add (bruteWalk4);
			bruteListR.Add (bruteWalk4R);
			
			sneakyList.Add (sneakyWalk4);
			sneakyListR.Add (sneakyWalk4R);
			
			mageList.Add (mageWalk4);
			mageListR.Add (mageWalk4R);
		}
		for(int i = 0; i < 8; i++) // Same as above, this gives us a two part animation movement.
		{
			defList.Add (walk5);
			defListR.Add (walk5R);
			
			bruteList.Add (bruteWalk5);
			bruteListR.Add (bruteWalk5R);
			
			sneakyList.Add (sneakyWalk5);
			sneakyListR.Add (sneakyWalk5R);
			
			mageList.Add (mageWalk5);
			mageListR.Add (mageWalk5R);
		}
		
	}
	// Update is called once per frame
	public int q = 0; // q is where in the list we are now, and allows for the animations to be initiated based on the buttons detected in player.cs
	void Update () 
	{
		if(attackBool == true)
		{
			if(leftAttackBool == false)
			{
				if(GetComponent<player>().currBody.name == "Default")
					GetComponent<SpriteRenderer>().sprite = defAtkList[q];
			}
			if(leftAttackBool == true)
			{
				if(GetComponent<player>().currBody.name == "Default")
					GetComponent<SpriteRenderer>().sprite = defAtkList[q];
			}
		}
		if(rightBool == true && attackBool != true) // if true look for current body var in player.cs and run the appropriate animation.
		{
			if(GetComponent<player>().currBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = defList[q];

			if(GetComponent<player>().currBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = bruteList[q];

			if(GetComponent<player>().currBody.name == "Sneaky")
				GetComponent<SpriteRenderer>().sprite = sneakyList[q];

			if(GetComponent<player>().currBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = mageList[q];

			rightBool = false; // set rightBool to false, so it stops when the button is no longer pressed.
		}
		if(leftBool == true && attackBool != true) // same as above but with inversed images.
		{
			if(GetComponent<player>().currBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = defListR[q];
			
			if(GetComponent<player>().currBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = bruteListR[q];
			
			if(GetComponent<player>().currBody.name == "Sneaky")
				GetComponent<SpriteRenderer>().sprite = sneakyListR[q];
			
			if(GetComponent<player>().currBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = mageListR[q];

			leftBool = false;
		}
		if(idleBool == true && attackBool != true) // load the idle sprite (1 image as per 16/4-2014)
		{
			if(GetComponent<player>().currBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = idle;
			
			if(GetComponent<player>().currBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = bruteIdle;
			
			if(GetComponent<player>().currBody.name == "Sneaky")
				GetComponent<SpriteRenderer>().sprite = sneakyIdle;
			
			if(GetComponent<player>().currBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = mageIdle;
			idleBool = false;
		}
		if(q >= 15) // make sure the q doesn't go out of list parameters.
		{
			attackBool = false;
			q = 0;
		}
		q++; // increment to next step.
	}

}
