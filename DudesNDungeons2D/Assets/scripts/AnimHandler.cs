using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimHandler : MonoBehaviour {

	Vector3 mousePos; // 3D vectors to detect mouse and to generate screen to world coordinates.
	Vector3 wantedPos;

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
	public List<Sprite> defAtkListR = new List<Sprite>();

	public List<Sprite> bruteAtkList = new List<Sprite>();
	public List<Sprite> bruteAtkListR = new List<Sprite>();

	public List<Sprite> sneakyAtkList = new List<Sprite>();
	public List<Sprite> sneakyAtkListR = new List<Sprite>();

	public List<Sprite> mageAtkList = new List<Sprite>();
	public List<Sprite> mageAtkListR = new List<Sprite>();

	public bool rightBool; // These bools help define what animation to start.
	public bool leftBool;
	public bool attackBool;
	public bool leftAttackBool;

	public Sprite defAttack1;
	public Sprite defAttack2;
	public Sprite defAttack1R;
	public Sprite defAttack2R;

	public Sprite bruteAttack1;
	public Sprite bruteAttack2;
	public Sprite bruteAttack3;
	public Sprite bruteAttack1R;
	public Sprite bruteAttack2R;
	public Sprite bruteAttack3R;

	public Sprite sneakyAttack1;
	public Sprite sneakyAttack2;
	public Sprite sneakyAttack1R;
	public Sprite sneakyAttack2R;

	public Sprite mageAttack1;
	public Sprite mageAttack2;
	public Sprite mageAttack3;
	public Sprite mageAttack1R;
	public Sprite mageAttack2R;
	public Sprite mageAttack3R;

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

	// Use this for initialization
	void Start () 
	{
		rightBool = false; // These bools help define what animation to start.
		leftBool = false;
		attackBool = false;

		//Default attack animation to the right
		addSpritesToList(defAtkList, defAttack1, 7); // add to list takes in a list, a sprite and a number of iterations.
		addSpritesToList(defAtkList, defAttack2, 7); // it basically fills up the given list with sprites as designated.
		addSpritesToList(defAtkList, defAttack1, 7);
		addSpritesToList(defAtkList, defAttack2, 7);
		defAtkList.Add (walk1);
		defAtkList.Add (walk1);

		//Default attack animation to the left
		addSpritesToList(defAtkListR, defAttack1R, 7);
		addSpritesToList(defAtkListR, defAttack2R, 7);
		addSpritesToList(defAtkListR, defAttack1R, 7);
		addSpritesToList(defAtkListR, defAttack2R, 7);
		defAtkListR.Add (walk1R);
		defAtkListR.Add (walk1R);



		//Brute attack animation to the right
		addSpritesToList(bruteAtkList, bruteAttack1, 10);
		addSpritesToList(bruteAtkList, bruteAttack2, 10);
		addSpritesToList(bruteAtkList, bruteAttack3, 10);

		//Brute attack animation to the left
		addSpritesToList(bruteAtkListR, bruteAttack1R, 10);
		addSpritesToList(bruteAtkListR, bruteAttack2R, 10);
		addSpritesToList(bruteAtkListR, bruteAttack3R, 10);



		//Sneaky attack animation to the right - double stab
		addSpritesToList(sneakyAtkList, sneakyAttack1, 7);
		addSpritesToList(sneakyAtkList, sneakyAttack2, 7);
		addSpritesToList(sneakyAtkList, sneakyAttack1, 7);
		addSpritesToList(sneakyAtkList, sneakyAttack2, 7);
		sneakyAtkList.Add (sneakyWalk1);
		sneakyAtkList.Add (sneakyWalk1);

		//Sneaky attack animation to the left - double stab
		addSpritesToList(sneakyAtkListR, sneakyAttack1R, 7);
		addSpritesToList(sneakyAtkListR, sneakyAttack2R, 7);
		addSpritesToList(sneakyAtkListR, sneakyAttack1R, 7);
		addSpritesToList(sneakyAtkListR, sneakyAttack2R, 7);
		sneakyAtkListR.Add (sneakyWalk1R);
		sneakyAtkListR.Add (sneakyWalk1R);



		//Mage attack animation to the right
		addSpritesToList(mageAtkList, mageAttack1, 10);
		addSpritesToList(mageAtkList, mageAttack2, 10);
		addSpritesToList(mageAtkList, mageAttack3, 10);

		//Mage attack animation to the left
		addSpritesToList(mageAtkListR, mageAttack1R, 10);
		addSpritesToList(mageAtkListR, mageAttack2R, 10);
		addSpritesToList(mageAtkListR, mageAttack3R, 10);

		//Movements

		addSpritesToList(defList, walk1, 6);
		addSpritesToList(defListR, walk1R, 6);

		addSpritesToList(bruteList, bruteWalk1, 6);
		addSpritesToList(bruteListR, bruteWalk1R, 6);

		addSpritesToList(sneakyList, sneakyWalk1, 6);
		addSpritesToList(sneakyListR, sneakyWalk1R, 6);

		addSpritesToList(mageList, mageWalk1, 6);
		addSpritesToList(mageListR, mageWalk1R, 6);



		addSpritesToList(defList, walk2, 6);
		addSpritesToList(defListR, walk2R, 6);
		
		addSpritesToList(bruteList, bruteWalk2, 6);
		addSpritesToList(bruteListR, bruteWalk2R, 6);
		
		addSpritesToList(sneakyList, sneakyWalk2, 6);
		addSpritesToList(sneakyListR, sneakyWalk2R, 6);
		
		addSpritesToList(mageList, mageWalk2, 6);
		addSpritesToList(mageListR, mageWalk2R, 6);



		addSpritesToList(defList, walk3, 6);
		addSpritesToList(defListR, walk3R, 6);
		
		addSpritesToList(bruteList, bruteWalk3, 6);
		addSpritesToList(bruteListR, bruteWalk3R, 6);
		
		addSpritesToList(sneakyList, sneakyWalk3, 6);
		addSpritesToList(sneakyListR, sneakyWalk3R, 6);
		
		addSpritesToList(mageList, mageWalk3, 6);
		addSpritesToList(mageListR, mageWalk3R, 6);



		addSpritesToList(defList, walk4, 6);
		addSpritesToList(defListR, walk4R, 6);
		
		addSpritesToList(bruteList, bruteWalk4, 6);
		addSpritesToList(bruteListR, bruteWalk4R, 6);
		
		addSpritesToList(sneakyList, sneakyWalk4, 6);
		addSpritesToList(sneakyListR, sneakyWalk4R, 6);
		
		addSpritesToList(mageList, mageWalk4, 6);
		addSpritesToList(mageListR, mageWalk4R, 6);



		addSpritesToList(defList, walk5, 6);
		addSpritesToList(defListR, walk5R, 6);
		
		addSpritesToList(bruteList, bruteWalk5, 6);
		addSpritesToList(bruteListR, bruteWalk5R, 6);
		
		addSpritesToList(sneakyList, sneakyWalk5, 6);
		addSpritesToList(sneakyListR, sneakyWalk5R, 6);
		
		addSpritesToList(mageList, mageWalk5, 6);
		addSpritesToList(mageListR, mageWalk5R, 6);
	}
	void addSpritesToList(List<Sprite> tmpList, Sprite tmpSprite, int p) // fills up the lists, more reusable code compared to the hardcoded version we had before.
	{
		for(int i = 0; i<p; i++)
			tmpList.Add(tmpSprite);
	}
	// Update is called once per frame
	public int q = 0; // q is where in the list we are now, and allows for the animations to be initiated based on the buttons detected in player.cs
	void Update () 
	{
		faceDirection(); // make sure the player is facing the direction of the mouse on screen.

		if(attackBool == true) // you can attack start the attack animation
		{
			if(leftAttackBool == true) // attack left
			{
				//Attack to the left animations for the specific body
				if(GetComponent<player>().currBody.name == "Default")
					GetComponent<SpriteRenderer>().sprite = defAtkListR[q];

				if(GetComponent<player>().currBody.name == "Brute")
					GetComponent<SpriteRenderer>().sprite = bruteAtkListR[q];

				if(GetComponent<player>().currBody.name == "Sneaky")
					GetComponent<SpriteRenderer>().sprite = sneakyAtkListR[q];

				if(GetComponent<player>().currBody.name == "Magus")
					GetComponent<SpriteRenderer>().sprite = mageAtkListR[q];

			}
			if(leftAttackBool == false) // attack right.
			{
				//Attack to the right animations for the specific body
				if(GetComponent<player>().currBody.name == "Default")
					GetComponent<SpriteRenderer>().sprite = defAtkList[q];

				if(GetComponent<player>().currBody.name == "Brute")
					GetComponent<SpriteRenderer>().sprite = bruteAtkList[q];

				if(GetComponent<player>().currBody.name == "Sneaky")
					GetComponent<SpriteRenderer>().sprite = sneakyAtkList[q];

				if(GetComponent<player>().currBody.name == "Magus")
					GetComponent<SpriteRenderer>().sprite = mageAtkList[q];
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
		if(q >= 29) // make sure the q doesn't go out of list's boundries.
		{
			attackBool = false; // so attack cycle will only run once.
			q = 0;
		}
		q++; // increment to next step.
	}
	void faceDirection()
	{
		mousePos = Input.mousePosition; // get mouse (x,y)
		wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 3.54f)); //position mouse in world space, not screen space.
		if(transform.position.x > wantedPos.x) // detect mouse pos compared to player pos.
		{
			leftAttackBool = true; // if mouse is left side of player sprite, face left and attack left if attacking.
			if(!Input.GetKeyDown (KeyCode.A) || !Input.GetKeyDown (KeyCode.D)) 
			{
				if(GetComponent<player>().currBody.name == "Default")
					GetComponent<SpriteRenderer>().sprite = walk1R;
				
				if(GetComponent<player>().currBody.name == "Brute")
					GetComponent<SpriteRenderer>().sprite = bruteWalk1R;
				
				if(GetComponent<player>().currBody.name == "Sneaky")
					GetComponent<SpriteRenderer>().sprite = sneakyWalk1R;
				
				if(GetComponent<player>().currBody.name == "Magus")
					GetComponent<SpriteRenderer>().sprite = mageWalk1R;
			}
		}
		else
		{
			leftAttackBool = false; // else face right, and attack right.
			if(!Input.GetKeyDown (KeyCode.A) || !Input.GetKeyDown (KeyCode.D)) 
			{
				if(GetComponent<player>().currBody.name == "Default")
					GetComponent<SpriteRenderer>().sprite = walk1;
				
				if(GetComponent<player>().currBody.name == "Brute")
					GetComponent<SpriteRenderer>().sprite = bruteWalk1;
				
				if(GetComponent<player>().currBody.name == "Sneaky")
					GetComponent<SpriteRenderer>().sprite = sneakyWalk1;
				
				if(GetComponent<player>().currBody.name == "Magus")
					GetComponent<SpriteRenderer>().sprite = mageWalk1;
			}
		}
	}
}
