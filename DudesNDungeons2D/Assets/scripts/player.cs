using UnityEngine;
using System.Collections;

public class player : MonoBehaviour 
{
    public int pHp, pInte, pDex, pStr, pCharge, pDamage = 0; //current player stats
	public int sHp, sInte, sDex, sStr, sCharge; // raw stats
	public bool invulnerable = false;
	public int HPCap, chargeCap; // HP max
	bool canJump; 
	public bool left; // moving left.
	public float dodge, crit, skillBon;
	public int SkillPoints;
	public AudioClip heartBeat;
	public Body currBody = new Body(); // this body is the current body that we can load other bodies into.
	int jump = 0;
	// Use this for initialization
	void Start () 
	{
		audio.clip = heartBeat;
		SkillPoints = 0;
		// default stat Values
		pHp = sHp = 30;
		pInte = sInte = 10;
		pDex = sDex = 10;
		pStr = sStr = 10;
		pCharge = sCharge = 100;
		HPCap = pHp;
		chargeCap = pCharge;
		pDamage = 0;
		canJump = true;

		// default Currbody Values.

	}
	// Update is called once per frame
	public bool loadGear = true; // if this is true then we load the gear.
	void Update () 
	{
		RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y), -Vector2.up, 0.3f);
		Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), -Vector2.up, Color.blue);
		if(hit != null)
		{
			if(hit.collider != null) 
			{
				if(hit.collider.tag != null && hit.collider.tag == "Floor") 
				{
					if(canJump == false)
					{
						canJump = true;
						jump = 0;
					}
				}
			}
		}

		if(pHp < HPCap/2 && !audio.isPlaying)
		{
			audio.clip = heartBeat;
			audio.loop = true;
			audio.Play ();
		}
		if(pHp > HPCap/2 && audio.isPlaying && audio.clip == heartBeat)
		{
			audio.loop = false;
			audio.Stop();
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

			dodge = (float)(pDex/2);
			skillBon = ((float)(pInte*0.1)+1);
			pCharge += ((int)(pInte*2));
			pDamage += (((int)(pStr*0.33))+1);
			pHp += ((int)(pStr*0.2))+1;
			HPCap = pHp;
			chargeCap = pCharge;
		}
		if(Input.GetKey(KeyCode.A)) // if key A move left.
		{
			transform.position -= new Vector3(0.05f,0,0);
			GetComponent<AnimHandler>().leftBool = true; // allow run of animation left.
			GetComponent<AnimHandler>().rightBool = false;
		}
		else if(Input.GetKey(KeyCode.D)) // move right.
		{
			transform.position += new Vector3(0.05f,0,0);
			GetComponent<AnimHandler>().rightBool = true;
			GetComponent<AnimHandler>().leftBool = false;
		}
		if(jump >= 2)
		{
			canJump = false; 
		}
		if(Input.GetKeyDown(KeyCode.W) && canJump == true) 
		{
			rigidbody2D.AddForce(new Vector2 (0,180));
			if(jump != 2)
			{
				jump ++;
			}
		}
	}

}
