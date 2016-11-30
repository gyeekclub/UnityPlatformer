using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	[SerializeField]
	private float speed;
	private bool edge;
	[SerializeField]
	private LayerMask groundLayer;
	private bool moveRight;

	private Transform leftSensor;
	private Transform rightSensor;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		edge = false;
		moveRight = true;

		leftSensor = transform.FindChild ("leftSensor");
		rightSensor = transform.FindChild ("rightSensor");

		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		EdgeCheck ();

		if(edge){
			speed *= -1;
			moveRight = !moveRight;
		}

		rb.velocity = new Vector2 (speed,rb.velocity.y);
	}

	private void EdgeCheck(){
		if (moveRight) {
			edge = !Physics2D.Raycast (rightSensor.position, Vector2.down, 0.1f, groundLayer);
		} else {
			edge = !Physics2D.Raycast (leftSensor.position, Vector2.down, 0.1f, groundLayer);
		}
	}

	// Sent when an incoming collider makes contact with this object's collider.
	private void OnCollisionEnter2D(Collision2D other){
		if (other.transform.tag == "Player") {
			GameOver.gameOver ();
		}
	}
}
