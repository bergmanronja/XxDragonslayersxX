using UnityEngine;
using System.Collections;

public class SecretDoor : MonoBehaviour {

	GameObject secretDoor;

	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Pacman") 
		{
			GameObject.FindGameObjectWithTag ("secretDoor");
			secretDoor.SetActive(false);
		}
	}
}