using UnityEngine;
using System.Collections;

public class DamShrine : MonoBehaviour {

	//Damage shrines add 30% to the user for a duration of 20s.
	//while active the player will take the evil essense of the Daemon as a visual feedback.
	
	GameObject DaemonDust;
	public Sprite Daemon;
	public Sprite DaemonAura;
	GameObject player;
	float buffDuration = 20.0f;



	// Use this for initialization
	void Start () {
		DaemonDust = GameObject.FindGameObjectWithTag("DaemonDust");
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.E) && !DaemonDust.GetComponent<DaemonAura>().activateAura)
		   buffPlayer();
	}
	void buffPlayer()
	{
		int tmp;
		tmp = player.GetComponent<player>().pDamage;
		DaemonDust.GetComponent<DaemonAura>().activateAura = true;
		GetComponent<SpriteRenderer>().sprite = Daemon;
		player.GetComponent<player>().pDamage += (int)(player.GetComponent<player>().pDamage*0.3)+1;
		StartCoroutine("removeBuff", tmp);
	}
	IEnumerator removeBuff(int damage)
	{
		yield return new WaitForSeconds(buffDuration);
		player.GetComponent<player>().pDamage = damage;
		DaemonDust.GetComponent<DaemonAura>().activateAura = false;
		GetComponent<SpriteRenderer>().sprite = DaemonAura;
		StopCoroutine("removeBuff");
	}
}
