using UnityEngine;
using System.Collections;

public class ActivateTutorial : MonoBehaviour {

	GameObject cam;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		cam.GetComponent<GuiTest>().inTutorial = true; // we added this variable to control the elements of Tutorial
	}
	
	// Update is called once per frame
	void Update () {

	}
}
