using UnityEngine;
using System.Collections;

// The script governs music being played in the background
// The game music is played throughout the game regardless level

public class MusicPlayer : MonoBehaviour {

	// static class variable
	// determine if music is currently playing
	static MusicPlayer instance = null;

	void Awake () {
		Debug.Log ("Music player Awakes " + GetInstanceID());
		// the instance check logic is in Awake method
		// it prevents brief double music glitch at Start scene
		if (instance != null) {
			// another music instance is already playing
			// destruct the newly created instance, current gameObject
			Destroy (gameObject);
			Debug.Log ("Duplicate music player self-destructs " + GetInstanceID());
		}
		else {
			// no other music player instance
			// claim this instance
			instance = this;
			// enable the music to play throughout the game
			// gameObject is the Music Player object
			GameObject.DontDestroyOnLoad(gameObject);
		}
	}
		
	// Use this for initialisation
	void Start () {
		Debug.Log ("Music player Starts " + GetInstanceID());
	}
	
	// Update is called once per frame
	void Update () {
	}
}
