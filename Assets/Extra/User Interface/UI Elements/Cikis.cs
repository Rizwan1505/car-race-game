using UnityEngine;
using System.Collections;

public class Cikis : MonoBehaviour {

	public AudioClip clicksound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		audio.clip = clicksound;
		audio.Play ();
		Application.Quit();
	}
}
