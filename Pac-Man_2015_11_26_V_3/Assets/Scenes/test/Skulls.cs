using UnityEngine;
using System.Collections;

public class Skulls : MonoBehaviour {

    float speed = 50.0f;

	// Use this for initialization
	void Start () {

        
	
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.up * Time.deltaTime* speed);
	}
}
