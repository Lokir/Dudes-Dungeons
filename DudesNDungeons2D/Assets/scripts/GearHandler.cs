using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Body
{	
	//intended to be instantiated when loading into lists in some sort of main class, to make the actual bodypart objects.
	public int gHp, gInte, gDex, gStr, gCharge;
	public string name;
	public bool mageAbil;
	public bool bruteAbil;
	public bool sneakyAbil;
	public int gDamage;
	public Sprite skin;

	public void ability()//not finished! Call this function when you want to activate abilities.
	{
		if(bruteAbil == true) // program the brute ability in here...
		{
			Debug.Log ("Brute Ability Activated");
		}
		else if(sneakyAbil == true) // program the sneaky ability in here...
		{
			Debug.Log ("Sneaky Ability Activated");
		}
		else if(mageAbil == true) // program the mage ability in here...
		{
			Debug.Log ("Mage Ability Activated");
		}
		else
		{
			Debug.Log("No Ability Assigned");
		}
	}
}

public class GearHandler : MonoBehaviour
{

    public List<Body> Bodies = new List<Body>();

	// Use this for initialization
	void Start () 
	{
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
