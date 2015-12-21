using UnityEngine;
using System.Collections;

public class spikeTrap : MonoBehaviour {

	private bool trapActivated = false;

	private float startTime;
	private float currentTime;
	private float activatedTrap;
	private float inactiveTrap;

	//public Animation trapAnimation;
	//public Animator trapAnimation;

	// Use this for initialization
	void Start () {

		//trapAnimation = GetComponent<Animation> ();
		//trapAnimation = GetComponent<Animator> ();
		
		InvokeRepeating ("StartTimerForSpikeTrapRepeat", 5f, 6f);
	}

	void Update(){

		if (trapActivated == true) {
			Debug.Log ("dead");
		}
	}

	void StartTimerForSpikeTrapRepeat(){

		StartCoroutine (TimerForSpikeTrap ());
	}

	IEnumerator TimerForSpikeTrap(){

		Debug.Log ("hej");
		trapActivated = true;
		//Animator.Play();

		yield return new WaitForSeconds (1);

		Debug.Log ("false");
		trapActivated = false;
	}
}
