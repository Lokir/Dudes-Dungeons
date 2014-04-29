using UnityEngine;
using System.Collections;

public class ExplosionShrine : MonoBehaviour {


	GameObject player;
	GameObject[] Enemies;
	public Transform Explosion;
	float Distance;
	public Sprite None;
	public AudioClip boom;
	
	// Use this for initialization
	void Start () {
		audio.clip = boom;
		Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Distance = Vector3.Distance(transform.position, player.transform.position); // distance between 
		if(Input.GetKeyDown(KeyCode.E) && Distance <= 1.0f)
		{
			explode();
			audio.Play();
		}
	}
	void explode()
	{
		if(player.transform.position.x < transform.position.x)
			player.rigidbody2D.AddForce (new Vector2(-300,0)); // add force of the explosion.
		if(player.transform.position.x > transform.position.x)
			player.rigidbody2D.AddForce (new Vector2(300,0));

		foreach (GameObject e in Enemies)
		{
			if(e!=null)
			{
				float eDistance = Vector3.Distance (transform.position, e.transform.position); // get distance between player and object.
				if(eDistance <= 2.0)
				{
					if(e.transform.position.x < transform.position.x) // addforce differently from player because mass is different.
						e.rigidbody2D.AddForce(new Vector2(-20,0));
					if(e.transform.position.x > transform.position.x)
						e.rigidbody2D.AddForce(new Vector2(20,0));
						e.GetComponent<Enemy>().eHp -= 30;
				}
			}
		}
		Instantiate (Explosion, new Vector3(transform.position.x ,transform.position.y, transform.position.z), Quaternion.identity); // explode
		GetComponent<SpriteRenderer>().sprite = None; // remove the sprite but keep the gameObject until sound is finished playing.
		Destroy(gameObject, audio.clip.length);
	}
}
