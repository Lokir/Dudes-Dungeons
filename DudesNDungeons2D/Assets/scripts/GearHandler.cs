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
	public Sprite brute;
	public Sprite sneaky;
	public Sprite mage;
	public Sprite myDefault;
	// Use this for initialization
	void Start () 
	{
		//Define some bodies.
        Body bruteBody = new Body();
		bruteBody.name = "Brute";
		bruteBody.gHp = 100;
		bruteBody.gInte = 5;
		bruteBody.gDex = 10;
		bruteBody.gStr = 15;
		bruteBody.gDamage = bruteBody.gStr + 5;
		bruteBody.bruteAbil = true;
		bruteBody.sneakyAbil = false;
		bruteBody.mageAbil = false;
		bruteBody.skin = brute;

        Body sneakyBody = new Body();
		sneakyBody.name = "sneaky";
        sneakyBody.gHp = 75;
        sneakyBody.gInte = 5;
        sneakyBody.gDex = 15;
        sneakyBody.gStr = 10;
        sneakyBody.gDamage = sneakyBody.gStr + 5;
        sneakyBody.sneakyAbil = true;
		sneakyBody.bruteAbil = false;
		sneakyBody.mageAbil = false;
		sneakyBody.skin = sneaky;

        Body mageBody = new Body();
		mageBody.name = "Magus";
        mageBody.gHp = 60;
        mageBody.gInte = 15;
        mageBody.gDex = 10;
        mageBody.gStr = 5;
        mageBody.gDamage = mageBody.gStr + 5;
        mageBody.mageAbil = true;
		mageBody.sneakyAbil = false;
		mageBody.bruteAbil = false;
		mageBody.skin = mage;

		Body defBody = new Body();
		defBody.name = "Default";
		defBody.gHp = 90;
		defBody.gInte = 10;
		defBody.gDex = 10;
		defBody.gStr = 10;
		defBody.gDamage = defBody.gStr + 5;
		defBody.mageAbil = false;
		defBody.sneakyAbil = false;
		defBody.bruteAbil = false;
		defBody.skin = myDefault;

		// Add bodies into the list.
		Bodies.Add (defBody);
		Bodies.Add (bruteBody);
		Bodies.Add (sneakyBody);
		Bodies.Add (mageBody);

	}
	// Update is called once per frame
	void Update () 
	{
	}
}
