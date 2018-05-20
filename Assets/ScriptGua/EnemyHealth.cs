using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	public float startingHealth=5f;
	public float currentHealth;
	bool isDead;

	public float deathSpinMin = -100f;
	public float deathSpinMax = 100f;


	PolygonCollider2D polygonCollider;

	private void Awake()
	{
		currentHealth = startingHealth;
		polygonCollider = GetComponent<PolygonCollider2D> ();

	}

	public void TakeDamage (float RocketDamage)
	{
		if (isDead)
			return;
		currentHealth -= RocketDamage;

		if(currentHealth <=0)
			Death();

	}

	void Death()
	{
		isDead = true;
		polygonCollider.isTrigger = true;  // why does it has to become a trigger?

		GetComponent<Rigidbody2D> ().AddTorque (Random.Range (deathSpinMin, deathSpinMax));
	
	//	Destroy (gameobject, 2f);
	
	}


}
