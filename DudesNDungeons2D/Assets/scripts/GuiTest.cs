using UnityEngine;
using System.Collections;

public class GuiTest : MonoBehaviour // This system handles the Interactive User Interface part
{
	Rect backpack = new Rect(10, 12.6f, 250, 230); // create the window boxes for inventory screen.
	Rect equippedGear = new Rect(1180, 12.6f, 177, 277.9f);
	Rect healthPot = new Rect(10, 669.47f, 60, 88.42f);
	Rect abilityArea = new Rect (573, 627.21f, 220, 180.68f);

	public bool inTutorial = false; // if in tutorial some stuff should happen, this boolean makes sure we can control it.
	public AudioClip backpackSound; // this is the sound of the backpack opening.

	//Rects for buttons in GUI and Shop screen.
	public Rect doBackpackBtn1 = new Rect(10, 10.1f, 75, 127.58f);
	public Rect doBackpackBtn2 = new Rect(88, 10.1f, 75, 127.58f);
	public Rect doBackpackBtn3 = new Rect(166, 10.1f, 75, 127.58f);
	public Rect doBackpackBtn4 = new Rect(10, 151.57f, 75, 127.58f);
	public Rect doBackpackBtn5 = new Rect(88, 151.57f, 75, 127.58f);
	public Rect doBackpackBtn6 = new Rect(166, 151.57f, 75, 127.58f);

	// always rendered GUI's for user interface.
	Rect potionRect = new Rect(10,25.26f,40,50.5f);
	Rect abilityBtnRect1 = new Rect(10,34.32f, 60, 75.8f);
	Rect abilityBtnRect2 = new Rect(80, 34.32f, 60,75.8f);
	Rect abilityBtnRect3 = new Rect(150,34.32f, 60, 75.8f);

	//Rects for text both user interface and inventory screen.
	Rect stringHPRect = new Rect(583, 10, 200, 25.26f);
	Rect stringChargeRect = new Rect(583, 30, 200, 25.26f);
	Rect stringDexRect = new Rect(583, 70, 200, 25.26f);
	Rect stringIntRect = new Rect(583, 90, 200, 25.26f);
	Rect stringStrRect = new Rect(583, 50, 200, 25.26f);
	Rect stringDamRect = new Rect(583, 110, 200, 25.26f);
	Rect lootTextRect = new Rect(650, 442.1f, 80, 25.26f);

	// rects for user interface
	Rect abilRect1 = new Rect(10, 6.3f, 60, 25.26f);
	Rect abilRect2 = new Rect(80, 6.3f, 60, 25.26f);
	Rect abilRect3 = new Rect(150, 6.3f, 60, 25.26f);

	Rect shrineTextRect = new Rect(Screen.width/2-65, 442.1f, 130, 25.26f); // for tutorial.

	//For user interface.
	Rect abilityRect1 = new Rect(15,112.1f,50,25.3f);
	Rect abilityRect2 = new Rect(85,112.1f,50,25.3f);
	Rect abilityRect3 = new Rect(155,112.1f,50,25.3f);



	float skillRectx, skillRecty; // modifies some shop interface based on skill descriptions menu open or closed
	//shop GUI windows.
	Rect pBackpack = new Rect(10, 12.6f, 250, 230); // create the window box for the backpack.
	Rect pressedGear = new Rect(1180, 12.6f, 177, 277.9f); // this is the box for the equipped box
	Rect pressedBodyStats = new Rect (1180, 303, 177, 290);
	Rect SkillRect = new Rect(341.5f,264.44f, 350, 500);
	Rect DescriptionRect = new Rect(688, 12.6f, 530, 700);


	GameObject[] enemies; // creates an array for finding enemies.
	GameObject[] Shops; // creates and array for finding shops, this is crucial for the shop GUI.

	
	GameObject PlayStat;
	//User interface related text.
	string abilLvl1;
	string abilLvl2;
	string abilLvl3;

	public int potionAmount = 3; // potion counter.
	string potAmountString = ""; // amount of potions in string.

	public string stringHP = "HP: "; // these will display the player Stats in text boxes on inventory screen. 
	public string stringStr = "Str: "; // HP and charge always present.
	public string stringDex = "Dex: ";
	public string stringInt = "Int: ";
	public string stringCharge = "Charge: ";
	public string stringDam = "Damage: ";	
	
	public Texture Body1; // These textures allow for user feedback of what body type the player is selecting.
	public Texture Body2;
	public Texture Body3;
	public Texture Body4;

	public Texture backpackSkin; // this is just to allow for a none texture on some windows.
	public Texture potion;

	public Texture mageTex; // these textures are ability textures.
	public Texture bruteTex;
	public Texture sneakyTex;

	public Texture defaultTex;
	//Button textures to be loaded in and out.
	public Texture button1;
	public Texture button2;
	public Texture button3;
	public Texture button4;
	public Texture button5;
	public Texture button6;
	//User interface related textures.
	public Texture abilityTexture1;
	public Texture abilityTexture2;
	public Texture abilityTexture3;

	public bool bodyChange = true;

	public AudioClip clickSound;
	public AudioClip coinSound;

	Texture equippedBody; // this is the empty intance that will be swapped in and out to change equipment.

	public bool visiGUI; // Boolean that allows for the Gui to be visible/active or not.

	void Start () // Use this for initialization
	{
		enemies = GameObject.FindGameObjectsWithTag("Enemy");
		Shops = GameObject.FindGameObjectsWithTag("Shop");

		//Inventory GUI Windows
		fitGUIToScreen(ref backpack, true, true); // this function fits the GUI 
		fitGUIToScreen(ref equippedGear, true, true); // to screen based on the concept of homographic coordinates.
		fitGUIToScreen(ref healthPot, true, true);
		fitGUIToScreen(ref abilityArea, true, true);
		
		//shop GUI Windows
		fitGUIToScreen(ref pBackpack, true, true);
		fitGUIToScreen(ref pressedGear, true, true);
		fitGUIToScreen(ref pressedBodyStats, true, true);
		fitGUIToScreen(ref SkillRect, true, true);
		fitGUIToScreen(ref DescriptionRect, true, true);

		//Rects for buttons
		fitGUIToScreen(ref doBackpackBtn1, true, true);
		fitGUIToScreen(ref doBackpackBtn2, true, true);
		fitGUIToScreen(ref doBackpackBtn3, true, true);
		fitGUIToScreen(ref doBackpackBtn4, true, true);
		fitGUIToScreen(ref doBackpackBtn5, true, true);
		fitGUIToScreen(ref doBackpackBtn6, true, true);

		fitGUIToScreen(ref potionRect, true, true);
		fitGUIToScreen(ref abilityBtnRect1, true, true);
		fitGUIToScreen(ref abilityBtnRect2, true, true);
		fitGUIToScreen(ref abilityBtnRect3, true, true);
		
		//Rects for text.
		fitGUIToScreen(ref stringStrRect, false, false);
		fitGUIToScreen(ref stringDexRect, false, false);
		fitGUIToScreen(ref stringIntRect, false, false);
		fitGUIToScreen(ref stringDamRect, false, false);
		fitGUIToScreen(ref stringHPRect, false, false);
		fitGUIToScreen(ref stringChargeRect, false, false);

		fitGUIToScreen(ref lootTextRect, false, true);

		fitGUIToScreen(ref abilityRect1, true, true);
		fitGUIToScreen(ref abilityRect2, true, true);
		fitGUIToScreen(ref abilityRect3, true, true);
		fitGUIToScreen(ref abilRect1, true, true);
		fitGUIToScreen(ref abilRect2, true, true);
		fitGUIToScreen(ref abilRect3, true, true);

		button1 = defaultTex;
		button2 = defaultTex;
		button3 = defaultTex;
		button4 = defaultTex;
		button5 = defaultTex;
		button6 = defaultTex;

		PlayStat = GameObject.FindGameObjectWithTag("Player"); // find player.
		visiGUI = false; // initialization as false.

		abilLvl1 = "NA"; // if default, there should be no abilities.
     	abilLvl2 = "NA";
    	abilLvl3 = "NA";
	}
	void fitGUIToScreen(ref Rect rectToMod, bool fitSize, bool adjustY) // game made on a computer with 1366x768 res,
																		//unit remade this into 1366x608, all rects have been recalculated 
																		//from Y 608 to Y 768 to keep the stretch proportions.
	{
		if(fitSize) // some objects like text does not need to be size changed.
		{
			rectToMod.width = ((rectToMod.width/1366)*Screen.width);
			rectToMod.height = ((rectToMod.height/768)*Screen.height);
		}
		rectToMod.x = ((rectToMod.x/1366)*Screen.width);
		if(adjustY) // some objects does not need to be adjusted on the Y scale.
		{
			rectToMod.y = ((rectToMod.y/768)*Screen.height);
		}
	}
	// Update is called once per frame
	void Update () 
	{

		SkillRect.x = skillRectx; // always update these to detect changes.
		SkillRect.y = skillRecty;
		foreach(GameObject s in Shops)
		{
			if(PlayStat.GetComponent<LootHandler>().hasLooted || s.GetComponent<ShopCode>().hasSold) // everyTime we loot or sell an object this list should be updated.
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
					button5 = PlayStat.GetComponent<GearHandler>().Backpack[4].skinTex; // if null then the object has been deleted/sold 
				if(PlayStat.GetComponent<GearHandler>().Backpack[5] != null)
					button6 = PlayStat.GetComponent<GearHandler>().Backpack[5].skinTex; // if not null the system should render textures.

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
				s.GetComponent<ShopCode>().hasSold = false;
			}

			if(bodyChange) // if a change in bodies ocurr, update the ability textures as per written below.
			{
				if(PlayStat.GetComponent<player>().currBody.name == "Default")
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
					s.GetComponent<ShopCode>().hasSold = false;
				}
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
					abilityTexture1 = s.GetComponent<ShopCode>().GroundSlamSkill;
					abilityTexture2 = s.GetComponent<ShopCode>().RageSkill;
					abilityTexture3 = s.GetComponent<ShopCode>().RegenSkill;
					abilLvl1 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().groundSlamLevel;
					abilLvl2 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().rageLevel;
					abilLvl3 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().regenerateLevel;
				}

				else if(PlayStat.GetComponent<player>().currBody.name == "Sneaky")
				{
					abilityTexture1 = s.GetComponent<ShopCode>().TeleportSkill;
					abilityTexture2 = s.GetComponent<ShopCode>().ShadowStabSkill;
					abilityTexture3 = s.GetComponent<ShopCode>().AccuteDexterity;
					abilLvl1 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().tpLevel;
					abilLvl2 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().sSLevel;
					abilLvl3 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().eAndASLevel;
				}

				else if(PlayStat.GetComponent<player>().currBody.name == "Magus")
				{
					abilityTexture1 = s.GetComponent<ShopCode>().ForcePush;
					abilityTexture2 = s.GetComponent<ShopCode>().StoneSkin;
					abilityTexture3 = s.GetComponent<ShopCode>().FlameBurst;
					abilLvl1 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().flameThrowerLevel;
					abilLvl2 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().shieldLevel;
					abilLvl3 = "Lvl: "+PlayStat.GetComponent<AbilHandler>().knockbackLevel;
				}
				bodyChange = false;
			}
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
			audio.clip = backpackSound;
			audio.Play();
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
			PlayStat.GetComponent<AbilHandler>().canUseAbilities = false; // makes sure the player doesn't do weird things when in inventory or shop.
		}
		stringHP = GUI.TextField(stringHPRect, stringHP, 25); // these are excluded from if(visiGUI) because charge, potions and HP should always be visible.
		stringCharge = GUI.TextField(stringChargeRect, stringCharge, 25);
		healthPot = GUI.Window (2, healthPot, doHealth, potAmountString);
		abilityArea = GUI.Window (3,abilityArea, doAbility, backpackSkin); // informs the player what his skills are, what lvls they are and what buttons they are.
		if(PlayStat.GetComponent<LootHandler>().DisplayText) // UI info for if loot or miss.
		{
			string loot = "Body Looted";
			loot = GUI.TextField(lootTextRect, loot, 20);
		}
		if(GetComponent<CombatHandler>().showMiss)
		{
			string loot = "Missed";
			loot = GUI.TextField(lootTextRect, loot, 20);
		}

		if(inTutorial) // only relevant if the player is in the tutorial.
		{
		//Tutorial components to tell to press e to actiavte shrines or shop
		if(GetComponent<TutorialHandler>().dmgClose)
		{
			string shrine = "Press E to activate";
			shrine = GUI.TextField(shrineTextRect, shrine, 50);
		}
		if(GetComponent<TutorialHandler>().healClose)
		{
			string shrine = "Press E to activate";
			shrine = GUI.TextField(shrineTextRect, shrine, 50);
		}
		if(GetComponent<TutorialHandler>().shopClose)
		{
			string shrine = "Press E to activate";
			shrine = GUI.TextField(shrineTextRect, shrine, 50);
		}
		if(GetComponent<TutorialHandler>().exploClose)
		{
			string shrine = "Press E to activate";
			shrine = GUI.TextField(shrineTextRect, shrine, 50);
		}
		if(GetComponent<TutorialHandler>().invulClose)
		{
			string shrine = "Press E to activate";
			shrine = GUI.TextField(shrineTextRect, shrine, 50);
		}
		if(GetComponent<TutorialHandler>().enemyClose)
		{
			string firstEnemy = "Left click to attack, right click to use ability(only if skill lvl > 0)";
			firstEnemy = GUI.TextField(shrineTextRect, firstEnemy, 150);
		}
	}
		//Each time a enemy misses he will get a box above him saying "Missed Player"
		foreach(GameObject e in enemies)
		{
			if(e != null)
			{
				if(e.GetComponent<FollowPlayerAI>().showMissedPlayer)
				{
					string miss = "Missed Player";
					float displacement = e.transform.localScale.x;
					Vector2 x = Camera.main.WorldToScreenPoint(new Vector3((e.transform.position.x-displacement),e.transform.position.y,e.transform.position.z));
					miss = GUI.TextField(new Rect ((x.x), (442.1f/768)*Screen.height, 90, 20), miss, 50);
				}
			}
		}
		foreach(GameObject s in Shops)
		{
			if(s != null && visiGUI) // make sure you can't have both shop and inventory active at the same time.
			{
				s.GetComponent<ShopCode>().visiShop = false;
			}
			if(s.GetComponent<ShopCode>().visiShop == true) // like visiGUI this handles the Shop.
			{
				visiGUI = false; // make sure you can't have both inventory and shop open at the same time.
				pressedBodyStats = GUI.Window(6,pressedBodyStats, s.GetComponent<ShopCode>().showBodyStats, s.GetComponent<ShopCode>().backpackSkin);
				pBackpack = GUI.Window(4, pBackpack, DoBackPack, s.GetComponent<ShopCode>().backpackSkin); //load GUI window for Backpack
				pressedGear = GUI.Window(5,pressedGear, s.GetComponent<ShopCode>().pressedEquip, s.GetComponent<ShopCode>().pressedBodyTex); // load GUI window for the equipped body.
				SkillRect = GUI.Window (7, SkillRect, s.GetComponent<ShopCode>().displaySkills, s.GetComponent<ShopCode>().backpackSkin);
				stringStr = GUI.TextField(stringStrRect, stringStr, 25); // load player stats
				stringDex = GUI.TextField(stringDexRect, stringDex, 25);
				stringInt = GUI.TextField(stringIntRect, stringInt, 25);
				stringDam = GUI.TextField(stringDamRect, stringDam, 25);
				PlayStat.GetComponent<AbilHandler>().canUseAbilities = false;

				if(s.GetComponent<ShopCode>().showDescription)
				{
					skillRectx = Screen.width/2f-(SkillRect.width);
					skillRecty = Screen.height/2f-(SkillRect.height/2);
					DescriptionRect = GUI.Window (8, DescriptionRect, s.GetComponent<ShopCode>().skillDescriptionload, s.GetComponent<ShopCode>().SkillDescription);
				}
				else// modifies the skillRect's position based on the DescriptionRect being on or of.
				{
					skillRectx = (Screen.width/2f)-(SkillRect.width/2);
					skillRecty = (Screen.height/2f)-(SkillRect.height/2);
				}
				//Render shop gui
			}
		
			if(!s.GetComponent<ShopCode>().visiShop && !visiGUI) // if inventory or shop is open make sure we can't attack or use abilities.
				PlayStat.GetComponent<AbilHandler>().canUseAbilities = true;
			else 
			{
				PlayStat.GetComponent<AbilHandler>().canUseAbilities = false;
			}
		}

	}
	// this is the RunFunction, it is run whenever it is called in OnGUI().
	void DoBackPack(int windowID) // this function handles backpack buttons
	{
		GameObject currentShop = null;
		foreach(GameObject s in Shops)
		{
			if(s.GetComponent<ShopCode>().visiShop == true)
			{
				currentShop = s;
			}
		}
		// if ( create Gui Button, new rect(x,y,W,H),Texture);
		if (GUI.Button(doBackpackBtn1, button1) && button1 != defaultTex) // button for loading Body 1 (default)
		{
			if(visiGUI) // if visigui is active, have inventory properties available.
			{
				audio.clip = clickSound;
				audio.Play ();
				PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[0]; // load default stats into currBody.
				PlayStat.GetComponent<player>().loadGear = true; // make sure that the gear is loaded.
				equippedBody = button1; // swap button's body into the equipped body. 
				PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin; // render the equipped body sprite.
				bodyChange = true;
			}
			if(currentShop.GetComponent<ShopCode>().visiShop) // if shop is open have shop properties available.
			{
				audio.clip = clickSound;
				audio.Play ();
				currentShop.GetComponent<ShopCode>().pressedBodyTex = button1;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.name = PlayStat.GetComponent<GearHandler>().Backpack[0].name;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gHp = PlayStat.GetComponent<GearHandler>().Backpack[0].gHp;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gStr = PlayStat.GetComponent<GearHandler>().Backpack[0].gStr;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gDex = PlayStat.GetComponent<GearHandler>().Backpack[0].gDex;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gInte = PlayStat.GetComponent<GearHandler>().Backpack[0].gInte;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gCharge = PlayStat.GetComponent<GearHandler>().Backpack[0].gCharge;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gDamage = PlayStat.GetComponent<GearHandler>().Backpack[0].gDamage;
				currentShop.GetComponent<ShopCode>().posInBackpack = 0;
			}

		}
		if (GUI.Button(doBackpackBtn2, button2)&& button2 != defaultTex) // same as first.
		{
			if(visiGUI)
			{
				audio.clip = clickSound;
				audio.Play ();
				PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[1]; // brute
				PlayStat.GetComponent<player>().loadGear = true;
				equippedBody = button2;
				PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
				bodyChange = true;

			}
			if(currentShop.GetComponent<ShopCode>().visiShop)
			{
				audio.clip = clickSound;
				audio.Play ();
				currentShop.GetComponent<ShopCode>().pressedBodyTex = button1;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.name = PlayStat.GetComponent<GearHandler>().Backpack[1].name;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gHp = PlayStat.GetComponent<GearHandler>().Backpack[1].gHp;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gStr = PlayStat.GetComponent<GearHandler>().Backpack[1].gStr;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gDex = PlayStat.GetComponent<GearHandler>().Backpack[1].gDex;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gInte = PlayStat.GetComponent<GearHandler>().Backpack[1].gInte;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gCharge = PlayStat.GetComponent<GearHandler>().Backpack[1].gCharge;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gDamage = PlayStat.GetComponent<GearHandler>().Backpack[1].gDamage;
				currentShop.GetComponent<ShopCode>().posInBackpack = 1;
			}
		}
		if (GUI.Button(doBackpackBtn3, button3)&& button3 != defaultTex) // same as first.
		{
			if(visiGUI)
			{
				audio.clip = clickSound;
				audio.Play ();
				PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[2]; // sneaky
				PlayStat.GetComponent<player>().loadGear = true;
				equippedBody = button3;
				PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
				bodyChange = true;

			}
			if(currentShop.GetComponent<ShopCode>().visiShop)
			{
				audio.clip = clickSound;
				audio.Play ();
				currentShop.GetComponent<ShopCode>().pressedBodyTex = button1;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.name = PlayStat.GetComponent<GearHandler>().Backpack[2].name;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gHp = PlayStat.GetComponent<GearHandler>().Backpack[2].gHp;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gStr = PlayStat.GetComponent<GearHandler>().Backpack[2].gStr;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gDex = PlayStat.GetComponent<GearHandler>().Backpack[2].gDex;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gInte = PlayStat.GetComponent<GearHandler>().Backpack[2].gInte;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gCharge = PlayStat.GetComponent<GearHandler>().Backpack[2].gCharge;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gDamage = PlayStat.GetComponent<GearHandler>().Backpack[2].gDamage;
				currentShop.GetComponent<ShopCode>().posInBackpack = 2;
			}
		}
		if (GUI.Button(doBackpackBtn4, button4) && button4 != defaultTex) // same as first.
		{
			if(visiGUI)
			{
				audio.clip = clickSound;
				audio.Play ();
				PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[3]; //mage
				PlayStat.GetComponent<player>().loadGear = true;
				equippedBody = button4; 
				PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
				bodyChange = true;

			}
			if(currentShop.GetComponent<ShopCode>().visiShop)
			{
				audio.clip = clickSound;
				audio.Play ();
				currentShop.GetComponent<ShopCode>().pressedBodyTex = button1;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.name = PlayStat.GetComponent<GearHandler>().Backpack[3].name;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gHp = PlayStat.GetComponent<GearHandler>().Backpack[3].gHp;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gStr = PlayStat.GetComponent<GearHandler>().Backpack[3].gStr;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gDex = PlayStat.GetComponent<GearHandler>().Backpack[3].gDex;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gInte = PlayStat.GetComponent<GearHandler>().Backpack[3].gInte;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gCharge = PlayStat.GetComponent<GearHandler>().Backpack[3].gCharge;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gDamage = PlayStat.GetComponent<GearHandler>().Backpack[3].gDamage;
				currentShop.GetComponent<ShopCode>().posInBackpack = 3;

			}
		}
		if (GUI.Button(doBackpackBtn5, button5)&& button5 != defaultTex) // same as first.
		{
			if(visiGUI)
			{
				audio.clip = clickSound;
				audio.Play ();
				PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[4]; //mage
				PlayStat.GetComponent<player>().loadGear = true;
				equippedBody = button5; 
				PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
				bodyChange = true;

			}
			if(currentShop.GetComponent<ShopCode>().visiShop)
			{
				audio.clip = clickSound;
				audio.Play ();
				currentShop.GetComponent<ShopCode>().pressedBodyTex = button1;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.name = PlayStat.GetComponent<GearHandler>().Backpack[4].name;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gHp = PlayStat.GetComponent<GearHandler>().Backpack[4].gHp;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gStr = PlayStat.GetComponent<GearHandler>().Backpack[4].gStr;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gDex = PlayStat.GetComponent<GearHandler>().Backpack[4].gDex;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gInte = PlayStat.GetComponent<GearHandler>().Backpack[4].gInte;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gCharge = PlayStat.GetComponent<GearHandler>().Backpack[4].gCharge;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gDamage = PlayStat.GetComponent<GearHandler>().Backpack[4].gDamage;
				currentShop.GetComponent<ShopCode>().posInBackpack = 4;
			}
		}
		if (GUI.Button(doBackpackBtn6, button6)&& button6 != defaultTex) // same as first.
		{
			if(visiGUI)
			{
				audio.clip = clickSound;
				audio.Play ();
				PlayStat.GetComponent<player>().currBody = PlayStat.GetComponent<GearHandler>().Backpack[5]; //mage
				PlayStat.GetComponent<player>().loadGear = true;
				equippedBody = button6; 
				PlayStat.GetComponent<SpriteRenderer>().sprite = PlayStat.GetComponent<player>().currBody.skin;
				bodyChange = true;
			}
			if(currentShop.GetComponent<ShopCode>().visiShop)
			{
				audio.clip = clickSound;
				audio.Play ();
				currentShop.GetComponent<ShopCode>().pressedBodyTex = button1;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.name = PlayStat.GetComponent<GearHandler>().Backpack[5].name;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gHp = PlayStat.GetComponent<GearHandler>().Backpack[5].gHp;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gStr = PlayStat.GetComponent<GearHandler>().Backpack[5].gStr;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gDex = PlayStat.GetComponent<GearHandler>().Backpack[5].gDex;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gInte = PlayStat.GetComponent<GearHandler>().Backpack[5].gInte;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gCharge = PlayStat.GetComponent<GearHandler>().Backpack[5].gCharge;
				currentShop.GetComponent<ShopCode>().pressedBodyObject.gDamage = PlayStat.GetComponent<GearHandler>().Backpack[5].gDamage;
				currentShop.GetComponent<ShopCode>().posInBackpack = 5;
			}
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
	void doAbility(int windowID) // this is the UI that shows what abilities are available and on what buttons.
	{	
		abilLvl1 = GUI.TextField(abilityRect1,abilLvl1,20);
		abilLvl2 = GUI.TextField(abilityRect2,abilLvl2,20);
		abilLvl3 = GUI.TextField(abilityRect3,abilLvl3,20);

		string abilBtn1 = " ";
		string abilBtn2 = " ";
		string abilBtn3 = " ";


		if(PlayStat.GetComponent<player>().currBody.name == "Default")
		{
			abilBtn1 = "No Abil";
			abilBtn2 = "No Abil";
			abilBtn3 = "No Abil";
		}
		else if(PlayStat.GetComponent<player>().currBody.name == "Brute")
		{
			abilBtn1 = "RightMB";
			abilBtn2 = " E ";
			abilBtn3 = "Passive";
		}
		else if(PlayStat.GetComponent<player>().currBody.name == "Sneaky")
		{
			abilBtn1 = "RightMB";
			abilBtn2 = " E ";
			abilBtn3 = "Passive";
		}
		else if(PlayStat.GetComponent<player>().currBody.name == "Magus")
		{
			abilBtn1 = "RightMB";
			abilBtn2 = " E ";
			abilBtn3 = " F ";
		}

		abilBtn1 = GUI.TextField(abilRect1,abilBtn1,20);
		abilBtn2 = GUI.TextField(abilRect2, abilBtn2,20);
		abilBtn3 = GUI.TextField(abilRect3,abilBtn3,20);

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
