using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
	[SerializeField] Transform objectToPan, targetEnemy;

	private void Update()
	{
		objectToPan.LookAt( targetEnemy );
	}
}
