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
	public Sprite skin; // skin for the player once body has been selected.
	public Texture skinTex;
}

public class GearHandler : MonoBehaviour
{

    public List<Body> Bodies = new List<Body>(); // make a list of bodies to be collected and loaded everywhere in code (this will contain all bodies implemented in the game.)
	public List<Body> Backpack = new List<Body>(); // all loot goes in here and loads from here.
	public Sprite brute; // allows for quick load later in the GUI.
	public Sprite sneaky;
	public Sprite mage;
	public Sprite myDefault;

	public Texture bruteTex;
	public Texture sneakyTex;
	public Texture mageTex;
	public Texture myDefaultTex;


	GameObject Player;

	// Use this for initialization
	void Start () 
	{
		Backpack.Add (null);
		Backpack.Add (null);
		Backpack.Add (null);
		Backpack.Add (null);
		Backpack.Add (null);
		Backpack.Add (null);

		Player = GameObject.FindGameObjectWithTag("Player"); // find the player data.
		//Define some bodies.

		Body defBody = new Body(); // generate new instance of class body
        Body bruteBody = new Body();
		Body sneakyBody = new Body();
		Body mageBody = new Body();
		
		makeBody(defBody, "Default", 100, 20,20,20, 10, false, false, false, myDefault, myDefaultTex); // fill these bodies with data.
		makeBody(bruteBody, "Brute", 150, 20,10,30, 20, false, false, true, brute, bruteTex);
		makeBody(sneakyBody, "Sneaky", 100, 10,30,20, 10, false, true, false, sneaky, sneakyTex);
		makeBody(mageBody, "Magus", 75, 30,20,10, 15, true, false, false, mage, mageTex);




		// Add bodies into the list.
		Player.GetComponent<player>().currBody = GetComponent<GearHandler>().Bodies[1]; // make sure that current body is a default body..
		Player.GetComponent<player>().loadGear = true; // load gear into player..

	}
	// Update is called once per frame
	void Update () 
	{

	}
	void makeBody(Body bodyToMold, string name, int HP, int inte, int dex, int str, int damage, bool mageAbil, bool sneakyAbil, bool bruteAbil, Sprite skin, Texture skinTex) // fill bodies with data.
	{
		bodyToMold.name = name;
		bodyToMold.gHp = HP;
		bodyToMold.gInte = inte;
		bodyToMold.gDex = dex;
		bodyToMold.gStr = str;
		bodyToMold.gDamage = damage;
		bodyToMold.mageAbil = mageAbil;
		bodyToMold.sneakyAbil = sneakyAbil;
		bodyToMold.bruteAbil = bruteAbil;
		bodyToMold.skin = skin;
		bodyToMold.skinTex = skinTex;
		Bodies.Add (bodyToMold);
	}
}
