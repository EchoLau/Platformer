using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour {

	//private GameObject rocket;
	public LayerMask Mask;
	public float MaxLifeTime = 4f;
	public float RocketDamage = 1;
	public float ExplosionRadius = 5f;

	private Rigidbody2D rb;

	private void Start()
	{
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		Destroy (gameObject, MaxLifeTime);


	}

	private void OnTriggerEnter2D(Collider2D other)
	{



		if (other.gameObject.CompareTag ("Enemy")) {
			//Destroy (other.gameObject);
			Destroy (gameObject);
			EnemyHealth enemyHealth = other.GetComponent<EnemyHealth> ();
			if (enemyHealth != null) {
				enemyHealth.TakeDamage (RocketDamage);
			}
		
		}

		if (other.gameObject.CompareTag ("Wall")) {
			//Destroy (other.gameObject);
			Destroy (gameObject);

			if (other.gameObject.CompareTag ("ground")) {
				//Destroy (other.gameObject);
				Destroy (gameObject);

			}

		}

	}


	/*


		Collider[] colliders = Physics.OverlapSphere (transform.position, ExplosionRadius, Mask);

		for (int i = 0; i < colliders.Length; i++) {
			Rigidbody2D targetRigidbody = colliders [i].GetComponent<Rigidbody2D> ();


			Destroy (gameObject);
		}
			

			if (!targetRigidbody)
				continue;
			
			EnemyHealth enemyHealth = targetRigidbody.GetComponent<EnemyHealth> ();

			if (enemyHealth != null) {
				enemyHealth.TakeDamage (RocketDamage);
			}


		}

		


		if (other.gameObject.CompareTag ("Pick Up")) 
		{
			Destory(other.gameObject);
			Destory (gameobject);

		}

		}
*/



	}
