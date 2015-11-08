using UnityEngine;
using System.Collections;

public class MenuButonGenel : MonoBehaviour {
	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseEnter() {
		gameObject.GetComponent<GUITexture>().color = Color.red;
		audio.Play ();
	}
	
	void OnMouseExit() {
		gameObject.GetComponent<GUITexture>().color = Color.gray;
	}
}
