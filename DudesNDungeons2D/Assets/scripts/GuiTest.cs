using UnityEngine;
using System.Collections;

public class GuiTest : MonoBehaviour // This system handles the Interactive User Interface part
{
	Rect backpack = new Rect(10, 10, 250, 230); // create the window box for the backpack.
	Rect equippedGear = new Rect(1180, 10, 177, 220); // this is the box for the equipped box
	Rect healthPot = new Rect(10, 530, 60, 70);
	Rect abilityArea = new Rect (573, 510, 220, 90);
	//Rects for buttons
	public Rect doBackpackBtn1 = new Rect(10, 8, 75, 101);
	public Rect doBackpackBtn2 = new Rect(88, 8, 75, 101);
	public Rect doBackpackBtn3 = new Rect(166, 8, 75, 101);
	public Rect doBackpackBtn4 = new Rect(10, 120, 75, 101);
	public Rect doBackpackBtn5 = new Rect(88, 120, 75, 101);
	public Rect doBackpackBtn6 = new Rect(166, 120, 75, 101);

	Rect potionRect = new Rect(10,20,40,40);
	Rect abilityBtnRect1 = new Rect(10,5, 60, 60);
	Rect abilityBtnRect2 = new Rect(80, 5, 60,60);
	Rect abilityBtnRect3 = new Rect(150,5, 60, 60);

	//Rects for text.
	Rect stringStrRect = new Rect(583, 90, 200, 20);
	Rect stringDexRect = new Rect(583, 50, 200, 20);
	Rect stringIntRect = new Rect(583, 70, 200, 20);
	Rect stringDamRect = new Rect(583, 110, 200, 20);
	Rect stringHPRect = new Rect(583, 10, 200, 20);
	Rect stringChargeRect = new Rect(583, 30, 200, 20);
	Rect abilityRect1 = new Rect(15,65,50,20);
	Rect abilityRect2 = new Rect(85,65,50,20);
	Rect abilityRect3 = new Rect(155,65,50,20);



	float skillRectx, skillRecty;
	//shop GUI
	Rect pBackpack = new Rect(10, 10, 250, 230); // create the window box for the backpack.
	Rect pressedGear = new Rect(1180, 10, 177, 220); // this is the box for the equipped box
	Rect pressedBodyStats = new Rect (1180, 240, 177, 220);
	Rect SkillRect = new Rect(341.5f,284.44f, 350, 350);
	Rect DescriptionRect = new Rect(688, 10, 530, 700);



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
		//Inventory GUI Windows
		Debug.Log ("backpackW before "+backpack.width);
		Debug.Log ("backpackH before "+backpack.height);
		Debug.Log ("backpackX before "+backpack.x);
		Debug.Log ("backpackY before "+backpack.y);

		fitGUIToScreen(ref backpack, true);
		Debug.Log ("backpackW after "+backpack.width);
		Debug.Log ("backpackH after "+backpack.height);
		Debug.Log ("backpackX after "+backpack.x);
		Debug.Log ("backpackY after "+backpack.y);
		fitGUIToScreen(ref equippedGear, true);
		fitGUIToScreen(ref healthPot, true);
		fitGUIToScreen(ref abilityArea, true);
		
		//shop GUI Windows
		fitGUIToScreen(ref pBackpack, true);
		fitGUIToScreen(ref pressedGear, true);
		fitGUIToScreen(ref pressedBodyStats, true);
		fitGUIToScreen(ref SkillRect, true);
		fitGUIToScreen(ref DescriptionRect, true);

	//Rects for buttons
		fitGUIToScreen(ref doBackpackBtn1, true);
		fitGUIToScreen(ref doBackpackBtn2, true);
		fitGUIToScreen(ref doBackpackBtn3, true);
		fitGUIToScreen(ref doBackpackBtn4, true);
		fitGUIToScreen(ref doBackpackBtn5, true);
		fitGUIToScreen(ref doBackpackBtn6, true);

		fitGUIToScreen(ref potionRect, true);
		fitGUIToScreen(ref abilityBtnRect1, true);
		fitGUIToScreen(ref abilityBtnRect2, true);
		fitGUIToScreen(ref abilityBtnRect3, true);
		
	//Rects for text.
		fitGUIToScreen(ref stringStrRect, false);
		fitGUIToScreen(ref stringDexRect, false);
		fitGUIToScreen(ref stringIntRect, false);
		fitGUIToScreen(ref stringDamRect, false);
		fitGUIToScreen(ref stringHPRect, false);
		fitGUIToScreen(ref stringChargeRect, false);

		fitGUIToScreen(ref abilityRect1, false);
		fitGUIToScreen(ref abilityRect2, false);
		fitGUIToScreen(ref abilityRect3, false);


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
	void fitGUIToScreen(ref Rect rectToMod, bool fitSize)
	{
		rectToMod.width = ((rectToMod.width/1366)*Screen.width);
		rectToMod.height = ((rectToMod.height/608)*Screen.height);
		rectToMod.x = ((rectToMod.x/1366)*Screen.width);
		rectToMod.y = ((rectToMod.y/608)*Screen.height);
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
			stringStr = GUI.TextField(stringStrRect, stringStr, 25); // load player stats
			stringDex = GUI.TextField(stringDexRect, stringDex, 25);
			stringInt = GUI.TextField(stringIntRect, stringInt, 25);
			stringDam = GUI.TextField(stringDamRect, stringDam, 25);
			PlayStat.GetComponent<AbilHandler>().canUseAbilities = false;
			Debug.Log (PlayStat.GetComponent<AbilHandler>().canUseAbilities);
		}
		stringHP = GUI.TextField(stringHPRect, stringHP, 25); // these are excluded because charge, potions and HP should always be visible.
		stringCharge = GUI.TextField(stringChargeRect, stringCharge, 25);
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
				skillRectx = (Screen.width/2f)-(SkillRect.width/2);
				skillRecty = (Screen.height/2f)-(SkillRect.width/2);
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
		if (GUI.Button(doBackpackBtn1, button1) && button1 != defaultTex) // button for loading Body 1 (default)
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[0]; // load default stats into currBody.
			PlayStat.GetComponent<player>().loadGear = true; // make sure that the gear is loaded.
			equippedBody = button1; // swap button's body into the equipped body. 
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin; // render the equipped body sprite.
			bodyChange = true;

		}
		if (GUI.Button(doBackpackBtn2, button2)&& button2 != defaultTex) // same as first.
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[1]; // brute
			PlayStat.GetComponent<player>().loadGear = true;
			equippedBody = button2;
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
			bodyChange = true;
		}
		if (GUI.Button(doBackpackBtn3, button3)&& button3 != defaultTex) // same as first.
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[2]; // sneaky
			PlayStat.GetComponent<player>().loadGear = true;
			equippedBody = button3;
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
			bodyChange = true;
		}
		if (GUI.Button(doBackpackBtn4, button4) && button4 != defaultTex) // same as first.
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[3]; //mage
			PlayStat.GetComponent<player>().loadGear = true;
			equippedBody = button4; 
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
			bodyChange = true;
		}
		if (GUI.Button(doBackpackBtn5, button5)&& button5 != defaultTex) // same as first.
		{
			PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[4]; //mage
			PlayStat.GetComponent<player>().loadGear = true;
			equippedBody = button5; 
			PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
			bodyChange = true;
		}
		if (GUI.Button(doBackpackBtn6, button6)&& button6 != defaultTex) // same as first.
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
		if(GUI.Button (potionRect,potion) || Input.GetKeyDown(KeyCode.Q) && potionAmount > 0)
		{ // if button is pressed, or Q is the input. & player health + 50 does not go above max life.
			PlayStat.GetComponent<player>().pHp = PlayStat.GetComponent<player>().HPCap; // add 50 life.
			potionAmount--; // deduct one potion.
		}

	}
	void doAbility(int windowID)
	{	abilLvl1 = GUI.TextField(abilityRect1,abilLvl1,20);
		abilLvl2 = GUI.TextField(abilityRect2,abilLvl2,20);
		abilLvl3 = GUI.TextField(abilityRect3,abilLvl3,20);
		if(GUI.Button (abilityBtnRect1,abilityTexture1))
		{
		}
		if(GUI.Button (abilityBtnRect2,abilityTexture2))
		{
		}
		if(GUI.Button (abilityBtnRect3,abilityTexture3))
		{
		}
	}




}
