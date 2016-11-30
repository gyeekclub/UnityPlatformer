using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Menu : MonoBehaviour {

	
	private GameObject panel;
	private bool active;

	// Use this for initialization
	void Start () {
		Time.timeScale = 1f;
		active = false;
		panel = transform.FindChild ("MenuPanel").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			if (!active)
				turnOn ();
			else
				turnOff ();
		}
	}

	
	private void turnOn(){
		panel.SetActive (true);
		active = true;
		Time.timeScale = 0f;
	}

	private void turnOff(){
		panel.SetActive (false);
		active = false;
		Time.timeScale = 1f;
	}

	public void Resume(){
		turnOff ();
	}

	public void Restart(){
		// Loads the scene by its name or index in Build Settings. 
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);
	}

	public void Quit(){
		// Quits the player application.
		Application.Quit ();
	}
}
