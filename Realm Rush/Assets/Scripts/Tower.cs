using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	[SerializeField] Transform objectToPan;
	[Range ( 10f, 1000f )] [SerializeField] float attackRange;
	[SerializeField] ParticleSystem projectileParticle;

	private Transform targetEnemy;
	private int damagePerShot = 25;

	void Start ()
	{
		
	}

	private void Update()
	{
		SetTargetEnemy ();
		if ( targetEnemy )
		{
			FireAtEnemy ();
		}
		else
		{
			Shoot ( false );
		}
	}

	private void SetTargetEnemy ()
	{
		var sceneEnemies = FindObjectsOfType<Enemy> ();
		if ( sceneEnemies.Length == 0 ) { return; }

		Transform closestEnemy = sceneEnemies [0].transform;

		foreach ( Enemy testEnemy in sceneEnemies )
		{
			closestEnemy = GetClosest ( closestEnemy, testEnemy.transform );
		}

		targetEnemy = closestEnemy;

	}

	private Transform GetClosest ( Transform closestEnemy, Transform testEnemy )
	{
		float distanceOne = Vector3.Distance ( closestEnemy.position, transform.position );
		float distanceTwo = Vector3.Distance ( testEnemy.position, transform.position );

		if ( distanceOne < distanceTwo )
			return closestEnemy;
		else
			return testEnemy;
	}

	private void FireAtEnemy ()
	{
		float distanceToEnemy = Vector3.Distance ( targetEnemy.position, transform.position );
		if ( distanceToEnemy <= attackRange )
		{
			objectToPan.LookAt ( targetEnemy );
			Shoot ( true );
		}
		else
		{
			Shoot ( false );
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