using UnityEngine;
using System.Collections;

public class enemyHPBarControl : MonoBehaviour {

	GameObject Player;
	float startingSize;
	Transform enemyParent;
	GameObject enemyParent2;
	float minSize;
	float scaleY;
	float scaleZ;
	// Use this for initialization
	void Start () {

		enemyParent = gameObject.transform.parent;
		startingSize = transform.localScale.x;
		scaleY = transform.localScale.y;
		scaleZ = transform.localScale.z;
		minSize = startingSize/10;
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(enemyParent != null)
		{
			if(enemyParent.GetComponent<Enemy>().eHp == enemyParent.GetComponent<Enemy>().HPCap)
			{
				transform.localScale = new Vector3((minSize*10), scaleY, scaleZ);
			}
			if(enemyParent.GetComponent<Enemy>().eHp <= enemyParent.GetComponent<Enemy>().HPCap*0.9 && enemyParent.GetComponent<Enemy>().eHp >= enemyParent.GetComponent<Enemy>().HPCap*0.8)
			{
				transform.localScale = new Vector3((minSize*9), scaleY, scaleZ);
			}
			if(enemyParent.GetComponent<Enemy>().eHp <= enemyParent.GetComponent<Enemy>().HPCap*0.8 && enemyParent.GetComponent<Enemy>().eHp >= enemyParent.GetComponent<Enemy>().HPCap*0.7)
			{
				transform.localScale = new Vector3((minSize*8), scaleY, scaleZ);
			}
			if(enemyParent.GetComponent<Enemy>().eHp <= enemyParent.GetComponent<Enemy>().HPCap*0.7 && enemyParent.GetComponent<Enemy>().eHp >= enemyParent.GetComponent<Enemy>().HPCap*0.6)
			{
				transform.localScale = new Vector3((minSize*7), scaleY, scaleZ);
			}
			if(enemyParent.GetComponent<Enemy>().eHp <= enemyParent.GetComponent<Enemy>().HPCap*0.6 && enemyParent.GetComponent<Enemy>().eHp >= enemyParent.GetComponent<Enemy>().HPCap*0.5)
			{
				transform.localScale = new Vector3((minSize*6), scaleY, scaleZ);
			}
			
			if(enemyParent.GetComponent<Enemy>().eHp <= enemyParent.GetComponent<Enemy>().HPCap*0.5 && enemyParent.GetComponent<Enemy>().eHp >= enemyParent.GetComponent<Enemy>().HPCap*0.4)
			{
				transform.localScale = new Vector3((minSize*5),scaleY, scaleZ);
			}
			
			if(enemyParent.GetComponent<Enemy>().eHp <= enemyParent.GetComponent<Enemy>().HPCap*0.4 && enemyParent.GetComponent<Enemy>().eHp >= enemyParent.GetComponent<Enemy>().HPCap*0.3)
			{
				transform.localScale = new Vector3((minSize*4), scaleY, scaleZ);
			}
			
			if(enemyParent.GetComponent<Enemy>().eHp <= enemyParent.GetComponent<Enemy>().HPCap*0.3 && enemyParent.GetComponent<Enemy>().eHp >= enemyParent.GetComponent<Enemy>().HPCap*0.2)
			{
				transform.localScale = new Vector3((minSize*3), scaleY, scaleZ);
			}
			
			if(enemyParent.GetComponent<Enemy>().eHp <= enemyParent.GetComponent<Enemy>().HPCap*0.2 && enemyParent.GetComponent<Enemy>().eHp >= enemyParent.GetComponent<Enemy>().HPCap*0.1)
			{
				transform.localScale = new Vector3((minSize*2), scaleY, scaleZ);
			}
			
			if(enemyParent.GetComponent<Enemy>().eHp <= enemyParent.GetComponent<Enemy>().HPCap*0.1 && enemyParent.GetComponent<Enemy>().eHp >= enemyParent.GetComponent<Enemy>().HPCap*0.0)
			{
				transform.localScale = new Vector3((minSize*1), scaleY, scaleZ);
			}
		}

	}
}
