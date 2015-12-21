using UnityEngine;
using System.Collections;

public class Pac : MonoBehaviour {

    float speed = 20f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        Move();
	
	}

    void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.RotateAround(GetComponent<Rigidbody>().position, Vector3.down, 90);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.RotateAround(GetComponent<Rigidbody>().position, Vector3.up, 90);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.RotateAround(GetComponent<Rigidbody>().position, Vector3.up, 180);
        }
    }
}
