using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

	void Start ()
	{
		PathFinder pathFinder = FindObjectOfType<PathFinder> ();
		var path = pathFinder.GetPath ();

		StartCoroutine ( FollowPath ( path ) );
	}

	IEnumerator FollowPath ( List<Waypoint> waypoints)
	{
		foreach ( Waypoint waypoint in waypoints )
		{
			transform.position = waypoint.transform.position;
			yield return new WaitForSecondsRealtime ( 1f );
		}
	}
}