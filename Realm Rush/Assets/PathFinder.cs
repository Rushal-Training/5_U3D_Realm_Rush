﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
	[SerializeField] Waypoint startWaypoint, endWaypoint;

	Dictionary<Vector2Int, Waypoint> grid = new Dictionary<Vector2Int, Waypoint> ();
	Queue<Waypoint> queue = new Queue<Waypoint> ();
	bool isRunning = true;
	Waypoint searchCenter;

	List<Waypoint> path = new List<Waypoint> ();

	Vector2Int [] directions = {
		Vector2Int.up,
		Vector2Int.right,
		Vector2Int.down,
		Vector2Int.left
	};

	public List<Waypoint> GetPath ()
	{
		LoadBlocks ();
		SetStartAndEndColor ();
		BreadthFirstSearch ();
		CreatePath ();
		return path;
	}

	private void SetStartAndEndColor ()
	{
		// todo consider moving out
		startWaypoint.SetTopColor ( Color.green );
		endWaypoint.SetTopColor ( Color.red );
	}

	private void BreadthFirstSearch ()
	{
		queue.Enqueue ( startWaypoint );

		while ( queue.Count > 0 && isRunning )
		{
			searchCenter = queue.Dequeue ();
			//print ( "Searching from " + searchCenter );
			searchCenter.isExplored = true;
			HaltIfEndFound ();
			ExploreNeighbors ();
		}
	}

	private void HaltIfEndFound ()
	{
		if ( searchCenter == endWaypoint )
		{
			isRunning = false;
		}
	}

	private void ExploreNeighbors ()
	{
		if ( !isRunning ) { return;  }

		foreach ( Vector2Int direction in directions )
		{
			Vector2Int neighborCoords = searchCenter.GetGridPos () + direction;

			if ( grid.ContainsKey ( neighborCoords ) )
			{
				QueueNewNeighbors ( neighborCoords );
			}
		}
	}

	private void QueueNewNeighbors ( Vector2Int neighbourCoords )
	{
		Waypoint neighbour = grid [neighbourCoords];
		if ( !neighbour.isExplored && !queue.Contains(neighbour) )
		{
			queue.Enqueue ( neighbour );
			neighbour.exploredFrom = searchCenter;
		}
	}

	private void CreatePath ()
	{
		path.Add ( endWaypoint );

		Waypoint previous = endWaypoint.exploredFrom;
		while ( previous != startWaypoint )
		{
			path.Add ( previous );
			previous = previous.exploredFrom;
		}

		path.Add ( startWaypoint );
		path.Reverse ();
	}

	private void LoadBlocks()
	{
		Waypoint[] waypoints = FindObjectsOfType<Waypoint> ();

		foreach ( Waypoint waypoint in waypoints )
		{
			var gridPos = waypoint.GetGridPos ();
			if ( grid.ContainsKey ( waypoint.GetGridPos () ) )
			{
				Debug.LogWarning ( "Skipping overlapping block " + waypoint );
			}
			else
			{
				grid.Add ( gridPos, waypoint );
			}
		}
		//Debug.Log ( "Loaded " + grid.Count + " blocks" );
	}
}