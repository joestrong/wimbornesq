using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject car;
	public GameObject helicopter;
	public GameObject player;
	public Camera mainCamera;

	protected string state = "car";
	protected CarMovement carScript;
	protected HelicopterScript helicopterScript;
	protected ThirdPersonUserControl playerScript;

	protected CameraCarScript cameraCarScript;
	protected CameraPlayerScript cameraPlayerScript;
	protected CameraHelicopterScript cameraHelicopterScript;

	void Start()
	{
		carScript = car.GetComponent<CarMovement>();
		helicopterScript = helicopter.GetComponent<HelicopterScript> ();
		playerScript = player.GetComponent<ThirdPersonUserControl> ();
		cameraCarScript = mainCamera.GetComponent<CameraCarScript> ();
		cameraPlayerScript = mainCamera.GetComponent<CameraPlayerScript> ();
		cameraHelicopterScript = mainCamera.GetComponent<CameraHelicopterScript> ();

		player.transform.GetChild (0).GetChild(0).renderer.enabled = false;
		player.transform.GetChild (0).GetChild(1).renderer.enabled = false;
	}

	void Update ()
	{
		if (state == "car" && Input.GetKeyUp (KeyCode.Return)) 
		{
			state = "foot";
			carScript.enabled = false;
			playerScript.enabled = true;
			player.transform.position = car.transform.position;
			player.transform.GetChild (0).GetChild(0).renderer.enabled = true;
			player.transform.GetChild (0).GetChild(0).renderer.enabled = true;
			cameraCarScript.enabled = false;
			cameraPlayerScript.enabled = true;
		}
		else if (state == "helicopter" && Input.GetKeyUp (KeyCode.Return))
		{
			state = "foot";
			helicopterScript.enabled = false;
			playerScript.enabled = true;
			player.transform.position = helicopter.transform.position;
			player.transform.GetChild (0).GetChild(0).renderer.enabled = true;
			player.transform.GetChild (0).GetChild(0).renderer.enabled = true;
			cameraHelicopterScript.enabled = false;
			cameraPlayerScript.enabled = true;
		}
		else if (state == "foot" && Input.GetKeyUp (KeyCode.Return) && Vector3.Distance(player.transform.position, car.transform.position) < 1)
		{
			state = "car";
			carScript.enabled = true;
			playerScript.enabled = false;
			player.transform.GetChild (0).GetChild(0).renderer.enabled = false;
			player.transform.GetChild (0).GetChild(0).renderer.enabled = false;
			cameraCarScript.enabled = true;
			cameraPlayerScript.enabled = false;
		}
		else if (state == "foot" && Input.GetKeyUp (KeyCode.Return) && Vector3.Distance(player.transform.position, helicopter.transform.position) < 1)
		{
			state = "helicopter";
			helicopterScript.enabled = true;
			playerScript.enabled = false;
			player.transform.GetChild (0).GetChild(0).renderer.enabled = false;
			player.transform.GetChild (0).GetChild(0).renderer.enabled = false;
			cameraHelicopterScript.enabled = true;
			cameraPlayerScript.enabled = false;
		}
	}
}
