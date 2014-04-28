using UnityEngine;
using System.Collections;

public class GuiTest : MonoBehaviour // This system handles the Interactive User Interface part
{
	Rect backpack = new Rect(Screen.width/200, Screen.height/100, Screen.width/5.5f/*350*/, Screen.height/2.5f/*450*/); // create the window box for the backpack.
	Rect equippedGear = new Rect(Screen.width/1.12f, Screen.height/100, Screen.width/11.4f/*177*/, Screen.height/4f/*220*/); // this is the box for the equipped box
	Rect healthPot = new Rect(Screen.width/200, Screen.height-70, 110, 60);
	Rect abilityArea = new Rect ((Screen.width/2f)-110, Screen.height-90, 220, 90);
	float skillRectx, skillRecty;
	//shop
	Rect pBackpack = new Rect(Screen.width/200, Screen.height/100, Screen.width/5.5f/*350*/, Screen.height/2.5f/*450*/); // create the window box for the backpack.
	Rect pressedGear = new Rect(Screen.width/1.12f, Screen.height/100, Screen.width/11.4f/*177*/, Screen.height/4f/*220*/); // this is the box for the equipped box
	Rect pressedBodyStats = new Rect (Screen.width/1.12f, (Screen.height/100)+((Screen.height/4f)+10), Screen.width/11.4f/*177*/, (Screen.height/4f)+10/*220*/);
	Rect SkillRect = new Rect(Screen.width/4f, (Screen.height/2.7f), 350, 350);

	Rect DescriptionRect = new Rect(((Screen.width/4f)*2)+5, 10, 530, 700);
	GameObject PlayStat;
	string abilLvl1;
	string abilLvl2;
	string abilLvl3;

	public int potionAmount = 3; // temporary potion counter.
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

	public Texture defaultTex;
	public Texture button1;
	public Texture button2;
	public Texture button3;
	public Texture button4;
	public Texture button5;
	public Texture button6;
	
	public Texture abilityTexture1;
	public Texture abilityTexture2;
	public Texture abilityTexture3;
	public bool bodyChange = true;



	Texture equippedBody; // this is the empty intance that will be swapped in and out to change equipment.

	public bool visiGUI; // Boolean that allows for the Gui to be visible/active or not.

	void Start () // Use this for initialization
	{
		button1 = defaultTex;
		button2 = defaultTex;
		button3 = defaultTex;
		button4 = defaultTex;
		button5 = defaultTex;
		button6 = defaultTex;
		PlayStat = GameObject.FindGameObjectWithTag("Player"); // find player.
		visiGUI = false; // initialization as false.

		abilLvl1 = "NA";
     	abilLvl2 = "NA";
    	abilLvl3 = "NA";
	}
	// Update is called once per frame
	void Update () 
	{
		SkillRect.x = skillRectx;
		SkillRect.y = skillRecty;
		if(PlayStat.GetComponent<LootHandler>().hasLooted || GetComponent<ShopCode>().hasSold)
		{
			if(PlayStat.GetComponent<GearHandler>().Backpack[0] != null)
				button1 = PlayStat.GetComponent<GearHandler>().Backpack[0].skinTex;
			if(PlayStat.GetComponent<GearHandler>().Backpack[1] != null)
				button2 = PlayStat.GetComponent<GearHandler>().Backpack[1].skinTex;
			if(PlayStat.GetComponent<GearHandler>().Backpack[2] != null)
				button3 = PlayStat.GetComponent<GearHandler>().Backpack[2].skinTex;
			if(PlayStat.GetComponent<GearHandler>().Backpack[3] != null)
				button4 = PlayStat.GetComponent<GearHandler>().Backpack[3].skinTex;
			if(PlayStat.GetComponent<GearHandler>().Backpack[4] != null)
				button5 = PlayStat.GetComponent<GearHandler>().Backpack[4].skinTex;
			if(PlayStat.GetComponent<GearHandler>().Backpack[5] != null)
				button6 = PlayStat.GetComponent<GearHandler>().Backpack[5].skinTex;

			if(PlayStat.GetComponent<GearHandler>().Backpack[0] == null)
				button1 = defaultTex;
			if(PlayStat.GetComponent<GearHandler>().Backpack[1] == null)
				button2 = defaultTex;
			if(PlayStat.GetComponent<GearHandler>().Backpack[2] == null)
				button3 = defaultTex;
			if(PlayStat.GetComponent<GearHandler>().Backpack[3] == null)
				button4 = defaultTex;
			if(PlayStat.GetComponent<GearHandler>().Backpack[4] == null)
				button5 = defaultTex;
			if(PlayStat.GetComponent<GearHandler>().Backpack[5] == null)
				button6 = defaultTex;
			PlayStat.GetComponent<LootHandler>().hasLooted = false;
			GetComponent<ShopCode>().hasSold = false;
		}

		if(bodyChange)
		{
			if(PlayStat.GetComponent<player>().currBody.name == "Default")
			{
				abilityTexture1 = defaultTex;
				abilityTexture2 = defaultTex;
				abilityTexture3 = defaultTex;
				abilLvl1 = "NA";
				abilLvl2 = "NA";
				abilLvl3 = "NA";
			}

			else if(PlayStat.GetComponent<player>().currBody.name == "Brute")
			{
				abilityTexture1 = GetComponent<ShopCode>().GroundSlamSkill;
				abilityTexture2 = GetComponent<ShopCode>().RegenSkill;
				abilityTexture3 = GetComponent<ShopCode>().RageSkill;
				abilLvl1 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().groundSlamLevel;
				abilLvl2 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().regenerateLevel;
				abilLvl3 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().rageLevel;
			}

			else if(PlayStat.GetComponent<player>().currBody.name == "Sneaky")
			{
				abilityTexture1 = GetComponent<ShopCode>().TeleportSkill;
				abilityTexture2 = GetComponent<ShopCode>().ShadowStabSkill;
				abilityTexture3 = GetComponent<ShopCode>().AccuteDexterity;
				abilLvl1 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().tpLevel;
				abilLvl2 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().sSLevel;
				abilLvl3 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().eAndASLevel;
			}

			else if(PlayStat.GetComponent<player>().currBody.name == "Magus")
			{
				abilityTexture1 = GetComponent<ShopCode>().ForcePush;
				abilityTexture2 = GetComponent<ShopCode>().StoneSkin;
				abilityTexture3 = GetComponent<ShopCode>().FlameBurst;
				abilLvl1 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().knockbackLevel;
				abilLvl2 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().shieldLevel;
				abilLvl3 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().flameThrowerLevel;
			}
			bodyChange = false;
		}

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
			equippedGear = GUI.Window(1, equippedGear,doEquip, equippedBody); // load GUI window for the equipped body.
			stringStr = GUI.TextField(new Rect((Screen.width/2)-100, 90, 200, 20), stringStr, 25); // load player stats
			stringDex = GUI.TextField(new Rect((Screen.width/2)-100, 50, 200, 20), stringDex, 25);
			stringInt = GUI.TextField(new Rect((Screen.width/2)-100, 70, 200, 20), stringInt, 25);
			stringDam = GUI.TextField(new Rect((Screen.width/2)-100, 110, 200, 20), stringDam, 25);
			PlayStat.GetComponent<AbilHandler>().canUseAbilities = false;
			Debug.Log (PlayStat.GetComponent<AbilHandler>().canUseAbilities);
		}
		stringHP = GUI.TextField(new Rect((Screen.width/2)-100, 10, 200, 20), stringHP, 25); // these are excluded because charge, potions and HP should always be visible.
		stringCharge = GUI.TextField(new Rect((Screen.width/2)-100, 30, 200, 20), stringCharge, 25);
		healthPot = GUI.Window (2, healthPot, doHealth, potAmountString);
		abilityArea = GUI.Window (3,abilityArea, doAbility, backpackSkin);


		if(GetComponent<ShopCode>().visiShop == true)
		{
			pressedBodyStats = GUI.Window(6,pressedBodyStats, GetComponent<ShopCode>().showBodyStats, GetComponent<ShopCode>().backpackSkin);
			pBackpack = GUI.Window(4, pBackpack, GetComponent<ShopCode>().pDoBackPack, GetComponent<ShopCode>().backpackSkin); //load GUI window for Backpack
			pressedGear = GUI.Window(5,pressedGear,GetComponent<ShopCode>().pressedEquip, GetComponent<ShopCode>().pressedBodyTex); // load GUI window for the equipped body.
			SkillRect = GUI.Window (7, SkillRect, GetComponent<ShopCode>().displaySkills, GetComponent<ShopCode>().backpackSkin);
			PlayStat.GetComponent<AbilHandler>().canUseAbilities = false;

			if(GetComponent<ShopCode>().showDescription)
			{
				skillRectx = Screen.width/4f;
				skillRecty = Screen.height/2.7f;
				DescriptionRect = GUI.Window (8, DescriptionRect, GetComponent<ShopCode>().skillDescriptionload, GetComponent<ShopCode>().SkillDescription);
			}
			else
			{
				skillRectx = (Screen.width/2f)-175;
				skillRecty = (Screen.height/2f)-175;
			}
			//Render shop gui
		}
		if(!GetComponent<ShopCode>().visiShop && !visiGUI)
		{
			PlayStat.GetComponent<AbilHandler>().canUseAbilities = true;
		}

	}
	// this is the RunFunction, it is run whenever it is called in OnGUI().
	void DoBackPack(int windowID) // this function handles backpack buttons
	{
		// if ( create Gui Button, new rect(x,y,W,H),Texture);
		if (GUI.Button(new Rect(Screen.width/150, Screen.height/75, Screen.width/18/*165*/, Screen.height/6/*215*/), button1) && button1 != defaultTex) // button for loading Body 1 (default)
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[0]; // load default stats into currBody.
			PlayStat.GetComponent<player>().loadGear = true; // make sure that the gear is loaded.
			equippedBody = button1; // swap button's body into the equipped body. 
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin; // render the equipped body sprite.
			bodyChange = true;

		}
		if (GUI.Button(new Rect(Screen.width/15.5f, Screen.height/75, Screen.width/18/*165*/, Screen.height/6/*215*/), button2)&& button2 != defaultTex) // same as first.
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[1]; // brute
			PlayStat.GetComponent<player>().loadGear = true;
			equippedBody = button2;
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
			bodyChange = true;
		}
		if (GUI.Button(new Rect(Screen.width/8.17f, Screen.height/75, Screen.width/18/*165*/, Screen.height/6/*215*/), button3)&& button3 != defaultTex) // same as first.
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[2]; // sneaky
			PlayStat.GetComponent<player>().loadGear = true;
			equippedBody = button3;
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
			bodyChange = true;
		}
		if (GUI.Button(new Rect(Screen.width/150, Screen.height/5, Screen.width/18/*165*/, Screen.height/6/*215*/), button4) && button4 != defaultTex) // same as first.
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[3]; //mage
			PlayStat.GetComponent<player>().loadGear = true;
			equippedBody = button4; 
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
			bodyChange = true;
		}
		if (GUI.Button(new Rect(Screen.width/15.5f, Screen.height/5, Screen.width/18/*165*/, Screen.height/6/*215*/), button5)&& button5 != defaultTex) // same as first.
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[4]; //mage
			PlayStat.GetComponent<player>().loadGear = true;
			equippedBody = button5; 
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
			bodyChange = true;
		}
		if (GUI.Button(new Rect(Screen.width/8.17f, Screen.height/5, Screen.width/18/*165*/, Screen.height/6/*215*/), button6)&& button6 != defaultTex) // same as first.
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[5]; //mage
			PlayStat.GetComponent<player>().loadGear = true;
			equippedBody = button6; 
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
			bodyChange = true;
		}
	}
	void doEquip(int windowID) // this needs to be there for the GUI window, but we currently don't want it to do anything.
	{
	}
	void doHealth(int windowID) // this handles the potion GUI
	{
		if(GUI.Button (new Rect(10,10,40,40),potion) || Input.GetKeyDown(KeyCode.Q) && potionAmount > 0)
		{ // if button is pressed, or Q is the input. & player health + 50 does not go above max life.
			PlayStat.GetComponent<player>().pHp = PlayStat.GetComponent<player>().HPCap; // add 50 life.
			potionAmount--; // deduct one potion.
		}

	}
	void doAbility(int windowID)
	{	abilLvl1 = GUI.TextField(new Rect(15,65,50,20),abilLvl1,20);
		abilLvl2 = GUI.TextField(new Rect(85,65,50,20),abilLvl2,20);
		abilLvl3 = GUI.TextField(new Rect(155,65,50,20),abilLvl3,20);
		if(GUI.Button (new Rect(10,5, 60, 60),abilityTexture1))
		{
		}
		if(GUI.Button (new Rect(80, 5, 60,60),abilityTexture2))
		{
		}
		if(GUI.Button (new Rect(150,5, 60, 60),abilityTexture3))
		{
		}
	}




}
