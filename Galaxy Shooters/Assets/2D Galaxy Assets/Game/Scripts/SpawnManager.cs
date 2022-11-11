using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {

	[SerializeField]
	private GameObject enemyPrefab;
	[SerializeField]
	private GameObject[] powerups;
	// Use this for initialization
	void Start () {
		StartCoroutine (spawnEnemy ());
		StartCoroutine (spawnPowerups ());
	}

	IEnumerator spawnEnemy()
	{
		while (true) 
		{
			Instantiate (enemyPrefab, transform.position, Quaternion.identity);
			yield return new WaitForSeconds (3f);
		}
	}
	IEnumerator spawnPowerups()
	{
		while (true) 
		{
			int randomPowerup = Random.Range (0, 3);
			Instantiate (powerups[randomPowerup], new Vector3(Random.Range(-7f,7f),transform.position.y,0), Quaternion.identity);
			yield return new WaitForSeconds (5f);
		}
	}
}
