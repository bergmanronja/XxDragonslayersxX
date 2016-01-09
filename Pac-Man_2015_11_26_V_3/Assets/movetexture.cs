using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class movetexture : MonoBehaviour {

	public MovieTexture cutscene;
	public AudioSource cutsceneaudio;

	// Use this for initialization
	void Start () {

		GetComponent<RawImage> ().texture = cutscene as MovieTexture;
		cutsceneaudio = GetComponent<AudioSource> ();

		cutscene.Play ();
		cutsceneaudio.Play ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.anyKey) {

			cutscene.Stop ();
			Application.LoadLevel (1);
		}
	}
}
