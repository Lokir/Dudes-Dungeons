using UnityEngine;
using System.Collections;

public class player : MonoBehaviour 
{
    public int pHp, pInte, pDex, pStr, pCharge, pDamage = 0; //current player stats
	public int sHp, sInte, sDex, sStr, sCharge; // raw stats
	public int HPCap; // HP max
	bool canJump; // canJump, this system will be remade in to a ray trace to make if more diverse and reliable.
	public bool left; // moving left.
	public float dodge, crit, skillBon;

	public Body currBody = new Body(); // this body is the current body that we can load other bodies into.
	// Use this for initialization
	void Start () 
	{
		// default stat Values
		pHp = sHp = 30;
		pInte = sInte = 10;
		pDex = sDex = 10;
		pStr = sStr = 10;
		pCharge = sCharge = 100;
		HPCap = pHp;
		pDamage = 0;
		canJump = true;

		// default Currbody Values.

	}
	// Update is called once per frame
	public bool loadGear = true; // if this is true then we load the gear.
	void Update () 
	{
		if(transform.position.y < -3.6f) // again this system will be remade.
		{
			canJump = true;
		}
		if(loadGear == true)// load gear.
		{
			pHp = sHp + currBody.gHp; // sHP is stat HP and gHP is Gear HP.
			pInte = sInte + currBody.gInte;
			pDex = sDex + currBody.gDex;
			pStr = sStr + currBody.gStr;
			pCharge = sCharge + currBody.gCharge;
			pDamage = currBody.gDamage; // temporary system for calculating damage... Dam+ 30% of strength.
			HPCap = sHp + currBody.gHp;
			loadGear = false; // set to false so we don't continously load gear when it is unnecessary.

			dodge = (float)pDex;
			crit = (float)(pDex/2);
			skillBon = (float)(pInte/2);
			pCharge += ((int)(pInte/3))+1;
			pDamage += ((int)(pStr*0.33))+1;
			pHp += ((int)(pStr*0.2))+1;
			HPCap = pHp;
		}
		if(Input.GetKey(KeyCode.A)) // if key A move left.
		{
			transform.position -= new Vector3(0.05f,0,0);
			GetComponent<AnimHandler>().leftBool = true; // allow run of animation left.
			left = true;
		}
		if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)) // if no movement in any direction, initiate idle.
		{
			GetComponent<AnimHandler>().idleBool = true;
			left = false;
		}

		if(Input.GetKey(KeyCode.D)) // move right.
		{
			transform.position += new Vector3(0.05f,0,0);
			GetComponent<AnimHandler>().rightBool = true;
		}
		if(Input.GetKeyDown(KeyCode.W) && canJump == true) // system to be remade (jump again)
		{
			rigidbody2D.AddForce(new Vector2 (0,200));
			canJump = false;
		}
	}

}
