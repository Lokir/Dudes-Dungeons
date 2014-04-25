using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DaemonAura : MonoBehaviour {

	GameObject player;
	public bool activateAura;
	
	public Sprite aura1;
	public Sprite aura2;
	public Sprite aura3;
	public Sprite aura4;
	public Sprite aura5;
	public Sprite aura6;
	public Sprite aura7;
	public Sprite aura8;
	public Sprite aura9;
	public Sprite aura10; // these sprites load the images needed for the animation.
	public Sprite none; // if not active make sure it is not visible.
	
	public List<Sprite> auraList = new List<Sprite>(); // lists to contain the animations,
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player"); // find player.
		
		for(int i = 0; i < 4; i++) // load in segments of the animation using all these SMALL for loops, only once.
			auraList.Add (aura1);
		for(int i = 0; i < 4; i++)
			auraList.Add (aura2);
		for(int i = 0; i < 4; i++)
			auraList.Add (aura3);
		for(int i = 0; i < 4; i++)
			auraList.Add (aura4);
		for(int i = 0; i < 4; i++)
			auraList.Add (aura5);
		for(int i = 0; i < 4; i++)
			auraList.Add (aura6);
		for(int i = 0; i < 4; i++)
			auraList.Add (aura7);
		for(int i = 0; i < 4; i++)
			auraList.Add (aura8);
		for(int i = 0; i < 4; i++)
			auraList.Add (aura9);
		for(int i = 0; i < 4; i++)
			auraList.Add (aura10);
	}
	// Update is called once per frame
	int C = 0; // C is used to control the animations.
	
	void Update () 
	{
		if(activateAura) // if player moving left
		{
			transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
			GetComponent<SpriteRenderer>().sprite = auraList[C];
			if(C >= 19) // make sure list parameters aren't broken.
				C=0;
			C++; // advance one step.
		}
		
		if(!activateAura) // if no longer active make render into nothing and set C to 0.
		{
			GetComponent<SpriteRenderer>().sprite = none;
			C = 0;
		}
	}
}
