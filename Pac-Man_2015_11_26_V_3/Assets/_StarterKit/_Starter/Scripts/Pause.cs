using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour
{

	public GameObject CanvasObject;

	// Use this for initialization
	void Start ()
	{
	
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (Input.GetKey (KeyCode.P)) {
			if (Time.timeScale == 1f) {
				Time.timeScale = 0.0000001f;
				CanvasObject.SetActive (true);
			} 
			else 
			{
				Time.timeScale = 1f;
			}
		}
	
	}

	void OnGui ()
	{
		
	}
}
