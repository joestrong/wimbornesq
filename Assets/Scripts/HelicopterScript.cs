using UnityEngine;
using System.Collections;

public class HelicopterScript : MonoBehaviour {

	public bool enabled = true;

	protected float speed = 0f;
	protected float maxSpeed = 10f;

	protected Rigidbody body;

	// Use this for initialization
	void Start () {
		body = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (enabled) {
			if (Input.GetKey (KeyCode.Space)) {
					speed += 1f;
					if (speed > maxSpeed) {
							speed = maxSpeed;
					}
					
			} else {
					speed -= 1f * Time.deltaTime;
			}
			body.AddForce (new Vector3 (0f, speed, 0f));

			float h = Input.GetAxis("Horizontal");
			float v = Input.GetAxis("Vertical");

			body.AddForce(transform.forward * v);

			Quaternion rotation = transform.rotation;
			Vector3 rotationEuler = rotation.eulerAngles;
			rotationEuler.y += h;
			rotation.eulerAngles = rotationEuler;
			body.MoveRotation(rotation);
		}
	}
}
