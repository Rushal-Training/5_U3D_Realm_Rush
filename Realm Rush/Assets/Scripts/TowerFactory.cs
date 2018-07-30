using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerFactory : MonoBehaviour
{
	[SerializeField] int towerLimit = 5;
	[SerializeField] Tower towerPrefab;

	Queue<Tower> towers = new Queue<Tower> ();

	public void AddTower ( Waypoint waypoint )
	{
		if ( towers.Count < towerLimit )
		{
			InstantiateTower ( waypoint );
		}
		else
		{
			MoveExistingTower ( waypoint );
		}

	}

	private void InstantiateTower ( Waypoint waypoint )
	{
		Tower tower = Instantiate ( towerPrefab, waypoint.transform.position, Quaternion.identity );
		waypoint.isPlaceable = false;

		tower.waypoint = waypoint;
		towers.Enqueue ( tower );
	}

	private void MoveExistingTower ( Waypoint waypoint )
	{
		Tower tower = towers.Dequeue ();
		tower.waypoint.isPlaceable = true;
		waypoint.isPlaceable = false;
		tower.transform.position = waypoint.transform.position;
		tower.waypoint = waypoint;
		towers.Enqueue ( tower );
	}
}
