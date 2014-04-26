using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	GameObject player;
	public GameObject Spawn;
	bool canSpawn = false;
	bool hasAppeared;
	public bool assault = false;
	
	private int spawned = 0;
	public Sprite _1;
	public Sprite _2;
	public Sprite _3;
	public Sprite _4;
	public Sprite _5;

	public List<Sprite> animList = new List<Sprite>();

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");

		animationLoad(_5);
		animationLoad(_1);
		animationLoad(_2);
		animationLoad(_3);
		animationLoad(_4);
		animationLoad(_5);
	}
	
	// Update is called once per frame
	int i = 0;
	float x = 0.0f;
	float Distance;
	void Update () {
		transform.Rotate (Vector3.forward * 1);
		transform.localScale = new Vector3(x,x,x);
		GetComponent<SpriteRenderer>().sprite = animList[i];
		Distance = Vector3.Distance(player.transform.position, transform.position);
		if(Distance < 2.0f && !hasAppeared || assault == true)
		{
			if(x >= 0.3)
			{
				assault = false;
				canSpawn = true;
				hasAppeared = true;
			}
			if(x == 0)
				x= 0.1f;
			x += x*0.03f;
		}

		if(hasAppeared)
		{
			if(canSpawn)
				spawning();

			canSpawn = false;
			if(x <= 0.1)
				Destroy (gameObject);

			x -= x*0.03f;
		}
		if(i >= 45)
			i=0;
		i++;

	}
	void animationLoad(Sprite txtr)
	{
		for(int i = 0; i < 8; i++)
			animList.Add (txtr);
	}
	void spawning(){
		Instantiate (Spawn, new Vector3((transform.position.x + 2.0f),transform.position.y, transform.position.z), Quaternion.identity);
		Instantiate (Spawn, new Vector3((transform.position.x - 2.0f),transform.position.y, transform.position.z), Quaternion.identity);
		Instantiate (Spawn, new Vector3((transform.position.x + 1.0f),transform.position.y, transform.position.z), Quaternion.identity);
	}
}
