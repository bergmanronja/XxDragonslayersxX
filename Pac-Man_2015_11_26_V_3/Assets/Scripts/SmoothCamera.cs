using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {

	public Transform cameraposition;
	float smoothTime = 2f;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 targetposition = cameraposition.TransformPoint(new Vector3());
		transform.position = Vector3.SmoothDamp (transform.position, targetposition, ref velocity, smoothTime);
	}
}
