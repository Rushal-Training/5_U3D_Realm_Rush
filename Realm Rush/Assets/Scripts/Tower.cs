using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	[SerializeField] Transform objectToPan, targetEnemy;
	[Range ( 10f, 1000f )] [SerializeField] float attackRange;
	[SerializeField] ParticleSystem projectileParticle;

	private Enemy [] enemies;
	private int damagePerShot = 25;

	void Start ()
	{
		
	}

	private void Update()
	{
		enemies = FindObjectsOfType<Enemy> ();
		if (enemies.Length > 0)
		{
			FireAtEnemy ();
		}
		else
		{
			Shoot ( false );
		}
	}

	private void FireAtEnemy ()
	{
		foreach ( Enemy enemy in enemies )
		{
			float distanceToEnemy = Vector3.Distance ( enemy.transform.position, transform.position );
			if ( distanceToEnemy <= attackRange )
			{
				objectToPan.LookAt ( enemy.transform );
				Shoot ( true );
			}
			else
			{
				Shoot ( false );
			}
		}
	}

	private void Shoot ( bool isActive )
	{	
		var emission = projectileParticle.emission;
		emission.enabled = isActive;
	}

	public int GetDamagePerShot ()
	{
		return damagePerShot;
	}
}
