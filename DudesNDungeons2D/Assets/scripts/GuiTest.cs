using UnityEngine;
using System.Collections;

public class GuiTest : MonoBehaviour // This system handles the Interactive User Interface part
{
	Rect backpack = new Rect(20, 20, 350, 450); // create the window box for the backpack.
	Rect equippedGear = new Rect(990, 20, 177, 220); // this is the box for the equipped box
	Rect healthPot = new Rect(10,535,110,60);
	Rect abilityArea = new Rect (990, 240, 177,220);

	GameObject PlayStat;

	int potionAmount = 7; // temporary potion counter.
	string potAmountString = ""; // amount of potions in string.

	public string stringHP = "HP: "; // these will display the player Stats in text boxes on screen.
	public string stringStr = "Str: ";
	public string stringDex = "Dex: ";
	public string stringInt = "Int: ";
	public string stringCharge = "Charge: ";
	public string stringDam = "Damage: ";	
	
	public Texture Body1; // These textures allow for visual confirmation of what body type the player is selecting.
	public Texture Body2;
	public Texture Body3;
	public Texture Body4;

	public Texture backpackSkin; // this is currently irrelevant.
	public Texture potion;

	public Texture mageTex; // these textures are ability textures.
	public Texture bruteTex;
	public Texture sneakyTex;

	public Texture abilityTexture; // this one is the one continously loaded
	public Texture abilityTexture1;
	public Texture abilityTexture2;
	public Texture abilityTexture3;

	public Texture defaultTex;

	Texture equippedBody; // this is the empty intance that will be swapped in and out to change equipment.

	bool visiGUI; // Boolean that allows for the Gui to be visible/active or not.

	void Start () // Use this for initialization
	{
		PlayStat = GameObject.FindGameObjectWithTag("Player"); // find player.
		visiGUI = false; // initialization as false.

	}
	// Update is called once per frame
	void Update () 
	{
		potAmountString = ""+potionAmount; // update potion amount with current potion amount.

		stringHP = "HP: "+PlayStat.GetComponent<player>().pHp; // update displayed stats with current stats.
		stringStr = "Str: "+PlayStat.GetComponent<player>().pStr;
		stringDex = "Dex: "+PlayStat.GetComponent<player>().pDex;
		stringInt = "Int: "+PlayStat.GetComponent<player>().pInte;
		stringCharge = "Charge: "+PlayStat.GetComponent<player>().pCharge;
		stringDam = "Damage: "+PlayStat.GetComponent<player>().pDamage;	

		if(Input.GetKeyUp(KeyCode.I)) 	// if I is pressed inverse the boolean controlling it, meaning if bool false become true and reverse.				
		{
			visiGUI = !visiGUI;
		}
	}
	void OnGUI() // this is like the update function but for GUI's, use this for all GUI related matters.
	{
		if(visiGUI == true) //if true, run code, revealing the GUI.
		{	// rect = GUI.Window(ID , Rect, RunFunction, applyTexture);
			backpack = GUI.Window(0, backpack, DoBackPack, backpackSkin); //load GUI window for Backpack
			equippedGear = GUI.Window(1,equippedGear,doEquip, equippedBody); // load GUI window for the equipped body.
			abilityArea = GUI.Window (3,abilityArea, doAbility, backpackSkin);

			stringStr = GUI.TextField(new Rect(580, 90, 200, 20), stringStr, 25); // load player stats
			stringDex = GUI.TextField(new Rect(580, 50, 200, 20), stringDex, 25);
			stringInt = GUI.TextField(new Rect(580, 70, 200, 20), stringInt, 25);
			stringDam = GUI.TextField(new Rect(580, 110, 200, 20), stringDam, 25);
		}
		stringHP = GUI.TextField(new Rect(580, 10, 200, 20), stringHP, 25); // these are excluded because charge, potions and HP should always be visible.
		stringCharge = GUI.TextField(new Rect(580, 30, 200, 20), stringCharge, 25);
		healthPot = GUI.Window (2,healthPot, doHealth, potAmountString);
	}
	// this is the RunFunction, it is run whenever it is called in OnGUI().
	void DoBackPack(int windowID) // this function handles backpack buttons
	{
		// if ( create Gui Button, new rect(x,y,W,H),Texture);
		if (GUI.Button(new Rect(10, 10, 165, 215),Body1)) // button for loading Body 1 (default)
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Bodies[0]; // load default stats into currBody.
			PlayStat.GetComponent<player>().loadGear = true; // make sure that the gear is loaded.
			equippedBody = Body1; // swap button's body into the equipped body. 
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin; // render the equipped body sprite.
			abilityTexture = defaultTex; // load the relevant ability texture.

		}
		if (GUI.Button(new Rect(175, 10, 165, 215),Body2)) // same as first.
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Bodies[1]; // brute
			PlayStat.GetComponent<player>().loadGear = true;
			equippedBody = Body2;
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
			abilityTexture = bruteTex;
		}
		if (GUI.Button(new Rect(10, 225, 165, 215),Body3)) // same as first.
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Bodies[2]; // sneaky
			PlayStat.GetComponent<player>().loadGear = true;
			equippedBody = Body3;
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
			abilityTexture = sneakyTex;
		}
		if (GUI.Button(new Rect(175, 225, 165, 215),Body4)) // same as first.
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Bodies[3]; //mage
			PlayStat.GetComponent<player>().loadGear = true;
			equippedBody = Body4; 
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
			abilityTexture = mageTex;
		}

	}
	void doEquip(int windowID) // this needs to be there for the GUI window, but we currently don't want it to do anything.
	{
	}
	void doHealth(int windowID) // this handles the potion GUI
	{
		if(GUI.Button (new Rect(10,10,40,40),potion) || Input.GetKeyDown(KeyCode.Q) && PlayStat.GetComponent<player>().pHp+50 <= PlayStat.GetComponent<player>().HPCap)
		{ // if button is pressed, or Q is the input. & player health + 50 does not go above max life.
			PlayStat.GetComponent<player>().pHp += 50; // add 50 life.
			potionAmount--; // deduct one potion.
		}
		if(GUI.Button (new Rect(60,10,40,40),abilityTexture) || Input.GetKeyDown(KeyCode.E))
		{
			PlayStat.GetComponent<player>().pCharge += 10;
		}

	}
	void doAbility(int windowID)
	{
		if(GUI.Button (new Rect(10,10,159,59),abilityTexture1))
		{
			abilityTexture1 = abilityTexture;
			PlayStat.GetComponent<player>().pCharge += 10;
			Debug.Log ("PlayerAbil1");
		}
		if(GUI.Button (new Rect(10,79,159,59),abilityTexture2))
		{
			abilityTexture2 = abilityTexture;
			PlayStat.GetComponent<player>().pCharge += 10;
			Debug.Log ("PlayerAbil2");
		}
		if(GUI.Button (new Rect(10,148,159,59),abilityTexture3))
		{
			abilityTexture3 = abilityTexture;
			PlayStat.GetComponent<player>().pCharge += 10;
			Debug.Log ("PlayerAbil3");
		}
	}
}
