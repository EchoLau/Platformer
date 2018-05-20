using UnityEngine;
using System.Collections;

public class TRYAGAIN : MonoBehaviour
{
	[HideInInspector]
	public static bool facingRight = true;			// For determining which way the player is currently facing.

	public float jumpForce = 10f;
	public float moveForce = 365f;			// Amount of force added to move the player left and right.
	public float maxSpeed = 10f;				// The fastest the player can travel in the x axis.
	public float vSpeed;

	private Rigidbody2D rb2d;
	private Animator anim;
	private AudioSource jumpAudio;

	public bool grounded;				// Condition for whether the player should jump.
	public Transform groundCheck;			// 一个你会建立在PLAYER脚下的OBJECT.用来CHECK立个点周围有没有地板
	public LayerMask whatIsGround;			// 所有当作地板的都集合成LAYER
	private float groundRadius = 0.2f;

	void Awake()
	{
		// Setting up references.
		//groundCheck = transform.Find("GroundCheck");
		rb2d = GetComponent <Rigidbody2D>();
		anim = GetComponent<Animator>();
		jumpAudio = GetComponent<AudioSource> ();
	}

	void Update()//跳起来SPACE容易被FIXEDUPDATE MISS，所以跳起来在UPDATE里
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			rb2d.AddForce(new Vector2(0,jumpForce));
			jumpAudio.Play ();
		}
	}

	void FixedUpdate ()
	{
		//是否在立个CIRCLE范围内碰到任何的COLLIDER, GROUNDCHECK就在立个Position上形成一个CIRCLE
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
	//	if (grounded = false)
	//	anim.SetTrigger ("Ground");

		anim.SetBool ("Ground", grounded);

		float h = Input.GetAxis ("Horizontal");
		anim.SetFloat ("Move", Mathf.Abs(h));

		rb2d.velocity = new Vector2(h * maxSpeed, rb2d.velocity.y);

		// If the input is moving the player right and the player is facing left...
		if (h > 0 && !facingRight)
			// ... flip the player.
			Flip ();
		// Otherwise if the input is moving the player left and the player is facing right...
		else if (h < 0 && facingRight)
			// ... flip the player.IF之后如果只有一行CODE，可以不用{}，直接写下面：
			Flip ();
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






