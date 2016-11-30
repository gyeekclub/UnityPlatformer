using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// OnTriggerEnter is called when the Collider other enters the trigger.
	private void OnTriggerEnter2D(Collider2D other){
		// Check if the collider's tag is 'Player'
		if (other.tag == "Player") {
			// Increasing the counter by calling the AddCoin function
			CoinCounter.AddCoin ();
			// Destroying Coin
			Destroy (gameObject);
		}
	}
}
