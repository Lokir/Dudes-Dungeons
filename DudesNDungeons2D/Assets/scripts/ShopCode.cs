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

	public Texture HPTex;
	public Texture ChargeTex;
	public Texture StrTex;
	public Texture DexTex;
	public Texture InteTex;

	public Texture Sell;
	public bool hasSold;
	public int posInBackpack;

	float Distance;
	public bool visiShop;

	//buttonRects
	Rect SellRect = new Rect(130, 221, 40, 50.5f);

	Rect rageRect = new Rect(25, 37.9f, 80, 101);
	Rect regenRect = new Rect(25, 176.8f, 80, 101);
	Rect slamRect = new Rect(25, 315.8f, 80, 101);
	
	Rect tpRect = new Rect(140, 37.9f, 80, 101);
	Rect sSRect = new Rect( 140, 176.8f, 80, 101);
	Rect accuteBodyRect = new Rect(140, 315.8f, 80, 101);
	
	Rect FPRect = new Rect( 255, 37.9f, 80, 101);
	Rect StoneSkinRect = new Rect(255, 176.8f, 80, 101);
	Rect flameRect = new Rect(255, 315.8f, 80, 101);

	Rect exitRect = new Rect(10,12.6f,50,63);
	Rect skillPlusRect = new Rect(420,114.2f,50,63);

	Rect BuyHPRect = new Rect(40, 430, 60, 60);
	Rect BuyStrRect = new Rect(110, 430, 60, 60);
	Rect BuyDexRect = new Rect(180, 430, 60, 60);
	Rect BuyInteRect = new Rect(250, 430, 60, 60);

	//textRects
	Rect nameTextRect = new Rect(10, 12.6f, 100,29);
	Rect textRect = new Rect(10, 37.9f, 100, 29);
	Rect textRect2 = new Rect(10, 63, 100, 29);
	Rect textRect3 = new Rect(10, 88.4f, 100, 29);
	Rect textRect4 = new Rect(10, 113.7f, 100, 29);
	Rect textRect5 = new Rect(10, 138.9f, 100, 29);
	Rect textRect6 = new Rect(10, 164.2f, 100, 29);

	Rect rageNameRect = new Rect(15, 12.6f, 100, 25.26f);
	Rect regenNameRect = new Rect(15, 151.5f, 100, 25.26f);
	Rect slamNameRect = new Rect(15, 290.5f, 100, 25.26f);
	Rect tpNameRect = new Rect(130, 12.6f, 100, 25.26f);
	Rect sSNameRect = new Rect(130, 151.5f, 100, 25.26f);
	Rect accuteBodyNameRect = new Rect(130, 290.5f, 100, 25.26f);
	Rect FPNameRect = new Rect(235, 12.6f, 100, 25.26f);
	Rect StoneSkinNameRect = new Rect(235, 151.5f, 100, 25.26f);
	Rect flameNameRect = new Rect(235, 290.5f, 100, 25.26f);

	Rect currSkillLvlRect = new Rect(198, 10, 165, 20);
	Rect costRect = new Rect(198, 35, 150, 20);
	Rect ptsAvailRect = new Rect(198, 60, 150, 20);
	public AudioClip clickSound;
	public AudioClip coinSound;

	// Use this for initialization
	void Start () 
	{

		//Buttons
		fitShopToScreen(ref BuyHPRect, true, true);
		fitShopToScreen(ref BuyDexRect, true, true);
		fitShopToScreen(ref BuyInteRect, true, true);
		fitShopToScreen(ref BuyStrRect, true, true);

		fitShopToScreen(ref SellRect, true, true);
		fitShopToScreen(ref rageRect, true, true);
		fitShopToScreen(ref regenRect, true, true);
		fitShopToScreen(ref slamRect, true, true);
		fitShopToScreen(ref tpRect, true, true);
		fitShopToScreen(ref sSRect, true, true);
		fitShopToScreen(ref accuteBodyRect, true, true);
		fitShopToScreen(ref FPRect, true, true);
		fitShopToScreen(ref StoneSkinRect, true, true);
		fitShopToScreen(ref flameRect, true, true);
		fitShopToScreen(ref exitRect, true, true);
		fitShopToScreen(ref skillPlusRect, true, true);

		//Text
		fitShopToScreen(ref nameTextRect, false, false);
		fitShopToScreen(ref textRect, false, false);
		fitShopToScreen(ref textRect2, false, false);
		fitShopToScreen(ref textRect3, false, false);
		fitShopToScreen(ref textRect4, false, false);
		fitShopToScreen(ref textRect5, false, false);
		fitShopToScreen(ref textRect6, false, false);
		
		fitShopToScreen(ref rageNameRect, false, true);
		fitShopToScreen(ref regenNameRect, false, true);
		fitShopToScreen(ref slamNameRect, false, true);
		fitShopToScreen(ref tpNameRect, false, true);
		fitShopToScreen(ref sSNameRect, false, true);
		fitShopToScreen(ref accuteBodyNameRect, false, true);
		fitShopToScreen(ref FPNameRect, false, true);
		fitShopToScreen(ref StoneSkinNameRect, false, true);
		fitShopToScreen(ref flameNameRect, false, true);
		
		fitShopToScreen(ref currSkillLvlRect, false, true);
		fitShopToScreen(ref costRect, false, true);
		fitShopToScreen(ref ptsAvailRect, false, true);



		showDescription = false;
		skillOpen = "Default";
		hasSold = false;
		posInBackpack = 0;
		pressedBodyObject = new Body();
		Player = GameObject.FindGameObjectWithTag("Player");
		Player.GetComponent<player>().SkillPoints = 30;

		visiShop = false;
	}
	void fitShopToScreen(ref Rect rectToMod, bool fitSize, bool adjustY)
	{
		if(fitSize)
		{
			rectToMod.width = ((rectToMod.width/1366)*Screen.width);
			rectToMod.height = ((rectToMod.height/768)*Screen.height);
		}
		rectToMod.x = ((rectToMod.x/1366)*Screen.width);
		if(adjustY)
		{
			rectToMod.y = ((rectToMod.y/768)*Screen.height);
		}
	}
	// Update is called once per frame
	void Update () 
	{
			Distance = Vector3.Distance(Player.transform.position, transform.position);
		if(Distance <= 1.0f && Input.GetKeyDown (KeyCode.E))
		{
			visiShop = !visiShop;
		}
		if(Distance > 1.0f)
		{
			visiShop = false;
		}
	}
	
	public void pressedEquip(int windowID) // this needs to be there for the GUI window, but we currently don't want it to do anything.
	{
		if (GUI.Button(SellRect, Sell) && Player.GetComponent<GearHandler>().Backpack[posInBackpack] != null) // same as first.
		{
			Player.GetComponent<player>().currBody = Player.GetComponent<GearHandler>().Bodies[0];
			Player.GetComponent<player>().loadGear = true;
			pressedBodyTex = Camera.main.GetComponent<GuiTest>().defaultTex;
			sellBody(posInBackpack);
		}
	}
	void sellBody(int pos)
	{
		audio.clip = coinSound;
		audio.Play ();
		Player.GetComponent<GearHandler>().Backpack[pos] = null;
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

		if(GUI.Button (BuyHPRect, HPTex))
		{
			if(Player.GetComponent<player>().SkillPoints >= 1)
			{
				audio.clip = coinSound;
				audio.Play ();
				Player.GetComponent<player>().SkillPoints -= 1;
				Player.GetComponent<player>().sHp += 10;
				Player.GetComponent<player>().pHp = Player.GetComponent<player>().sHp + Player.GetComponent<player>().currBody.gHp;
				Player.GetComponent<player>().HPCap = Player.GetComponent<player>().pHp;
			}
		}
		if(GUI.Button (BuyStrRect, StrTex))
		{
			if(Player.GetComponent<player>().SkillPoints >= 1)
			{
				audio.clip = coinSound;
				audio.Play ();
				Player.GetComponent<player>().SkillPoints -= 1;
				Player.GetComponent<player>().HPCap = Player.GetComponent<player>().HPCap-((int)(Player.GetComponent<player>().pStr*0.2))+1;
				Player.GetComponent<player>().pDamage -= (((int)(Player.GetComponent<player>().pStr*0.33))+1);
				Player.GetComponent<player>().sStr += 1;
				Player.GetComponent<player>().pStr = Player.GetComponent<player>().sStr + Player.GetComponent<player>().currBody.gStr;
				Player.GetComponent<player>().pHp = Player.GetComponent<player>().HPCap;
				Player.GetComponent<player>().pHp += ((int)(Player.GetComponent<player>().pStr*0.2))+1;
				Player.GetComponent<player>().HPCap = Player.GetComponent<player>().pHp;
				Player.GetComponent<player>().pDamage += (((int)(Player.GetComponent<player>().pStr*0.33))+1);
			}
		}
		if(GUI.Button (BuyDexRect, DexTex))
		{
			if(Player.GetComponent<player>().SkillPoints >= 1)
			{
				audio.clip = coinSound;
				audio.Play ();
				Player.GetComponent<player>().SkillPoints -= 1;
				Player.GetComponent<player>().sDex += 1;
				Player.GetComponent<player>().pDex = Player.GetComponent<player>().sDex + Player.GetComponent<player>().currBody.gDex;
				Player.GetComponent<player>().dodge = (float)Player.GetComponent<player>().pDex;
				Player.GetComponent<AbilHandler>().canEandAS = true;
			}
		}
		if(GUI.Button (BuyInteRect, InteTex))
		{
			if(Player.GetComponent<player>().SkillPoints >= 1)
			{
				audio.clip = coinSound;
				audio.Play ();
				Player.GetComponent<player>().SkillPoints -= 1;
				Player.GetComponent<player>().sInte += 1;
				Player.GetComponent<player>().pInte = Player.GetComponent<player>().sInte+Player.GetComponent<player>().currBody.gInte;
				Player.GetComponent<player>().skillBon = ((float)(Player.GetComponent<player>().pInte*0.1)+1);
				Player.GetComponent<player>().pCharge += 10;
			}
		}
		

		if(GUI.Button (rageRect, RageSkill))
		{
			audio.clip = clickSound;
			audio.Play ();
			skillOpen = rageName;
			skillLvl = Player.GetComponent<AbilHandler>().rageLevel;
			SkillDescription = RageSkillDescription;
			showDescription = true;
		}

		if(GUI.Button (regenRect, RegenSkill))
		{
			audio.clip = clickSound;
			audio.Play ();
			skillOpen = regenName;
			skillLvl = Player.GetComponent<AbilHandler>().regenerateLevel;
			SkillDescription = RegenDescription;
			showDescription = true;
		}

		if(GUI.Button (slamRect, GroundSlamSkill))
		{
			audio.clip = clickSound;
			audio.Play ();
			skillOpen = slamName;
			skillLvl = Player.GetComponent<AbilHandler>().groundSlamLevel;
			SkillDescription = GroundSlamDescription;
			showDescription = true;
		}

		// sneaky
		if(GUI.Button (tpRect, TeleportSkill))
		{
			audio.clip = clickSound;
			audio.Play ();
			skillOpen = teleportName;
			skillLvl = Player.GetComponent<AbilHandler>().tpLevel;
			SkillDescription = TeleportDescription;
			showDescription = true;
		}

		if(GUI.Button (sSRect, ShadowStabSkill))
		{
			audio.clip = clickSound;
			audio.Play ();
			skillOpen = shadowStabName;
			skillLvl = Player.GetComponent<AbilHandler>().sSLevel;
			SkillDescription = ShadowStabDescription;
			showDescription = true;
		}

		if(GUI.Button (accuteBodyRect, AccuteDexterity))
		{
			audio.clip = clickSound;
			audio.Play ();
			skillOpen = accDexName;
			skillLvl = Player.GetComponent<AbilHandler>().eAndASLevel;
			SkillDescription = AccuteDexterityDescription;
			showDescription = true;
		}

		// mage
		if(GUI.Button (FPRect, ForcePush))
		{
			audio.clip = clickSound;
			audio.Play ();
			skillOpen = forcePushName;
			skillLvl = Player.GetComponent<AbilHandler>().knockbackLevel;
			SkillDescription = ForcePushDescription;
			showDescription = true;
		}

		if(GUI.Button (StoneSkinRect, StoneSkin))
		{
			audio.clip = clickSound;
			audio.Play ();
			skillOpen = stoneSkinName;
			skillLvl = Player.GetComponent<AbilHandler>().shieldLevel;
			SkillDescription = StoneSkinDescription;
			showDescription = true;
		}

		if(GUI.Button (flameRect, FlameBurst))
		{
			audio.clip = clickSound;
			audio.Play ();
			skillOpen = flameBurstName;
			skillLvl = Player.GetComponent<AbilHandler>().flameThrowerLevel;
			SkillDescription = FlameBurstDescription;
			showDescription = true;
		}
	}
	public void skillDescriptionload(int windowID)
	{
		currSkillLvl = "Current skill lvl = "+skillLvl+" out of 5";
		currSkillLvl = GUI.TextField(currSkillLvlRect, currSkillLvl, 100);
		skillCost = skillLvl+1;
		if(skillCost < 5)
		{
			cost = "Point cost to increase: "+skillCost;
		}
		cost = GUI.TextField(costRect,cost,40);
		string pointsAvailable = "points to spend: "+ Player.GetComponent<player>().SkillPoints;
		pointsAvailable = GUI.TextField (ptsAvailRect, pointsAvailable, 40);
		if(GUI.Button (exitRect, exitTex))
		{
			showDescription = false;
		}
		if(GUI.Button (skillPlusRect, skillInc))
		{
			if(skillOpen == rageName && Player.GetComponent<player>().SkillPoints >= skillCost&& Player.GetComponent<AbilHandler>().rageLevel < 5)
			{
				audio.clip = coinSound;
				audio.Play ();
				skillLvl = ++Player.GetComponent<AbilHandler>().rageLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;

			}
			else if(skillOpen == regenName && Player.GetComponent<player>().SkillPoints >= skillCost&& Player.GetComponent<AbilHandler>().regenerateLevel < 5)
			{
				audio.clip = coinSound;
				audio.Play ();
				skillLvl= ++Player.GetComponent<AbilHandler>().regenerateLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == slamName && Player.GetComponent<player>().SkillPoints >= skillCost&& Player.GetComponent<AbilHandler>().groundSlamLevel < 5)
			{
				audio.clip = coinSound;
				audio.Play ();
				skillLvl= ++Player.GetComponent<AbilHandler>().groundSlamLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == teleportName && Player.GetComponent<player>().SkillPoints >= skillCost&& Player.GetComponent<AbilHandler>().tpLevel < 5)
			{
				audio.clip = coinSound;
				audio.Play ();
				skillLvl= ++Player.GetComponent<AbilHandler>().tpLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == shadowStabName && Player.GetComponent<player>().SkillPoints >= skillCost && Player.GetComponent<AbilHandler>().sSLevel < 5)
			{
				audio.clip = coinSound;
				audio.Play ();
				skillLvl= ++Player.GetComponent<AbilHandler>().sSLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == accDexName && Player.GetComponent<player>().SkillPoints >= skillCost&& Player.GetComponent<AbilHandler>().eAndASLevel < 5)
			{
				audio.clip = coinSound;
				audio.Play ();
				skillLvl = ++Player.GetComponent<AbilHandler>().eAndASLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				Player.GetComponent<AbilHandler>().canEandAS = true;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == forcePushName && Player.GetComponent<player>().SkillPoints >= skillCost&& Player.GetComponent<AbilHandler>().knockbackLevel < 5)
			{
				audio.clip = coinSound;
				audio.Play ();
				skillLvl= ++Player.GetComponent<AbilHandler>().knockbackLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == stoneSkinName && Player.GetComponent<player>().SkillPoints >= skillCost && Player.GetComponent<AbilHandler>().shieldLevel < 5)
			{
				audio.clip = coinSound;
				audio.Play ();
				skillLvl= ++Player.GetComponent<AbilHandler>().shieldLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			else if(skillOpen == flameBurstName && Player.GetComponent<player>().SkillPoints >= skillCost && Player.GetComponent<AbilHandler>().flameThrowerLevel < 5)
			{
				audio.clip = coinSound;
				audio.Play ();
				skillLvl= ++Player.GetComponent<AbilHandler>().flameThrowerLevel;
				Player.GetComponent<player>().SkillPoints -= skillCost;
				GetComponent<GuiTest>().bodyChange = true;
			}
			if(skillLvl == 5)
			{
				cost =" Skill is MAXED out";
			}		
		}
	}

}
