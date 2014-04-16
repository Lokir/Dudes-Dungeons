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


	public bool rightBool; // These bools help define what animation to start.
	public bool leftBool;
	public bool idleBool;

	public Sprite walk1; // Default Animations
	public Sprite walk2;
	public Sprite walk1R;
	public Sprite walk2R;
	public Sprite idle;

	public Sprite bruteWalk1; // BruteType Animations
	public Sprite bruteWalk2;
	public Sprite bruteWalk1R;
	public Sprite bruteWalk2R;
	public Sprite bruteIdle;

	public Sprite sneakyWalk1; // Sneaky/Rogue type Animations.
	public Sprite sneakyWalk2;
	public Sprite sneakyWalk1R;
	public Sprite sneakyWalk2R;
	public Sprite sneakyIdle;

	public Sprite mageWalk1; // Mage type Animations.
	public Sprite mageWalk2;
	public Sprite mageWalk1R;
	public Sprite mageWalk2R;
	public Sprite mageIdle;

	// Use this for initialization
	void Start () {
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
		
	}
	// Update is called once per frame
	int q = 0; // q is where in the list we are now, and allows for the animations to be initiated based on the buttons detected in player.cs
	void Update () 
	{
		if(rightBool == true) // if true look for current body var in player.cs and run the appropriate animation.
		{
			if(GetComponent<player>().currBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = defList[q];

			if(GetComponent<player>().currBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = bruteList[q];

			if(GetComponent<player>().currBody.name == "sneaky")
				GetComponent<SpriteRenderer>().sprite = sneakyList[q];

			if(GetComponent<player>().currBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = mageList[q];

			rightBool = false; // set rightBool to false, so it stops when the button is no longer pressed.
		}
		if(leftBool == true) // same as above but with inversed images.
		{
			if(GetComponent<player>().currBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = defListR[q];
			
			if(GetComponent<player>().currBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = bruteListR[q];
			
			if(GetComponent<player>().currBody.name == "sneaky")
				GetComponent<SpriteRenderer>().sprite = sneakyListR[q];
			
			if(GetComponent<player>().currBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = mageListR[q];

			leftBool = false;
		}
		if(idleBool == true) // load the idle sprite (1 image as per 16/4-2014)
		{
			if(GetComponent<player>().currBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = idle;
			
			if(GetComponent<player>().currBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = bruteIdle;
			
			if(GetComponent<player>().currBody.name == "sneaky")
				GetComponent<SpriteRenderer>().sprite = sneakyIdle;
			
			if(GetComponent<player>().currBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = mageIdle;
			idleBool = false;
		}
		if(q >= 15) // make sure the q doesn't go out of list parameters.
			q = 0;
		q++; // increment to next step.
	}

}
