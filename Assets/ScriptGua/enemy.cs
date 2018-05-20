using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {
	[HideInInspector]
	public bool facingRight = true;		

		public float moveSpeed = 2f;		// The speed the enemy moves at.

		private SpriteRenderer ren;			// Reference to the sprite renderer.

		private bool dead = false;			// Whether or not the enemy is dead.

	public Transform wallDetect;

	//GameObject Wall;

		void Awake()
		{
			// Setting up the references.
			ren = transform.Find("enemy1-body").GetComponent<SpriteRenderer>();
		//	wallDetect = transform.Find("wallDetect");

		}

	void Update()
	{
	// Create an array of all the colliders in front of the enemy.
		Collider2D[] walls = Physics2D.OverlapCircleAll (wallDetect.position, 1);

	// Check each of the colliders.
		foreach(Collider2D c in walls)
	{
			if(c.tag == "Wall")
			{
				// ... Flip the enemy and stop checking the other colliders.
				Flip ();
				break;
		
		}
		}
	}
		

		void FixedUpdate ()
		{

			// Set the enemy's velocity to moveSpeed in the x direction.
		GetComponent<Rigidbody2D>().velocity = new Vector2( moveSpeed * transform.localScale.x,GetComponent<Rigidbody2D>().velocity.y);	

		}

void Flip ()
{
	// Switch the way the player is labelled as facing.
	facingRight = !facingRight;

	// GEt local scale, flip, apply to local scale. Multiply the player's x local scale by -1.
	Vector3 theScale = transform.localScale;
	theScale.x *= -1;
	transform.localScale = theScale;
}
	}
//transform.localScale.x *moveSpeed,