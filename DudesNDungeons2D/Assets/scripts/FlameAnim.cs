using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FlameAnim : MonoBehaviour {

	GameObject PlayStat;

	public Sprite fCone1;
	public Sprite fCone2;
	public Sprite fCone3;
	public Sprite fCone4;
	public Sprite fCone5;
	public Sprite RfCone1;
	public Sprite RfCone2;
	public Sprite RfCone3;
	public Sprite RfCone4;
	public Sprite RfCone5;
	public Sprite none;

	public List<Sprite> ConeFire = new List<Sprite>();
	public List<Sprite> RConeFire = new List<Sprite>();
	// Use this for initialization
	void Start () {
		PlayStat = GameObject.FindGameObjectWithTag("Player");

		for(int i = 0; i < 4; i++)
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
	}
	// Update is called once per frame
	int C = 0;

	void Update () 
	{
		if(PlayStat.GetComponent<player>().currBody.mageAbil == true)
		{
			if(PlayStat.GetComponent<player>().left == true)
			{
				transform.position = new Vector3(PlayStat.transform.position.x-2,PlayStat.transform.position.y,0);
			}
			else 
			{
				transform.position = new Vector3(PlayStat.transform.position.x+2,PlayStat.transform.position.y,0);
			}

			if(Input.GetKeyUp (KeyCode.R))
			{
				GetComponent<SpriteRenderer>().sprite = none;
				C = 0;
			}

			if(Input.GetKey (KeyCode.R))
			{
				if(PlayStat.GetComponent<player>().left == true)
					GetComponent<SpriteRenderer>().sprite = RConeFire[C];
				else
					GetComponent<SpriteRenderer>().sprite = ConeFire[C];
					if(C >= 19)
						C=0;
				C++;
			}
		}
	}
}
