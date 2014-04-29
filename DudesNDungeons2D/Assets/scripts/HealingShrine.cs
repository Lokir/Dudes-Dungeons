using UnityEngine;
using System.Collections;

public class HealingShrine : MonoBehaviour {

	GameObject player;
	GameObject healingParticle;
	Transform HealingOnTent;
	bool canHeal = true;
	float Distance;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		healingParticle = GameObject.FindGameObjectWithTag ("Healing");
		HealingOnTent = transform.FindChild("Healing");
	}
	
	// Update is called once per frame
	void Update () {
		Distance = Vector3.Distance(transform.position, player.transform.position);
		if(Input.GetKeyDown(KeyCode.E) && Distance <= 2.0f && canHeal)//The player gets full hp when activating this shrine, and the particles follow
																	  //him in a short amount of time
		{
			canHeal = false;
			HealingOnTent.GetComponent<ParticleRenderer>().enabled = false;
			healingParticle.GetComponent<ParticleRenderer>().enabled = true;
			player.GetComponent<player>().pHp = player.GetComponent<player>().HPCap;
			StartCoroutine("stopParticle");
		}
	}
	IEnumerator	stopParticle()
	{
		yield return new WaitForSeconds(1.0f);
		healingParticle.GetComponent<ParticleAnimator>().damping = 0.31f;
		yield return new WaitForSeconds(0.5f);
		healingParticle.GetComponent<ParticleAnimator>().damping = 0;
		yield return new WaitForSeconds(2.0f);
		healingParticle.GetComponent<ParticleRenderer>().enabled = false;
		healingParticle.GetComponent<ParticleAnimator>().damping = 0.62f;
		StopCoroutine("stopParticle");
	}
}
