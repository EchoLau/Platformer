using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathRiver : MonoBehaviour {


	Collider2D Col;

	void Start () {

		Collider2D col = GetComponent<Collider2D> ();
	}
	
	// Update is called once per frame
	void Update () {



	}




	void OnTriggerEnter2D (Collider2D other)
	{

	
		if (other.gameObject.CompareTag ("Player")) 
		
		{
			Destroy (other.gameObject, 2f);
			Application.LoadLevel (Application.loadedLevel);
		}


	}
}

