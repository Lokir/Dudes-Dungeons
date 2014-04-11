using UnityEngine;
using System.Collections;

public class player : MonoBehaviour 
{
    public int pHp, pInte, pDex, pStr, pCharge, pDamage = 0; //current player stats
	public int sHp, sInte, sDex, sStr, sCharge; // raw stats
	public int HPCap;
	bool canJump;
	public bool left;

	public Body currBody = new Body();
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
	public bool loadGear = true;
	void Update () 
	{
		if(transform.position.y < -3.6f)
		{
			canJump = true;
		}
		if(loadGear == true)
		{
			pHp = sHp + currBody.gHp;
			pInte = sInte + currBody.gInte;
			pDex = sDex + currBody.gDex;
			pStr = sStr + currBody.gStr;
			pCharge = sCharge + currBody.gCharge;
			pDamage = currBody.gDamage +((int)((pStr/100)*30));
			HPCap = sHp + currBody.gHp;
			loadGear = false;
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.position -= new Vector3(0.2f,0,0);
			GetComponent<AnimHandler>().leftBool = true;
			left = true;
		}
		if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
		{
			GetComponent<AnimHandler>().idleBool = true;
			left = false;
		}

		if(Input.GetKey(KeyCode.D))
		{
			transform.position += new Vector3(0.2f,0,0);
			GetComponent<AnimHandler>().rightBool = true;
		}
		if(Input.GetKeyDown(KeyCode.W) && canJump == true)
		{
			rigidbody2D.AddForce(new Vector2 (0,450));
			canJump = false;
		}
	}
}
