using UnityEngine;
using System.Collections;

public class ExplosionShrine : MonoBehaviour {


	GameObject player;
	GameObject[] Enemies;
	public Transform Explosion;
	float Distance;
	
	
	
	// Use this for initialization
	void Start () {
		Enemies = GameObject.FindGameObjectsWithTag("Enemy");
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Distance = Vector3.Distance(transform.position, player.transform.position);
		if(Input.GetKeyDown(KeyCode.E) && Distance <= 1.0f)
			explode();
	}
	void explode()
	{
		if(player.transform.position.x < transform.position.x)
			player.rigidbody2D.AddForce (new Vector2(-300,0));
		if(player.transform.position.x > transform.position.x)
			player.rigidbody2D.AddForce (new Vector2(300,0));

		foreach (GameObject e in Enemies)
		{
			float eDistance = Vector3.Distance (transform.position, e.transform.position);
			if(eDistance <= 2.0)
			{
				if(e.transform.position.x < transform.position.x)
					e.rigidbody2D.AddForce(new Vector2(-20,0));
				if(e.transform.position.x > transform.position.x)
					e.rigidbody2D.AddForce(new Vector2(20,0));
					e.GetComponent<Enemy>().eHp -= 30;
			}
		}
		Instantiate (Explosion, new Vector3(transform.position.x ,transform.position.y, transform.position.z), Quaternion.identity);
		Destroy(gameObject);
	}
}
