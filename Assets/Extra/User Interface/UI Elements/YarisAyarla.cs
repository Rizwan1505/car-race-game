using UnityEngine;
using System.Collections;

public class YarisAyarla : MonoBehaviour {

	public AudioClip clicksound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		GameObject.Find ("Main Camera - Main Menu").GetComponent<GUILayer>().enabled = false;
		audio.clip = clicksound;
		audio.Play ();
		StartCoroutine (LoadLevel ());
		Screen.showCursor = false;
		GameObject.Find ("Main Camera - Main Menu").transform.Rotate (0, 90, 0);
		GameObject.Find ("Main Camera - Main Menu").transform.position = new Vector3(90, 0, 0);
	}

	IEnumerator LoadLevel() {
		AsyncOperation async = Application.LoadLevelAsync(2);
		yield return async;
		Debug.Log("Loading complete");
	}

}
