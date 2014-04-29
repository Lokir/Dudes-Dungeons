using UnityEngine;
using System.Collections;

public class ActivateLevel1 : MonoBehaviour {
	//This script is not used
	GameObject cam;

	// Use this for initialization
	void Start () {
		cam = GameObject.FindGameObjectWithTag("MainCamera");
		cam.GetComponent<GuiTest>().inTutorial = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
