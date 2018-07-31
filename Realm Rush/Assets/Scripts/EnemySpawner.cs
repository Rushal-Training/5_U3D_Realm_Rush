using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
	[Range(0.1f, 120f)][SerializeField] float secondsBetweenSpawns = 5f;
	[SerializeField] Enemy enemyPrefab;
	[SerializeField] Text scoreText;
	[SerializeField] AudioClip spawnEnemySfx;

	private int numEnemies;

	void Start ()
	{
		scoreText.text = numEnemies.ToString();
		StartCoroutine ( SpawnEnemies () );
	}

	IEnumerator SpawnEnemies ()
	{

		while ( true )
		{
			numEnemies++;
			scoreText.text = numEnemies.ToString();

			GetComponent<AudioSource>().PlayOneShot( spawnEnemySfx );

			Enemy enemy = Instantiate ( enemyPrefab, transform.position, Quaternion.identity );
			enemy.transform.parent = transform;
			yield return new WaitForSecondsRealtime ( secondsBetweenSpawns );
		}
	}
}
