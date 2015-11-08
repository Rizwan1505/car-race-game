using UnityEngine;
using System.Collections;

public class intro : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.runInBackground = true;
		Cursor.visible = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!movie.isPlaying) {
			Application.LoadLevel (1);
		}
	}
	

	
	public MovieTexture movie;
	
	void Awake () {
		movie.Play ();
	}
	


}
