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
		GetComponent<AudioSource>().clip = clicksound;
		GetComponent<AudioSource>().Play ();
		Application.Quit();
	}
}
