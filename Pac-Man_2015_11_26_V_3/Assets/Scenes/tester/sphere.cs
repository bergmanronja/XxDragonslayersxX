using UnityEngine;
using System.Collections;

public class sphere : MonoBehaviour {

	public KeyCode moveForward;
	public KeyCode moveLeft;
	public KeyCode moveRight;
	public KeyCode moveBack;
	private int score;
	private int life;

	public GameObject Wall;

	//public wallblah otherScript;

	float moveSpeed = 0.1f;
	float turnSpeed = 1f;
	float slowSpeed = 0.005f;

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (moveForward)) {
			transform.Translate(new Vector3(0f, 0f, 1f) * moveSpeed);
		}
		
		if (Input.GetKey (moveLeft)) {
			transform.Rotate(new Vector3(0f, -1f, 0f) * turnSpeed);
		}
		
		if (Input.GetKey (moveRight)) {
			transform.Rotate (new Vector3 (0f, 1f, 0f) * turnSpeed);
		}
		
		if (Input.GetKey (moveBack)) {
			transform.Translate(new Vector3(0f, 0f, -1f) * moveSpeed);
		}
	}

	void OnTriggerEnter (Collider col){ // när spelaren rör dem

		if (col.tag == "Slow") {

			moveSpeed = slowSpeed;
		}

		if (col.tag == "SpecialPoint") {

			Wall.SetActive(false); // sätter väggen till inaktiv = syns inte
		}
	}

	void OnTriggerExit (Collider col){ // när spelaren slutar röra dem
	
		if (col.tag == "Slow") {
		
			moveSpeed = 0.1f;
		}
	}
}
