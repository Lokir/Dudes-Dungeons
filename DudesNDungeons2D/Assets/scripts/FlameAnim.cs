using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlameAnim : MonoBehaviour {

	GameObject player;
	public bool throwFire;

	public Sprite fCone1;
	public Sprite fCone2;
	public Sprite fCone3;
	public Sprite fCone4;
	public Sprite fCone5;
	public Sprite RfCone1;
	public Sprite RfCone2;
	public Sprite RfCone3;
	public Sprite RfCone4;
	public Sprite RfCone5; // these sprites load the images needed for the animation.
	public Sprite none; // if not active make sure it is not visible.

	public List<Sprite> ConeFire = new List<Sprite>(); // lists to contain the animations,
	public List<Sprite> RConeFire = new List<Sprite>();
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player"); // find player.

		for(int i = 0; i < 4; i++) // load in segments of the animation using all these SMALL for loops, only once.
			ConeFire.Add (fCone1);
		for(int i = 0; i < 4; i++)
			ConeFire.Add (fCone2);
		for(int i = 0; i < 4; i++)
			ConeFire.Add (fCone3);
		for(int i = 0; i < 4; i++)
			ConeFire.Add (fCone4);
		for(int i = 0; i < 4; i++)
			ConeFire.Add (fCone5);

		for(int i = 0; i < 4; i++)
			RConeFire.Add (RfCone1);
		for(int i = 0; i < 4; i++)
			RConeFire.Add (RfCone2);
		for(int i = 0; i < 4; i++)
			RConeFire.Add (RfCone3);
		for(int i = 0; i < 4; i++)
			RConeFire.Add (RfCone4);
		for(int i = 0; i < 4; i++)
			RConeFire.Add (RfCone5);

		throwFire = false;
	}
	// Update is called once per frame
	int C = 0; // C is used to control the animations.

	void Update () 
	{
		if(player.GetComponent<player>().currBody.bruteAbil == true) // if player is wearing a mage body (only one who can use this abil)
		{
			if(player.GetComponent<player>().left == true) // if player moving left
			{
				transform.position = new Vector3(player.transform.position.x-0.5f,player.transform.position.y,0); // move the animation left.
			}
			else 
			{
				transform.position = new Vector3(player.transform.position.x+0.5f,player.transform.position.y,0); // else move the animation right
			}

			if(throwFire == false) // if no longer active make render into nothing and set C to 0.
			{
				GetComponent<SpriteRenderer>().sprite = none;
				C = 0;
			}

			if(throwFire == true) // if active, render animation.
			{

				if(player.GetComponent<player>().left == true) // if left, render inverse images in sequence.
					GetComponent<SpriteRenderer>().sprite = RConeFire[C];
				else // else render standard images.
					GetComponent<SpriteRenderer>().sprite = ConeFire[C];
					if(C >= 19) // make sure list parameters aren't broken.
						C=0;
				C++; // advance one step.
			}
		}
	}
}
