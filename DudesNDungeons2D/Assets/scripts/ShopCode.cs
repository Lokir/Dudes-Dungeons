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
	// Use this for initialization
	void Start () 
	{
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
		if (GUI.Button(new Rect(Screen.width/150, Screen.height/75, Screen.width/18/*165*/, Screen.height/6/*215*/), button1) && button1 !=camera.GetComponent<GuiTest>().defaultTex) // button for loading Body 1 (default)
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
		if (GUI.Button(new Rect(Screen.width/15.5f, Screen.height/75, Screen.width/18/*165*/, Screen.height/6/*215*/), button2)&& button2 !=camera.GetComponent<GuiTest>().defaultTex) // same as first.
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
		if (GUI.Button(new Rect(Screen.width/8.17f, Screen.height/75, Screen.width/18/*165*/, Screen.height/6/*215*/), button3)&& button3 !=camera.GetComponent<GuiTest>().defaultTex) // same as first.
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
		if (GUI.Button(new Rect(Screen.width/150, Screen.height/5, Screen.width/18/*165*/, Screen.height/6/*215*/), button4)&& button4!=camera.GetComponent<GuiTest>().defaultTex) // same as first.
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
		if (GUI.Button(new Rect(Screen.width/15.5f, Screen.height/5, Screen.width/18/*165*/, Screen.height/6/*215*/), button5)&& button5 !=camera.GetComponent<GuiTest>().defaultTex) // same as first.
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
		if (GUI.Button(new Rect(Screen.width/8.17f, Screen.height/5, Screen.width/18/*165*/, Screen.height/6/*215*/), button6)&& button6 !=camera.GetComponent<GuiTest>().defaultTex) // same as first.
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
		if (GUI.Button(new Rect(70, 105, 40, 40), Sell) && Player.GetComponent<GearHandler>().Backpack[posInBackpack] != null) // same as first.
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
		nameText = GUI.TextField(new Rect(10, 10, 100,23), nameText, 25);
		string text = "HP: "+pressedBodyObject.gHp;
		text = GUI.TextField(new Rect(10, 30, 100, 23), text, 25);
		string text2 = "Str: "+pressedBodyObject.gStr;
		text2 = GUI.TextField(new Rect(10, 50, 100, 23), text2, 25);
		string text3 = "Dex: "+pressedBodyObject.gDex;
		text3 = GUI.TextField(new Rect(10, 70, 100, 23), text3, 25);
		string text4 = "Int: "+pressedBodyObject.gInte;
		text4 = GUI.TextField(new Rect(10, 90, 100, 23), text4, 25);
		string text5 = "Charge: "+pressedBodyObject.gCharge;
		text5 = GUI.TextField(new Rect(10, 110, 100, 23), text5, 25);
		string text6 = "Damage: "+pressedBodyObject.gDamage;
		text6 = GUI.TextField(new Rect(10, 130, 100, 23), text6, 25);

	}
	public void displaySkills(int windowID)
	{

		rageName = GUI.TextField(new Rect(15, 10, 100, 20), rageName, 25);
		regenName = GUI.TextField(new Rect(15, 120, 100, 20), regenName, 25);
		slamName = GUI.TextField(new Rect(15, 230, 100, 20), slamName, 25);
		teleportName = GUI.TextField(new Rect(130, 10, 100, 20), teleportName, 25);
		shadowStabName = GUI.TextField(new Rect(130, 120, 100, 20), shadowStabName, 25);
		accDexName = GUI.TextField(new Rect(130, 230, 100, 20), accDexName, 25);
		forcePushName = GUI.TextField(new Rect(235, 10, 100, 20), forcePushName, 25);
		stoneSkinName = GUI.TextField(new Rect(235, 120, 100, 20), stoneSkinName, 25);
		flameBurstName = GUI.TextField(new Rect(235, 230, 100, 20), flameBurstName, 25);

		if(GUI.Button (new Rect ( 25, 30, 80, 80), RageSkill))
		{
			skillOpen = rageName;
			skillLvl = Player.GetComponent<AbilHandler>().rageLevel;
			SkillDescription = RageSkillDescription;
			showDescription = true;
		}

		if(GUI.Button (new Rect ( 25, 140, 80, 80), RegenSkill))
		{
			skillOpen = regenName;
			skillLvl = Player.GetComponent<AbilHandler>().regenerateLevel;
			SkillDescription = RegenDescription;
			showDescription = true;
		}

		if(GUI.Button (new Rect ( 25, 250, 80, 80), GroundSlamSkill))
		{
			skillOpen = slamName;
			skillLvl = Player.GetComponent<AbilHandler>().groundSlamLevel;
			SkillDescription = GroundSlamDescription;
			showDescription = true;
		}

		// sneaky
		if(GUI.Button (new Rect ( 140, 30, 80, 80), TeleportSkill))
		{
			skillOpen = teleportName;
			skillLvl = Player.GetComponent<AbilHandler>().tpLevel;
			SkillDescription = TeleportDescription;
			showDescription = true;
		}

		if(GUI.Button (new Rect ( 140, 140, 80, 80), ShadowStabSkill))
		{
			skillOpen = shadowStabName;
			skillLvl = Player.GetComponent<AbilHandler>().sSLevel;
			SkillDescription = ShadowStabDescription;
			showDescription = true;
		}

		if(GUI.Button (new Rect ( 140, 250, 80, 80), AccuteDexterity))
		{
			skillOpen = accDexName;
			skillLvl = Player.GetComponent<AbilHandler>().eAndASLevel;
			SkillDescription = AccuteDexterityDescription;
			showDescription = true;
		}

		// mage
		if(GUI.Button (new Rect ( 255, 30, 80, 80), ForcePush))
		{
			skillOpen = forcePushName;
			skillLvl = Player.GetComponent<AbilHandler>().knockbackLevel;
			SkillDescription = ForcePushDescription;
			showDescription = true;
		}

		if(GUI.Button (new Rect ( 255, 140, 80, 80), StoneSkin))
		{
			skillOpen = stoneSkinName;
			skillLvl = Player.GetComponent<AbilHandler>().shieldLevel;
			SkillDescription = StoneSkinDescription;
			showDescription = true;
		}

		if(GUI.Button (new Rect ( 255, 250, 80, 80), FlameBurst))
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
		currSkillLvl = GUI.TextField(new Rect(350-152, 40, 165, 20), currSkillLvl, 100);
		cost = GUI.TextField(new Rect(210, 70, 150, 20),cost,40);
		string pointsAvailable = "points to spend: "+ Player.GetComponent<player>().SkillPoints;
		pointsAvailable = GUI.TextField (new Rect(210, 100, 150, 20), pointsAvailable, 40);
		if(GUI.Button (new Rect(10,10,50,50), exitTex))
		{
			showDescription = false;
		}
		if(GUI.Button (new Rect(420,130,50,50), skillInc))
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
			currSkillLvl = GUI.TextField(new Rect(350-152, 40, 165, 20), currSkillLvl, 100);						
		}
	}

}
