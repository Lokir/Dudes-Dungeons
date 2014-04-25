using UnityEngine;
using System.Collections;

public class CamScript : MonoBehaviour {
	GameObject Player;
	// Use this for initialization
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player"); // find player so we can locate him.
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 center = new Vector3(0,0,-3.548449f); // center on his position, set Z so it is encompassing player and gameworld.
		center += Player.transform.position; // update center with new position of player.
		center.y = -3.16f; // center y so camera is stationary.
		transform.position = Vector3.Lerp(transform.position, center, 0.2f); // make the camera lerp to give a smooth movement feeling.
	}
}
