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

	IEnumerator SpawnEnemies ()
	{
		while ( true )
		{
			Enemy enemy = Instantiate ( enemyPrefab, transform.position, Quaternion.identity );
			enemy.transform.parent = transform;
			yield return new WaitForSecondsRealtime ( secondsBetweenSpawns );
		}
	}
}
