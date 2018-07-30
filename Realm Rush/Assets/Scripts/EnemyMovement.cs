using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : MonoBehaviour
{
	[SerializeField] float moveSpeed = 10f;
	[SerializeField] ParticleSystem goalParticlePrefab;

	void Start ()
	{
		PathFinder pathFinder = FindObjectOfType<PathFinder> ();
		var path = pathFinder.GetPath ();

		StartCoroutine ( FollowPath ( path ) );
	}

	IEnumerator FollowPath ( List<Waypoint> waypoints )
	{
		foreach ( Waypoint waypoint in waypoints )
		{
			// Ease to point
			while ( transform.position != waypoint.transform.position )
			{
				transform.position = Vector3.MoveTowards(transform.position, waypoint.transform.position, moveSpeed * Time.deltaTime);
				yield return null;
			}
			// Hop to point
			//transform.position = waypoint.transform.position;
			//yield return new WaitForSecondsRealtime ( 1f );
		}
		DestroyEnemy ();
	}

	private void DestroyEnemy ()
	{
		ParticleSystem deathFx = Instantiate ( goalParticlePrefab, transform.position, Quaternion.identity );
		Destroy ( deathFx.gameObject, deathFx.main.duration );

		Destroy ( gameObject );

	}
}