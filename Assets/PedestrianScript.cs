using UnityEngine;
using System.Collections;

public class PedestrianScript : MonoBehaviour {

	public GameObject target;
	Rigidbody body;

	void Start() {
		body = GetComponent<Rigidbody> ();
	}

	void FixedUpdate () {
		Vector3 newPosition = body.position + transform.forward * 1f * Time.deltaTime;
		body.MovePosition (newPosition);
	}
}
