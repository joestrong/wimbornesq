using UnityEngine;
using System.Collections;

public class PedestrianScript : MonoBehaviour {

	Rigidbody body;

	void Start() {
		body = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		Vector3 newPosition = body.position + transform.forward * 3f * Time.deltaTime;
		body.MovePosition (newPosition);
	}
}
