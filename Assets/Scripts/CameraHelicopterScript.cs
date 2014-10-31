using UnityEngine;
using System.Collections;

public class CameraHelicopterScript : MonoBehaviour {
	
	public Transform helicopter;
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
			Vector3 position = helicopter.position;
			position.y += height;
			position -= (helicopter.forward * behind);
			transform.position = Vector3.Lerp (transform.position, position, smoothness * Time.deltaTime);
			
			transform.LookAt (helicopter);
			Vector3 rotation = transform.rotation.eulerAngles;
			rotation.x -= lookUp;
			transform.rotation = Quaternion.Euler (rotation);
		}
	}
}
