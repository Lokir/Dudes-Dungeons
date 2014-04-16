using UnityEngine;
using System.Collections;

public class player : MonoBehaviour 
{
    public int pHp, pInte, pDex, pStr, pCharge, pDamage = 0; //current player stats
	public int sHp, sInte, sDex, sStr, sCharge; // raw stats
	public int HPCap; // HP max
	bool canJump; // canJump, this system will be remade in to a ray trace to make if more diverse and reliable.
	public bool left; // moving left.

	public Body currBody = new Body(); // this body is the current body that we can load other bodies into.
	// Use this for initialization
	void Start () 
	{
		// default stat Values
		pHp = sHp = 30;
		pInte = sInte = 5;
		pDex = sDex = 5;
		pStr = sStr = 5;
		pCharge = sCharge = 20;
		HPCap = pHp;
		pDamage = ((int)((pStr/100)*30))+1;
		canJump = true;

		// default Currbody Values.
		currBody.name = "Default";
		currBody.gHp = 90;
		currBody.gInte = 10;
		currBody.gDex = 10;
		currBody.gStr = 10;
		currBody.gDamage = currBody.gStr + 5;
		currBody.mageAbil = false;
		currBody.sneakyAbil = false;
		currBody.bruteAbil = false;

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
			pDamage = currBody.gDamage +((int)((pStr/100)*30)); // temporary system for calculating damage... Dam+ 30% of strength.
			HPCap = sHp + currBody.gHp;
			loadGear = false; // set to false so we don't continously load gear when it is unnecessary.
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
