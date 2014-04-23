using UnityEngine;
using System.Collections;

public class AbilHandler : MonoBehaviour 
{
	Vector3 mousePos;
	Vector3 wantedPos;
	float rageDuration = 2.0f; // adjust this for rage duration.
	float TPCD = 10.0f;

	int HP;
	int Inte;
	int Str;
	int Dex;
	int HPCap;
	int Charge;
	int Damage;
	bool canRage;
	bool canTeleport;


	// Use this for initialization
	void Start () 
	{
		canRage = true;
		canTeleport = true;
	}
	// Update is called once per frame
	void Update () 
	{

		if(Input.GetMouseButtonDown(0) && canTeleport == true)
		{
			teleport ();
		}
		if(Input.GetMouseButtonDown (1) && canRage == true)
		{
			rage ();
		}
	}
	public void teleport()
	{
		mousePos = Input.mousePosition;
		wantedPos = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 3.54f));
		transform.position = wantedPos;
		canTeleport = false;
		StartCoroutine("teleportCooldown");
	}
	public void rage()
	{
		HP = GetComponent<player>().pHp;
		Inte = GetComponent<player>().pInte;
		Dex = GetComponent<player>().pDex;
		Str = GetComponent<player>().pStr;
		Charge = GetComponent<player>().pCharge;
		HPCap = GetComponent<player>().HPCap;
		Damage = GetComponent<player>().pDamage;
		Debug.Log ("First "+GetComponent<player>().pHp);
		GetComponent<player>().pHp += (int)(HP*0.3);
		GetComponent<player>().pInte -=(int)(Inte*0.3);
		GetComponent<player>().pDex += (int)(Dex*0.3);
		GetComponent<player>().pStr += (int)(Str*0.3);
		GetComponent<player>().pCharge += (int)(Charge*0.3);
		GetComponent<player>().HPCap = GetComponent<player>().pHp;
		GetComponent<player>().pDamage += (int)(Damage*0.3);
		Debug.Log ("Second "+GetComponent<player>().pHp);


		canRage = false;
		StartCoroutine("rageDurationElapse");
		Debug.Log ("After Coroutine "+GetComponent<player>().pHp);
	}
	IEnumerator rageDurationElapse()
	{
		while(true)
		{
			yield return new WaitForSeconds (rageDuration);

			GetComponent<player>().pHp -= (int)(HP*0.3);
			GetComponent<player>().pInte +=(int)(Inte*0.3);
			GetComponent<player>().pDex -= (int)(Dex*0.3);
			GetComponent<player>().pStr -= (int)(Str*0.3);
			GetComponent<player>().pCharge -= (int)(Charge*0.3);
			GetComponent<player>().HPCap = GetComponent<player>().pHp;
			GetComponent<player>().pDamage -= (int)(Damage*0.3);
			Debug.Log ("in coroutine "+GetComponent<player>().pHp);
			canRage = true;
			StopCoroutine("rageDurationElapse");
		}
	}
	IEnumerator teleportCooldown()
	{
		while(true)
		{
			yield return new WaitForSeconds (TPCD);
			canTeleport = true;
			StopCoroutine("teleportCooldown");
		}
	}
}
