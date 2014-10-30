using UnityEngine;
using System.Collections;

public class RaceController : MonoBehaviour {

	public GameObject[] checkpoints;
	public int laps = 3;
	public GameObject UIcheckpoint;
	public GameObject player;

	protected float checkpointTimer = 0f;

	void Start()
	{
		UIcheckpoint.SetActive (false);
	}

	void Update()
	{
		if (checkpointTimer > 0)
		{
			checkpointTimer -= Time.deltaTime;
		}
		if (UIcheckpoint.activeSelf && checkpointTimer <= 0)
		{
			UIcheckpoint.SetActive (false);
		}
	}

	void FixedUpdate()
	{
		checkForCheckpoints ();
	}

	void checkForCheckpoints()
	{
		foreach(GameObject checkpoint in checkpoints)
		{
			if(player.collider.bounds.Intersects(checkpoint.collider.bounds))
			{
				flashCheckpoint();
			}
		}
	}

	void flashCheckpoint()
	{
		checkpointTimer = 3f;
		UIcheckpoint.SetActive (true);
	}
}
