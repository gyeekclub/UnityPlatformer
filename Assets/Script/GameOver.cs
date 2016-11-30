using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameOver : MonoBehaviour {

	private GameObject panel;

	// Use this for initialization
	void Start () {
		panel = transform.FindChild ("GameOverPanel").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void turnOn(){
		panel.SetActive (true);
		Time.timeScale = 0f;
	}

	public static void gameOver(){
		GameObject.Find ("GameOver").GetComponent<GameOver> ().turnOn ();
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
