using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Health : MonoBehaviour {


	public Slider slider;
	public float PlayerStartHealth = 100f;
//	public Image fillImage;
	public Color FullHealthColor = Color.green;
	public Color ZeroHealthColor = Color.red;

	private float CurrentHealth;
	private bool Dead;
	private AudioSource OuchAudio;


	void Awake () 
	{
		OuchAudio = GetComponent<AudioSource> ();
		//slider = GetComponent<Slider> ();
	//	fillImage = GetComponent<Image> ();
	}
	

	void OnEnable () {
		CurrentHealth = PlayerStartHealth;
		Dead = false;
		SetHealthUI ();
	}

	public void TakeDamage(float amount)
	{
		CurrentHealth -= amount;

		SetHealthUI ();
	
		if (CurrentHealth <= 0f && !Dead)
			OnDeath();
		
		
	}


	private void SetHealthUI()
	{
//		slider.value = CurrentHealth;
	//	fillImage.color = FullHealthColor.Lerp (ZeroHealthColor, FullHealthColor, CurrentHealth / PlayerStartHealth);

	}

	private void OnDeath()
	{
		Dead = true;


	}
}
