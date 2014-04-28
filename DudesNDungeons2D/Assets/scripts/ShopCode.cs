using UnityEngine;
using System.Collections;

public class ShopCode : MonoBehaviour {

	GameObject shop;
	GameObject Player;
	public bool showDescription = false;

	public Texture backpackSkin;
	public Texture pressedBodyTex;
	public Body pressedBodyObject;

	public Texture RageSkill;
	public Texture RegenSkill;
	public Texture GroundSlamSkill;
	public Texture TeleportSkill;
	public Texture ShadowStabSkill;
	public Texture AccuteDexterity;
	public Texture ForcePush;
	public Texture StoneSkin;
	public Texture FlameBurst;
	public Texture exitTex;
	public Texture skillInc;
	string skillOpen;

	public Texture SkillDescription;
	public Texture RageSkillDescription;
	public Texture RegenDescription;
	public Texture GroundSlamDescription;
	public Texture TeleportDescription;
	public Texture ShadowStabDescription;
	public Texture AccuteDexterityDescription;
	public Texture ForcePushDescription;
	public Texture StoneSkinDescription;
	public Texture FlameBurstDescription;

	string rageName = "Rage";
	string regenName = "Regeneration";
	string slamName = "Groundslam";
	string teleportName = "step in shadows";
	string shadowStabName = "shadeling";
	string accDexName = "Accute Dexterity";
	string forcePushName = "Wave of Force";
	string stoneSkinName = "Stoneskin";
	string flameBurstName = "Cone of Fire";

	int skillLvl;
	int skillCost;
	string currSkillLvl;
	string cost;

	Texture button1;
	Texture button3;
	Texture button2;
	Texture button5;
	Texture button4;
	Texture button6;
	public Texture Sell;
	public bool hasSold;
	int posInBackpack;

	float Distance;
	public bool visiShop;

	//buttonRects
	Rect SellRect = new Rect(130, 175, 40, 40);

	Rect rageRect = new Rect(25, 30, 80, 80);
	Rect regenRect = new Rect(25, 140, 80, 80);
	Rect slamRect = new Rect(25, 250, 80, 80);
	
	Rect tpRect = new Rect(140, 30, 80, 80);
	Rect sSRect = new Rect( 140, 140, 80, 80);
	Rect accuteBodyRect = new Rect(140, 250, 80, 80);
	
	Rect FPRect = new Rect( 255, 30, 80, 80);
	Rect StoneSkinRect = new Rect(255, 140, 80, 80);
	Rect flameRect = new Rect(255, 250, 80, 80);

	Rect exitRect = new Rect(10,10,50,50);
	Rect skillPlusRect = new Rect(420,130,50,50);


	//textRects
	Rect nameTextRect = new Rect(10, 10, 100,23);
	Rect textRect = new Rect(10, 30, 100, 23);
	Rect textRect2 = new Rect(10, 50, 100, 23);
	Rect textRect3 = new Rect(10, 70, 100, 23);
	Rect textRect4 = new Rect(10, 90, 100, 23);
	Rect textRect5 = new Rect(10, 110, 100, 23);
	Rect textRect6 = new Rect(10, 130, 100, 23);

	Rect rageNameRect = new Rect(15, 10, 100, 20);
	Rect regenNameRect = new Rect(15, 120, 100, 20);
	Rect slamNameRect = new Rect(15, 230, 100, 20);
	Rect tpNameRect = new Rect(130, 10, 100, 20);
	Rect sSNameRect = new Rect(130, 120, 100, 20);
	Rect accuteBodyNameRect = new Rect(130, 230, 100, 20);
	Rect FPNameRect = new Rect(235, 10, 100, 20);
	Rect StoneSkinNameRect = new Rect(235, 120, 100, 20);
	Rect flameNameRect = new Rect(235, 230, 100, 20);

	Rect currSkillLvlRect = new Rect(198, 40, 165, 20);
	Rect costRect = new Rect(210, 70, 150, 20);
	Rect ptsAvailRect = new Rect(210, 100, 150, 20);


	// Use this for initialization
	void Start () 
	{
		//Buttons
		fitShopToScreen(ref SellRect, true);
		fitShopToScreen(ref rageRect, true);
		fitShopToScreen(ref regenRect, true);
		fitShopToScreen(ref slamRect, true);
		fitShopToScreen(ref tpRect, true);
		fitShopToScreen(ref sSRect, true);
		fitShopToScreen(ref accuteBodyRect, true);
		fitShopToScreen(ref FPRect, true);
		fitShopToScreen(ref StoneSkinRect, true);
		fitShopToScreen(ref flameRect, true);
		fitShopToScreen(ref exitRect, true);
		fitShopToScreen(ref skillPlusRect, true);

		//Text
		fitShopToScreen(ref nameTextRect, false);
		fitShopToScreen(ref textRect, false);
		fitShopToScreen(ref textRect2, false);
		fitShopToScreen(ref textRect3, false);
		fitShopToScreen(ref textRect4, false);
		fitShopToScreen(ref textRect5, false);
		fitShopToScreen(ref textRect6, false);
		
		fitShopToScreen(ref rageNameRect, false);
		fitShopToScreen(ref regenNameRect, false);
		fitShopToScreen(ref slamNameRect, false);
		fitShopToScreen(ref tpNameRect, false);
		fitShopToScreen(ref sSNameRect, false);
		fitShopToScreen(ref accuteBodyNameRect, false);
		fitShopToScreen(ref FPNameRect, false);
		fitShopToScreen(ref StoneSkinNameRect, false);
		fitShopToScreen(ref flameNameRect, false);
		
		fitShopToScreen(ref currSkillLvlRect, false);
		fitShopToScreen(ref ptsAvailRect, false);



		showDescription = false;
		skillOpen = "Default";
		hasSold = false;
		posInBackpack = 0;
		pressedBodyObject = new Body();
		shop = GameObject.FindGameObjectWithTag("Shop");
		Player = GameObject.FindGameObjectWithTag("Player");
		Player.GetComponent<player>().SkillPoints = 5;

		visiShop = false;
	}
	void fitShopToScreen(ref Rect rectToMod, bool fitSize)
	{
		rectToMod.width = ((rectToMod.width/1366)*Screen.width);
		rectToMod.height = ((rectToMod.height/608)*Screen.height);
		rectToMod.x = ((rectToMod.x/1366)*Screen.width);
		rectToMod.y = ((rectToMod.y/608)*Screen.height);
	}
	// Update is called once per frame
	void Update () 
	{
		Distance = Vector3.Distance(Player.transform.position, shop.transform.position);
		if(Distance <= 3.0f && Input.GetKeyDown (KeyCode.E))
		{
			visiShop = !visiShop;
		}
		if(Distance > 3.0f)
		{
			visiShop = false;
		}
	}

	public void pDoBackPack(int windowID) // this function handles backpack buttons
	{
		button1 = camera.GetComponent<GuiTest>().button1;
		button2 = camera.GetComponent<GuiTest>().button2;
		button3 = camera.GetComponent<GuiTest>().button3;
		button4 = camera.GetComponent<GuiTest>().button4;
		button5 = camera.GetComponent<GuiTest>().button5;
		button6 = camera.GetComponent<GuiTest>().button6;

		// if ( create Gui Button, new rect(x,y,W,H),Texture);
		if (GUI.Button(GetComponent<GuiTest>().doBackpackBtn1, button1) && button1 !=camera.GetComponent<GuiTest>().defaultTex) // button for loading Body 1 (default)
		{
			pressedBodyTex = button1;
			pressedBodyObject.name = Player.GetComponent<GearHandler>().Backpack[0].name;
			pressedBodyObject.gHp = Player.GetComponent<GearHandler>().Backpack[0].gHp;
			pressedBodyObject.gStr = Player.GetComponent<GearHandler>().Backpack[0].gStr;
			pressedBodyObject.gDex = Player.GetComponent<GearHandler>().Backpack[0].gDex;
			pressedBodyObject.gInte = Player.GetComponent<GearHandler>().Backpack[0].gInte;
			pressedBodyObject.gCharge = Player.GetComponent<GearHandler>().Backpack[0].gCharge;
			pressedBodyObject.gDamage = Player.GetComponent<GearHandler>().Backpack[0].gDamage;
			posInBackpack = 0;
		}
		if (GUI.Button(GetComponent<GuiTest>().doBackpackBtn2, button2)&& button2 !=camera.GetComponent<GuiTest>().defaultTex) // same as first.
		{
			pressedBodyTex = button2;
			pressedBodyObject.name = Player.GetComponent<GearHandler>().Backpack[1].name;
			pressedBodyObject.gHp = Player.GetComponent<GearHandler>().Backpack[1].gHp;
			pressedBodyObject.gStr = Player.GetComponent<GearHandler>().Backpack[1].gStr;
			pressedBodyObject.gDex = Player.GetComponent<GearHandler>().Backpack[1].gDex;
			pressedBodyObject.gInte = Player.GetComponent<GearHandler>().Backpack[1].gInte;
			pressedBodyObject.gCharge = Player.GetComponent<GearHandler>().Backpack[1].gCharge;
			pressedBodyObject.gDamage = Player.GetComponent<GearHandler>().Backpack[1].gDamage;
			posInBackpack = 1;
		}
		if (GUI.Button(GetComponent<GuiTest>().doBackpackBtn3, button3)&& button3 !=camera.GetComponent<GuiTest>().defaultTex) // same as first.
		{
			pressedBodyTex = button3;
			pressedBodyObject.name = Player.GetComponent<GearHandler>().Backpack[2].name;
			pressedBodyObject.gHp = Player.GetComponent<GearHandler>().Backpack[2].gHp;
			pressedBodyObject.gStr = Player.GetComponent<GearHandler>().Backpack[2].gStr;
			pressedBodyObject.gDex = Player.GetComponent<GearHandler>().Backpack[2].gDex;
			pressedBodyObject.gInte = Player.GetComponent<GearHandler>().Backpack[2].gInte;
			pressedBodyObject.gCharge = Player.GetComponent<GearHandler>().Backpack[2].gCharge;
			pressedBodyObject.gDamage = Player.GetComponent<GearHandler>().Backpack[2].gDamage;
			posInBackpack = 2;
		}
		if (GUI.Button(GetComponent<GuiTest>().doBackpackBtn4, button4)&& button4!=camera.GetComponent<GuiTest>().defaultTex) // same as first.
		{
			pressedBodyTex = button4;
			pressedBodyObject.name = Player.GetComponent<GearHandler>().Backpack[3].name;
			pressedBodyObject.gHp = Player.GetComponent<GearHandler>().Backpack[3].gHp;
			pressedBodyObject.gStr = Player.GetComponent<GearHandler>().Backpack[3].gStr;
			pressedBodyObject.gDex = Player.GetComponent<GearHandler>().Backpack[3].gDex;
			pressedBodyObject.gInte = Player.GetComponent<GearHandler>().Backpack[3].gInte;
			pressedBodyObject.gCharge = Player.GetComponent<GearHandler>().Backpack[3].gCharge;
			pressedBodyObject.gDamage = Player.GetComponent<GearHandler>().Backpack[3].gDamage;
			posInBackpack = 3;
		}
		if (GUI.Button(GetComponent<GuiTest>().doBackpackBtn5, button5)&& button5 !=camera.GetComponent<GuiTest>().defaultTex) // same as first.
		{
			pressedBodyTex = button5;
			pressedBodyObject.name = Player.GetComponent<GearHandler>().Backpack[4].name;
			pressedBodyObject.gHp = Player.GetComponent<GearHandler>().Backpack[4].gHp;
			pressedBodyObject.gStr = Player.GetComponent<GearHandler>().Backpack[4].gStr;
			pressedBodyObject.gDex = Player.GetComponent<GearHandler>().Backpack[4].gDex;
			pressedBodyObject.gInte = Player.GetComponent<GearHandler>().Backpack[4].gInte;
			pressedBodyObject.gCharge = Player.GetComponent<GearHandler>().Backpack[4].gCharge;
			pressedBodyObject.gDamage = Player.GetComponent<GearHandler>().Backpack[4].gDamage;
			posInBackpack = 4;
		}
		if (GUI.Button(GetComponent<GuiTest>().doBackpackBtn6, button6)&& button6 !=camera.GetComponent<GuiTest>().defaultTex) // same as first.
		{
			pressedBodyTex = button6;
			pressedBodyObject.name = Player.GetComponent<GearHandler>().Backpack[5].name;
			pressedBodyObject.gHp = Player.GetComponent<GearHandler>().Backpack[5].gHp;
			pressedBodyObject.gStr = Player.GetComponent<GearHandler>().Backpack[5].gStr;
			pressedBodyObject.gDex = Player.GetComponent<GearHandler>().Backpack[5].gDex;
			pressedBodyObject.gInte = Player.GetComponent<GearHandler>().Backpack[5].gInte;
			pressedBodyObject.gCharge = Player.GetComponent<GearHandler>().Backpack[5].gCharge;
			pressedBodyObject.gDamage = Player.GetComponent<GearHandler>().Backpack[5].gDamage;
			posInBackpack = 5;
		}
	}
	public void pressedEquip(int windowID) // this needs to be there for the GUI window, but we currently don't want it to do anything.
	{
		if (GUI.Button(SellRect, Sell) && Player.GetComponent<GearHandler>().Backpack[posInBackpack] != null) // same as first.
		{
			Player.GetComponent<player>().currBody = Player.GetComponent<GearHandler>().Bodies[0];
			Player.GetComponent<player>().loadGear = true;
			pressedBodyTex = camera.GetComponent<GuiTest>().defaultTex;
			sellBody(posInBackpack);
		}
	}
	void sellBody(int pos)
	{
		Player.GetComponent<GearHandler>().Backpack[0] = null;
		Player.GetComponent<player>().SkillPoints++;
		hasSold = true;
		GetComponent<GuiTest>().bodyChange = true;
		Debug.Log (Player.GetComponent<player>().SkillPoints);
	}
	public void showBodyStats(int windowID)
	{
		string nameText = "name: "+pressedBodyObject.name;
		nameText = GUI.TextField(nameTextRect, nameText, 25);
		string text = "HP: "+pressedBodyObject.gHp;
		text = GUI.TextField(textRect, text, 25);
		string text2 = "Str: "+pressedBodyObject.gStr;
		text2 = GUI.TextField(textRect2, text2, 25);
		string text3 = "Dex: "+pressedBodyObject.gDex;
		text3 = GUI.TextField(textRect3, text3, 25);
		string text4 = "Int: "+pressedBodyObject.gInte;
		text4 = GUI.TextField(textRect4, text4, 25);
		string text5 = "Charge: "+pressedBodyObject.gCharge;
		text5 = GUI.TextField(textRect5, text5, 25);
		string text6 = "Damage: "+pressedBodyObject.gDamage;
		text6 = GUI.TextField(textRect6, text6, 25);

	}
	public void displaySkills(int windowID)
	{

		rageName = GUI.TextField(rageNameRect, rageName, 25);
		regenName = GUI.TextField(regenNameRect, regenName, 25);
		slamName = GUI.TextField(slamNameRect, slamName, 25);
		teleportName = GUI.TextField(tpNameRect, teleportName, 25);
		shadowStabName = GUI.TextField(sSNameRect, shadowStabName, 25);
		accDexName = GUI.TextField(accuteBodyNameRect, accDexName, 25);
		forcePushName = GUI.TextField(FPNameRect, forcePushName, 25);
		stoneSkinName = GUI.TextField(StoneSkinNameRect, stoneSkinName, 25);
		flameBurstName = GUI.TextField(flameNameRect, flameBurstName, 25);


		if(GUI.Button (rageRect, RageSkill))
		{
			skillOpen = rageName;
			skillLvl = Player.GetComponent<AbilHandler>().rageLevel;
			SkillDescription = RageSkillDescription;
			showDescription = true;
		}

		if(GUI.Button (regenRect, RegenSkill))
		{
			skillOpen = regenName;
			skillLvl = Player.GetComponent<AbilHandler>().regenerateLevel;
			SkillDescription = RegenDescription;
			showDescription = true;
		}

		if(GUI.Button (slamRect, GroundSlamSkill))
		{
			skillOpen = slamName;
			skillLvl = Player.GetComponent<AbilHandler>().groundSlamLevel;
			SkillDescription = GroundSlamDescription;
			showDescription = true;
		}

		// sneaky
		if(GUI.Button (tpRect, TeleportSkill))
		{
			skillOpen = teleportName;
			skillLvl = Player.GetComponent<AbilHandler>().tpLevel;
			SkillDescription = TeleportDescription;
			showDescription = true;
		}

		if(GUI.Button (sSRect, ShadowStabSkill))
		{
			skillOpen = shadowStabName;
			skillLvl = Player.GetComponent<AbilHandler>().sSLevel;
			SkillDescription = ShadowStabDescription;
			showDescription = true;
		}

		if(GUI.Button (accuteBodyRect, AccuteDexterity))
		{
			skillOpen = accDexName;
			skillLvl = Player.GetComponent<AbilHandler>().eAndASLevel;
			SkillDescription = AccuteDexterityDescription;
			showDescription = true;
		}

		// mage
		if(GUI.Button (FPRect, ForcePush))
		{
			skillOpen = forcePushName;
			skillLvl = Player.GetComponent<AbilHandler>().knockbackLevel;
			SkillDescription = ForcePushDescription;
			showDescription = true;
		}

		if(GUI.Button (StoneSkinRect, StoneSkin))
		{
			skillOpen = stoneSkinName;
			skillLvl = Player.GetComponent<AbilHandler>().shieldLevel;
			SkillDescription = StoneSkinDescription;
			showDescription = true;
		}

		if(GUI.Button (flameRect, FlameBurst))
		{
			skillOpen = flameBurstName;
			skillLvl = Player.GetComponent<AbilHandler>().flameThrowerLevel;
			SkillDescription = FlameBurstDescription;
			showDescription = true;
		}
	}
	public void skillDescriptionload(int windowID)
	{
		currSkillLvl = "Current skill lvl = "+skillLvl+" out of 5";
		skillCost = skillLvl+1;
		cost = "Point cost to increase: "+skillCost;
		cost = GUI.TextField(costRect,cost,40);
		string pointsAvailable = "points to spend: "+ Player.GetComponent<player>().SkillPoints;
		pointsAvailable = GUI.TextField (ptsAvailRect, pointsAvailable, 40);
		if(GUI.Button (exitRect, exitTex))
		{
			showDescription = false;
		}
		if(GUI.Button (skillPlusRect, skillInc))
		{
			if(skillOpen == rageName && Player.GetComponent<player>().SkillPoints >= skillCost)
			{
				skillLvl = ++Player.GetComponent<AbilHandler>().rageLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;

			}
			else if(skillOpen == regenName && Player.GetComponent<player>().SkillPoints >= skillCost)
			{
				skillLvl= ++Player.GetComponent<AbilHandler>().regenerateLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == slamName && Player.GetComponent<player>().SkillPoints >= skillCost)
			{
				skillLvl= ++Player.GetComponent<AbilHandler>().groundSlamLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == teleportName && Player.GetComponent<player>().SkillPoints >= skillCost)
			{
				skillLvl= ++Player.GetComponent<AbilHandler>().tpLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == shadowStabName && Player.GetComponent<player>().SkillPoints >= skillCost)
			{
				skillLvl= ++Player.GetComponent<AbilHandler>().sSLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == accDexName && Player.GetComponent<player>().SkillPoints >= skillCost)
			{
				skillLvl = ++Player.GetComponent<AbilHandler>().eAndASLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == forcePushName && Player.GetComponent<player>().SkillPoints >= skillCost)
			{
				skillLvl= ++Player.GetComponent<AbilHandler>().knockbackLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == stoneSkinName && Player.GetComponent<player>().SkillPoints >= skillCost)
			{
				skillLvl= ++Player.GetComponent<AbilHandler>().shieldLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == flameBurstName && Player.GetComponent<player>().SkillPoints >= skillCost)
			{
				skillLvl= ++Player.GetComponent<AbilHandler>().flameThrowerLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			currSkillLvl = "Current skill lvl = "+skillLvl+" out of 5";
			currSkillLvl = GUI.TextField(currSkillLvlRect, currSkillLvl, 100);						
		}
	}

}
