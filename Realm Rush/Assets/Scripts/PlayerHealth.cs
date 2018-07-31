using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	[SerializeField] int health = 25;
	[SerializeField] Text livesText;
	[SerializeField] AudioClip lifeLostSfx;

	void Start()
	{
		livesText.text = health.ToString();
	}

	private void OnTriggerEnter( Collider collider )
	{
		health--;
		livesText.text = health.ToString();
		GetComponent<AudioSource>().PlayOneShot( lifeLostSfx );
	}
}
