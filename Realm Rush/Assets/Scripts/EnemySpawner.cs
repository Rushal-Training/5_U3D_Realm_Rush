using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
	[Range(0.1f, 120f)][SerializeField] float secondsBetweenSpawns = 5f;
	[SerializeField] Enemy enemyPrefab;

	void Start ()
	{
		StartCoroutine ( SpawnEnemies () );
	}
	
	void Update ()
	{
		
	}

	IEnumerator SpawnEnemies ()
	{
		while ( true )
		{
			Instantiate ( enemyPrefab, transform.position, Quaternion.identity );
			yield return new WaitForSecondsRealtime ( secondsBetweenSpawns );
		}
	}
}
