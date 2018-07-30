using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int health = 100;
	[SerializeField] Collider collisionMesh;
	[SerializeField] ParticleSystem deathParticlePrefab,hitParticlePrefab;

	void Start ()
	{
		AddBoxCollider ();
	}
	
	void Update ()
	{
		
	}

	private void AddBoxCollider ()
	{
		/*Transform child = gameObject.GetComponentInChildren<Transform> ().GetChild(0);
		BoxCollider boxCollider = child.gameObject.AddComponent<BoxCollider> ();
		BoxCollider boxCollider = gameObject.AddComponent<BoxCollider> ();
		boxCollider.isTrigger = false;*/
	}

	private void OnParticleCollision ( GameObject other )
	{
		ProcessHit ( other );
		DestroyEnemy ();
	}

	private void ProcessHit ( GameObject other )
	{
		hitParticlePrefab.Play ();
		Tower tower = other.GetComponentInParent<Tower> ();
		health -= tower.GetDamagePerShot ();
	}

	private void DestroyEnemy ()
	{
		if ( health <= 0 )
		{
			ParticleSystem deathFx = Instantiate ( deathParticlePrefab, transform.position, Quaternion.identity );
			Destroy ( gameObject );
		}
	}
}