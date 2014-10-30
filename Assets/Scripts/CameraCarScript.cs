using UnityEngine;
using System.Collections;

public class CameraCarScript : MonoBehaviour {

	public Transform player;
	public float height = 1f;
	public float behind = 3f;
	public float lookUp = 1f;
	public float smoothness = 5f;
	public bool enabled = true;

	void Awake () {

	}

	// Update is called once per frame
	void Update () {
		if (enabled) {
			Vector3 position = player.position;
			position.y += height;
			position -= (player.forward * behind);
			transform.position = Vector3.Lerp (transform.position, position, smoothness * Time.deltaTime);

			transform.LookAt (player);
			Vector3 rotation = transform.rotation.eulerAngles;
			rotation.x -= lookUp;
			transform.rotation = Quaternion.Euler (rotation);
		}
	}
}
