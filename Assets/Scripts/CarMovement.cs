using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {

	public float speed = 5f;
	public float turnAngle = 30f;
	public WheelCollider wheelFL;
	public WheelCollider wheelFR;
	public WheelCollider wheelBL;
	public WheelCollider wheelBR;
	public bool enabled = true;

	Rigidbody body;

	// Use this for initialization
	void Start () {
		body = GetComponent <Rigidbody> ();
		body.centerOfMass = new Vector3 (0, -0.25f, 0);
	}

	// Update is called once per frame
	void FixedUpdate () {
		float h = 0f;
		float v = 0f;
		if (enabled) {
			h = Input.GetAxis ("Horizontal");
			v = Input.GetAxis ("Vertical");
		}

		wheelBL.motorTorque = v * speed * Time.deltaTime;
		wheelBR.motorTorque = v * speed * Time.deltaTime;

		wheelFL.steerAngle = h * turnAngle;
		wheelFR.steerAngle = h * turnAngle;
	}

	void disable(){
		Debug.Log ("Car disabled");
	}
}
