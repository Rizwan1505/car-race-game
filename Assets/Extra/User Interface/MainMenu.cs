using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find ("Directional light - Main Menu").light.intensity < 0.5f) {
			GameObject.Find ("Directional light - Main Menu").light.intensity = GameObject.Find ("Directional light - Main Menu").light.intensity + 0.001f;
		}
	}

	public bool GUIEnabled = true;
	void OnGUI () {
		if (GUIEnabled) {
				// Make a background box
				GUI.Box (new Rect (10, 10, 200, 300), "Tournament: Formula 1");
		
				// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
				if (GUI.Button (new Rect (40, 40, 140, 40), "Find Match")) {
						StartCoroutine (LoadLevel1 ());
						GameObject.Find ("Main Camera - Main Menu").transform.Rotate (0, 90, 0);
						GUIEnabled = false;
				}
		
				// Make the second button.
				if (GUI.Button (new Rect (40, 90, 140, 40), "Practice")) {
						StartCoroutine (LoadLevel2 ());
						GameObject.Find ("Main Camera - Main Menu").transform.Rotate (0, 90, 0);
						GUIEnabled = false;
				}
		}
	}

	void Awake () {
		GameObject.Find ("Directional light - Main Menu").light.intensity = 0;
	}

	IEnumerator LoadLevel1() {
		AsyncOperation async = Application.LoadLevelAsync(1);
		yield return async;
		Debug.Log("Loading complete");
	}

	IEnumerator LoadLevel2() {
		AsyncOperation async = Application.LoadLevelAsync(2);
		yield return async;
		Debug.Log("Loading complete");
	}



}
