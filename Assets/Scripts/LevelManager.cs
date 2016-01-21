using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

// This script a the game's level manager
// It manages the flow of different game scenes

public class LevelManager : MonoBehaviour {

	public void LoadLevel(string name) {
		Debug.Log("Level load requested for: "+name);
        SceneManager.LoadScene(name);
	}

	public void QuitRequest() {
		Debug.Log ("Quit requested to leave game");
		// no effect for debug and web build
		Application.Quit ();
	}
	
	public void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}
