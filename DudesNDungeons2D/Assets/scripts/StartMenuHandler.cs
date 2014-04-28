using UnityEngine;
using System.Collections;

public class StartMenuHandler : MonoBehaviour {

	public bool isQuitButton = false;
	public bool startGame = false;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseEnter()
	{
		//change the color of the text
		renderer.material.color = Color.red;
	}

	void OnMouseExit()
	{
		//change color back to white
		renderer.material.color = Color.white;
	}

	void OnMouseUp()
	{
		//Finding the quit button
		if(isQuitButton){
			//Quit the game
			Application.Quit();
		}
		else if(startGame)
		{
			//Load the game scene such that the game can start
			Application.LoadLevel(2);
		}
		else
		{
			//load a scene full of text how to play the game
			Application.LoadLevel(1);
		}
	}
}
