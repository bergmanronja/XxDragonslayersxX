using UnityEngine;
using System.Collections;

public class RotationDiamonds : MonoBehaviour {

	void Update () {
		
		transform.Rotate(Time.deltaTime, 1, 0);
	}
}
