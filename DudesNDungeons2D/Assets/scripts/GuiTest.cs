using UnityEngine;
using System.Collections;

public class GuiTest : MonoBehaviour 
{
	Rect backpack = new Rect(20, 20, 350, 450); // create the window box for the backpack.
	Rect equippedGear = new Rect(990, 20, 354, 440); // this is the box for the equipped box
	Rect healthPot = new Rect(10,535,110,60);

	GameObject PlayStat;
	GameObject Gear;

	int potionAmount = 7; // temporary potion counter.
	string potAmountString = "";

	public string stringHP = "HP: ";
	public string stringStr = "Str: ";
	public string stringDex = "Dex: ";
	public string stringInt = "Int: ";
	public string stringCharge = "Charge: ";
	public string stringDam = "Damage: ";	
	
	public Texture Body1;
	public Texture Body2;
	public Texture Body3;
	public Texture Body4;

	public Texture backpackSkin;
	public Texture potion;

	public Texture mageTex;
	public Texture bruteTex;
	public Texture sneakyTex;
	public Texture abilityTexture;
	public Texture defaultTex;

	public Sprite playerSkin1;
	public Sprite playerSkin2;
	public Sprite playerSkin3;
	public Sprite playerSkin4;

	Texture equippedBody1; // these are empty intances that will be swapped in and out to change equipment.

	bool visiGUI; // Boolean that allows for the Gui to be visible/active or not.
					// Use this for initialization
	void Start () 
	{
		PlayStat = GameObject.FindGameObjectWithTag("Player");
		Gear = GameObject.FindGameObjectWithTag("Player");
		visiGUI = false; // initialization as false.

	}
	// Update is called once per frame
	void Update () 
	{
		stringHP = "HP: "+PlayStat.GetComponent<player>().pHp;
		stringStr = "Str: "+PlayStat.GetComponent<player>().pStr;
		stringDex = "Dex: "+PlayStat.GetComponent<player>().pDex;
		stringInt = "Int: "+PlayStat.GetComponent<player>().pInte;
		stringCharge = "Charge: "+PlayStat.GetComponent<player>().pCharge;
		stringDam = "Damage: "+PlayStat.GetComponent<player>().pDamage;	

		if(Input.GetKeyUp(KeyCode.I)) 					
		{
			visiGUI = !visiGUI;
		}
	}
	void OnGUI() // this is like the update function but for GUI's, use this for all GUI related matters.
	{
		if(visiGUI == true) //if true, run code, revealing the GUI.
		{	// rect = GUI.Window(ID , Rect, RunFunction, applyTexture);
			backpack = GUI.Window(0, backpack, DoBackPack, backpackSkin); 
			equippedGear = GUI.Window(1,equippedGear,doEquip, equippedBody1);

			stringStr = GUI.TextField(new Rect(580, 90, 200, 20), stringStr, 25);
			stringDex = GUI.TextField(new Rect(580, 50, 200, 20), stringDex, 25);
			stringInt = GUI.TextField(new Rect(580, 70, 200, 20), stringInt, 25);
			stringDam = GUI.TextField(new Rect(580, 110, 200, 20), stringDam, 25);
		}
		stringHP = GUI.TextField(new Rect(580, 10, 200, 20), stringHP, 25);
		stringCharge = GUI.TextField(new Rect(580, 30, 200, 20), stringCharge, 25);
		healthPot = GUI.Window (2,healthPot, doHealth, potAmountString);
	}
	// this is the RunFunction, it is run whenever it is called in OnGUI().
	void DoBackPack(int windowID) 
	{
		// if ( create Gui Button, new rect(x,y,W,H),Texture);
		if (GUI.Button(new Rect(10, 10, 165, 215),Body1))
		{
			equippedBody1 = Body1; // swap buttons item into the equipped item.
			PlayStat.GetComponent<SpriteRenderer>().sprite = playerSkin1;
			PlayStat.GetComponent<player>().currBody = Gear.GetComponent<GearHandler>().Bodies[0]; // default
			PlayStat.GetComponent<player>().loadGear = true;
			abilityTexture = defaultTex;

		}
		if (GUI.Button(new Rect(175, 10, 165, 215),Body2))
		{
			equippedBody1 = Body2; // swap buttons item into the equipped item.
			PlayStat.GetComponent<SpriteRenderer>().sprite = playerSkin2;
			PlayStat.GetComponent<player>().currBody = Gear.GetComponent<GearHandler>().Bodies[1]; // brute
			PlayStat.GetComponent<player>().loadGear = true;
			abilityTexture = bruteTex;
		}
		if (GUI.Button(new Rect(10, 225, 165, 215),Body3))
		{
			equippedBody1 = Body3; // swap buttons item into the equipped item.
			PlayStat.GetComponent<SpriteRenderer>().sprite = playerSkin3;
			PlayStat.GetComponent<player>().currBody = Gear.GetComponent<GearHandler>().Bodies[2]; // sneaky
			PlayStat.GetComponent<player>().loadGear = true;
			abilityTexture = sneakyTex;
		}
		if (GUI.Button(new Rect(175, 225, 165, 215),Body4))
		{
			equippedBody1 = Body4; // swap buttons item into the equipped item.
			PlayStat.GetComponent<SpriteRenderer>().sprite = playerSkin4;
			PlayStat.GetComponent<player>().currBody = Gear.GetComponent<GearHandler>().Bodies[3]; //mage
			PlayStat.GetComponent<player>().loadGear = true;
			abilityTexture = mageTex;
		}

	}
	void doEquip(int windowID)
	{
	}
	void doHealth(int windowID)
	{
		if(GUI.Button (new Rect(10,10,40,40),potion) || Input.GetKeyDown(KeyCode.Q) && PlayStat.GetComponent<player>().pHp+50 <= PlayStat.GetComponent<player>().HPCap)
		{
			PlayStat.GetComponent<player>().pHp += 50;
			potionAmount--;
		}
		if(GUI.Button (new Rect(60,10,40,40),abilityTexture) || Input.GetKeyDown(KeyCode.E))
		{
			PlayStat.GetComponent<player>().pCharge += 10;
		}
	}
}
