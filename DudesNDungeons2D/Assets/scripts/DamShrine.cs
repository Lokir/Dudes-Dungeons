using UnityEngine;
using System.Collections;

public class DamShrine : MonoBehaviour {

	//Damage shrines add 30% to the user for a duration of 20s.
	//while active the player will take the evil essense of the Daemon as a visual feedback.

	public GameObject DustObject;
	GameObject playStat;
	bool dustIsFollowing = true;
	float buffDuration = 20.0f;



	// Use this for initialization
	void Start () {
		playStat = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(dustIsFollowing)
			DustObject.transform.position = playStat.transform.position;

		if(Input.GetKeyDown(KeyCode.E) && !dustIsFollowing)
		   buffPlayer();
	}
	void buffPlayer()
	{
		int tmp;
		tmp = playStat.GetComponent<player>().pDamage;
		dustIsFollowing = true;
		playStat.GetComponent<player>().pDamage += (int)(playStat.GetComponent<player>().pDamage*0.3)+1;
		StartCoroutine("removeBuff", tmp);
	}
	IEnumerator removeBuff(int damage)
	{
		yield return new WaitForSeconds(buffDuration);
		playStat.GetComponent<player>().pDamage = damage;
		dustIsFollowing = false;
		Destroy(DustObject);
		StopCoroutine("removeBuff");
	}
}
