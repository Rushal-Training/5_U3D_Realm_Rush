using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
	[SerializeField] int health = 100;
	[SerializeField] Collider collisionMesh;
	[SerializeField] ParticleSystem deathParticlePrefab,hitParticlePrefab;

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
			Destroy ( deathFx.gameObject, deathFx.main.duration );

			Destroy ( gameObject );
		}
	}
}