using UnityEngine;
using System.Collections;

public class PedestrianSpawner : MonoBehaviour {

	public GameObject[] spawnPoints;
	public GameObject spawnObject;
	public float spawnTime = 3f;

	void Start()
	{
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn()
	{
		GameObject spawnPoint = spawnPoints [Random.Range (0, spawnPoints.Length)];
		Instantiate (spawnObject, spawnPoint.transform.position, spawnPoint.transform.rotation);
	}

}
