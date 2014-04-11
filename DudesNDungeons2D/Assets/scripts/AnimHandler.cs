using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimHandler : MonoBehaviour {

	public List<Sprite> defList = new List<Sprite>();
	public List<Sprite> defListR = new List<Sprite>();

	public List<Sprite> bruteList = new List<Sprite>();
	public List<Sprite> bruteListR = new List<Sprite>();

	public List<Sprite> sneakyList = new List<Sprite>();
	public List<Sprite> sneakyListR = new List<Sprite>();

	public List<Sprite> mageList = new List<Sprite>();
	public List<Sprite> mageListR = new List<Sprite>();


	public bool rightBool;
	public bool leftBool;
	public bool idleBool;

	public Sprite walk1;
	public Sprite walk2;
	public Sprite walk1R;
	public Sprite walk2R;
	public Sprite idle;

	public Sprite bruteWalk1;
	public Sprite bruteWalk2;
	public Sprite bruteWalk1R;
	public Sprite bruteWalk2R;
	public Sprite bruteIdle;

	public Sprite sneakyWalk1;
	public Sprite sneakyWalk2;
	public Sprite sneakyWalk1R;
	public Sprite sneakyWalk2R;
	public Sprite sneakyIdle;

	public Sprite mageWalk1;
	public Sprite mageWalk2;
	public Sprite mageWalk1R;
	public Sprite mageWalk2R;
	public Sprite mageIdle;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 8; i++)
		{
			defList.Add (walk1);
			defListR.Add (walk1R);

			bruteList.Add (bruteWalk1);
			bruteListR.Add (bruteWalk1R);

			sneakyList.Add (sneakyWalk1);
			sneakyListR.Add (sneakyWalk1R);

			mageList.Add (mageWalk1);
			mageListR.Add (mageWalk1R);

		}
		for(int i = 0; i < 8; i++)
		{
			defList.Add (walk2);
			defListR.Add (walk2R);

			bruteList.Add (bruteWalk2);
			bruteListR.Add (bruteWalk2R);
			
			sneakyList.Add (sneakyWalk2);
			sneakyListR.Add (sneakyWalk2R);
			
			mageList.Add (mageWalk2);
			mageListR.Add (mageWalk2R);
		}
		
	}
	// Update is called once per frame
	int q = 0;
	void Update () 
	{
		if(rightBool == true)
		{
			if(GetComponent<player>().currBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = defList[q];

			if(GetComponent<player>().currBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = bruteList[q];

			if(GetComponent<player>().currBody.name == "sneaky")
				GetComponent<SpriteRenderer>().sprite = sneakyList[q];

			if(GetComponent<player>().currBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = mageList[q];

			rightBool = false;
		}
		if(leftBool == true)
		{
			if(GetComponent<player>().currBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = defListR[q];
			
			if(GetComponent<player>().currBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = bruteListR[q];
			
			if(GetComponent<player>().currBody.name == "sneaky")
				GetComponent<SpriteRenderer>().sprite = sneakyListR[q];
			
			if(GetComponent<player>().currBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = mageListR[q];

			leftBool = false;
		}
		if(idleBool == true)
		{
			if(GetComponent<player>().currBody.name == "Default")
				GetComponent<SpriteRenderer>().sprite = idle;
			
			if(GetComponent<player>().currBody.name == "Brute")
				GetComponent<SpriteRenderer>().sprite = bruteIdle;
			
			if(GetComponent<player>().currBody.name == "sneaky")
				GetComponent<SpriteRenderer>().sprite = sneakyIdle;
			
			if(GetComponent<player>().currBody.name == "Magus")
				GetComponent<SpriteRenderer>().sprite = mageIdle;
			idleBool = false;
		}
		if(q >= 15)
			q = 0;
		q++;
	}

}
