using UnityEngine;
using System.Collections;

public class CameraPlayerScript : MonoBehaviour {

	public GameObject target;
	public bool enabled = true;
	public float cameraDistance = 3f;
	public float cameraHeight = 1f;
	public float smoothness = 3f;

	protected bool is3rdPerson = true;

	void FixedUpdate()
	{
		if (Input.GetKeyUp (KeyCode.LeftControl)) {
			is3rdPerson = !is3rdPerson;
		}
		if (enabled) {
			if(is3rdPerson){
				transform.LookAt(target.transform.position);
				Vector3 newPosition = transform.position;
				if(Vector3.Distance(transform.position, target.transform.position) > cameraDistance){
					newPosition = transform.position + (transform.forward * smoothness * Time.deltaTime);
				}
				newPosition.y = target.transform.position.y + cameraHeight;
				transform.position = newPosition;
			}else{
				Vector3 newPosition = target.transform.position;
				newPosition.y = target.transform.position.y + cameraHeight;
				transform.position = newPosition;
				transform.rotation = target.transform.rotation;
			}
		}
	}

}
