﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class CubeEditor : MonoBehaviour
{
	TextMesh textMesh;
	Vector3 gridPos;
	Waypoint waypoint;

	private void Awake ()
	{
		textMesh = GetComponentInChildren<TextMesh> ();
		waypoint = GetComponent<Waypoint> ();
	}

	void Update ()
	{
		SnapToGrid ();
		UpdateLabel ();
	}

	private void SnapToGrid ()
	{
		int gridSize = waypoint.GetGridSize ();
		transform.position = new Vector3 ( waypoint.GetGridPos().x * gridSize, 0f, waypoint.GetGridPos().y * gridSize );
	}

	private void UpdateLabel ()
	{
		string labelText =
			waypoint.GetGridPos ().x +
			"," +
			waypoint.GetGridPos ().y;

		textMesh.text = labelText;
		gameObject.name = labelText;
	}
}