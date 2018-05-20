using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {
	public LayerMask Mask;
	public Transform FirePosition;

	private TRYAGAIN tryAgain;
	public ParticleSystem SmokeParticles;
	public float MaxLifeTime = 5f;
	public float launchForce = 30f;
	public Rigidbody2D rocket;
	//	private bool Fired;


	// Use this for initialization
	void Awake () 
	{
	//	Mask = LayerMask.GetMask("Enermies");
		SmokeParticles = GetComponent <ParticleSystem>();
		tryAgain = transform.root.GetComponent<TRYAGAIN>();//为什么用root?Returns the topmost transform in the hierarchy.
	}




	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			Fire ();

		}
	}
		


	/*
	void Fire()
	{
	//	bool lr = TRYAGAIN.facingRight
		//Rigidbody2D rocketInstance = Instantiate (rocket, FirePosition.position, FirePosition.rotation) as Rigidbody2D;

		if (TRYAGAIN.facingRight)
 {		//	
			// ... instantiate the rocket facing right and set it's velocity to the right. 
			Rigidbody2D rocketInstance = Instantiate (rocket, FirePosition.position, Quaternion.Euler (new Vector3 (0, 0, 0))) as Rigidbody2D;
			rocketInstance.velocity = new Vector2 (launchForce, 0);
		}

		else
		{	Rigidbody2D rocketInstance = Instantiate(rocket, FirePosition.position, Quaternion.Euler(new Vector3(0,0,180f))) as Rigidbody2D;

			rocketInstance.velocity = new Vector2(-launchForce, 0);
		}


	}
		*/


	void Fire()
	{
	//	bool lr = TRYAGAIN.facingRight
			//Rigidbody2D rocketInstance = Instantiate (rocket, FirePosition.position, FirePosition.rotation) as Rigidbody2D;
  
		
		if (TRYAGAIN.facingRight) {
			
			Rigidbody2D rocketInstance = Instantiate (rocket, FirePosition.position, FirePosition.rotation) as Rigidbody2D;
			rocketInstance.velocity = launchForce * FirePosition.right;
		} 

		else 
		{
			
			Rigidbody2D rocketInstance = Instantiate (rocket, FirePosition.position, FirePosition.rotation) as Rigidbody2D;
			rocketInstance.velocity = -launchForce * FirePosition.right;
		}
		//rocketInstance.velocity = new Vector2(l * LaunchForce * FirePosition.left ,rocketInstance.velocity.y);

		//rocketInstance.velocity = LaunchForce* 
	//	GetComponent<Rigidbody2D>().velocity = new Vector2( moveSpeed * transform.localScale.x,GetComponent<Rigidbody2D>().velocity.y);	



	}


}
