using UnityEngine;

public class Movement : MonoBehaviour {

    private Rigidbody2D myRigidBody;

    [SerializeField]
    private float movSpeed;

    [SerializeField]
    private float jumpHeight;

    private bool facingRight;

    // Use this for initialization
    void Start() {

        // Initially our character is facing right
        facingRight = true;

        // Our character's RigidBody
        myRigidBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update() {

        // Built-in movement type, e.g. you will get the same output by pressing 
        // the right arrow on a keyboard or right controller stick on an Xbox controller
        float horizontal = Input.GetAxis("Horizontal");

        HandleMovement(horizontal);
        Facing(horizontal);
        Jump();

    }

    private void HandleMovement(float horizontal)
    {
        // Our character's movement of movSpeed speed
        myRigidBody.velocity = new Vector2(horizontal * movSpeed, myRigidBody.velocity.y);

    }

    // Handling the facing of our character
    private void Facing(float horizontal) {

        // If we press left and our character is facing right and vica versa
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) {

            facingRight = !facingRight;

            // Flip our character vertically
            Vector3 scale = transform.localScale;
            scale.x *= -1;

            transform.localScale = scale;

        }
    }
        private void Jump() {

        // If we press the Space button
        if (Input.GetKeyDown(KeyCode.Space)) {

            // Our character will jump by jumpHeight height
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpHeight);

        }

    }

    }

