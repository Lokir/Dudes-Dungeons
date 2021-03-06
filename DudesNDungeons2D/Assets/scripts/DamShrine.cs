﻿using UnityEngine;
using System.Collections;

public class DamShrine : MonoBehaviour {

	//Damage shrines add 30% to the user for a duration of 20s.
	//while active the player will take the evil essense of the Daemon as a visual feedback.
	
	GameObject DaemonDust;
	public Sprite Daemon;
	public Sprite DaemonAura;
	GameObject player;
	float buffDuration = 20.0f;
	float Distance;
	public AudioClip laugh;


	// Use this for initialization
	void Start () {
		audio.clip = laugh;
		DaemonDust = GameObject.FindGameObjectWithTag("DaemonDust");
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Distance = Vector3.Distance(transform.position, player.transform.position);
		if(Input.GetKeyDown(KeyCode.E) && !DaemonDust.GetComponent<DaemonAura>().activateAura && Distance <= 1.0f)
		{
		   buffPlayer();
			audio.Play ();
		}
	}
	void buffPlayer()
	{
		int tmp;
		tmp = player.GetComponent<player>().pDamage;
		DaemonDust.GetComponent<DaemonAura>().activateAura = true;
		GetComponent<SpriteRenderer>().sprite = Daemon;//make the sprites that illustrate that the player has the damage buff
		player.GetComponent<player>().pDamage += (int)(player.GetComponent<player>().pDamage*0.3)+1;
		StartCoroutine("removeBuff", tmp);
	}
	IEnumerator removeBuff(int damage)//timer for when to remove the buff again
	{
		yield return new WaitForSeconds(buffDuration);
		player.GetComponent<player>().pDamage = damage;
		DaemonDust.GetComponent<DaemonAura>().activateAura = false;
		GetComponent<SpriteRenderer>().sprite = DaemonAura;
		StopCoroutine("removeBuff");
	}
}
