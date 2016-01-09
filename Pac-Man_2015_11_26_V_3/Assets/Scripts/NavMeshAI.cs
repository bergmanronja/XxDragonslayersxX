using UnityEngine;
using System.Collections;

public class NavMeshAI : MonoBehaviour {

	private NavMeshAgent ghosts;
	public Transform goal;
	public GameObject[] newGoal;

	// Use this for initialization
	void Start () {

		ghosts = GetComponent<NavMeshAgent>();
		ghosts.destination = goal.position;
		GhostWander ();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void GhostWander(){
		ghosts.destination = newGoal[2].transform.position;
	}
}
