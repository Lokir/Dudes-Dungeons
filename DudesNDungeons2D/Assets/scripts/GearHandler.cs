using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Body // defines body as a class.
{
	public int gHp, gInte, gDex, gStr, gCharge; // BodyStats
	public string name; // Label the body.
	public bool mageAbil; // define ability.
	public bool bruteAbil;
	public bool sneakyAbil;
	public int gDamage; // Body Bonus Damage
	public Sprite skin;
}

public class GearHandler : MonoBehaviour
{

    public List<Body> Bodies = new List<Body>(); // make a list of bodies to be collected and loaded everywhere in code (this will contain all bodies implemented in the game.)
	public List<Body> Backpack = new List<Body>();
	public Sprite brute;
	public Sprite sneaky;
	public Sprite mage;
	public Sprite myDefault;

	GameObject Player;

	// Use this for initialization
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag("Player");
		//Define some bodies.
        Body bruteBody = new Body();
		bruteBody.name = "Brute";
		bruteBody.gHp = 150;
		bruteBody.gInte = 20;
		bruteBody.gDex = 10;
		bruteBody.gStr = 30;
		bruteBody.gDamage = 20;
		bruteBody.bruteAbil = true;
		bruteBody.sneakyAbil = false;
		bruteBody.mageAbil = false;
		bruteBody.skin = brute;

        Body sneakyBody = new Body();
		sneakyBody.name = "Sneaky";
        sneakyBody.gHp = 100;
        sneakyBody.gInte = 10;
        sneakyBody.gDex = 30;
        sneakyBody.gStr = 20;
        sneakyBody.gDamage = 10;
        sneakyBody.sneakyAbil = true;
		sneakyBody.bruteAbil = false;
		sneakyBody.mageAbil = false;
		sneakyBody.skin = sneaky;

        Body mageBody = new Body();
		mageBody.name = "Magus";
        mageBody.gHp = 75;
        mageBody.gInte = 30;
        mageBody.gDex = 20;
        mageBody.gStr = 10;
        mageBody.gDamage = 15;
        mageBody.mageAbil = true;
		mageBody.sneakyAbil = false;
		mageBody.bruteAbil = false;
		mageBody.skin = mage;

		Body defBody = new Body();
		defBody.name = "Default";
		defBody.gHp = 100;
		defBody.gInte = 20;
		defBody.gDex = 20;
		defBody.gStr = 20;
		defBody.gDamage = 10;
		defBody.mageAbil = false;
		defBody.sneakyAbil = false;
		defBody.bruteAbil = false;
		defBody.skin = myDefault;

		// Add bodies into the list.
		Bodies.Add (defBody);
		Bodies.Add (bruteBody);
		Bodies.Add (sneakyBody);
		Bodies.Add (mageBody);

		Player.GetComponent<player>().currBody = GetComponent<GearHandler>().Bodies[0];
		Player.GetComponent<player>().loadGear = true;

	}
	// Update is called once per frame
	void Update () 
	{

	}
}
