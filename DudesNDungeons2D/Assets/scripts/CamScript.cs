using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour {
	GameObject Player;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 center = new Vector3(0,0,-3.548449f);
		center += Player.transform.position;
		center.y = -1.0f;
		transform.position = Vector3.Lerp(transform.position, center, 0.2f);
	}
}
