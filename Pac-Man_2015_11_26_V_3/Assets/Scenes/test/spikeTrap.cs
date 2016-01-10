using UnityEngine;
using System.Collections;

public class spikeTrap : MonoBehaviour {

	//bool trapActivated;

	private float startTime;
	private float currentTime;
	private float activatedTrap;
	private float inactiveTrap;

	public Animator trapanimation;

	// Use this for initialization
	void Start () {

		trapanimation = GetComponent<Animator> ();
		trapanimation.enabled = false;
		
		InvokeRepeating ("StartTimerForSpikeTrapRepeat", 2f, 4f);
		//StartCoroutine (TimerForSpikeTrap ());
	}

	void StartTimerForSpikeTrapRepeat(){

		trapanimation.enabled = true;
		StartCoroutine (TimerForSpikeTrap ());
		Debug.Log("Dead");
		//trapanimation.enabled = false;
	}

	IEnumerator TimerForSpikeTrap(){

		//Debug.Log ("true");
		//trapActivated = true;
		//trapanimation.Play ("trap");
		//trapanimation.enabled = true; 

		yield return new WaitForSeconds (2);

		Debug.Log ("false");
		trapanimation.enabled = false;
		//trapActivated = false;
	}
}
