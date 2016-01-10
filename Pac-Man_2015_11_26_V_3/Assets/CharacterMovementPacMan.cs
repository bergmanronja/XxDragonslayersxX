using UnityEngine;
using System.Collections;

public class CharacterMovementPacMan : MonoBehaviour {
	private CharacterController CharCont;
	private float verticalRot;
	public Vector3 speed;
	public int maxSpeed;
	public float MouseSensitivity;
	public float CameraViewAngle = 60f;
	
	// Use this for initialization
	void Start () {
		CharCont = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update() {
		//Rotates with mouse
		transform.Rotate(new Vector3(0,Input.GetAxis("Mouse X") * MouseSensitivity,0));
		
		//Credits Quill18Creates, modified by Thomas SP15
		//Holds the vertical rotation between the CameraViewAngle variable
		verticalRot = Mathf.Clamp(verticalRot - Input.GetAxis("Mouse Y") * MouseSensitivity, -CameraViewAngle, CameraViewAngle);
		Camera.main.transform.localRotation = Quaternion.Euler(verticalRot,0,0);
		//Credits Quill18Creates, modified by Thomas SP15
		
		//Walk with keyboard
		speed = new Vector3(Input.GetAxis("Horizontal") * maxSpeed,0, Input.GetAxis("Vertical") * maxSpeed);
		speed = transform.rotation * speed;
		CharCont.SimpleMove (speed);
	}
}
