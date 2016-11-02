using UnityEngine;

public class BackgroudPooling : MonoBehaviour {

    public float offSetX = 2;

    private bool hasABackground = false;

    private float spriteWidth = 0f;

    Camera cam;
    private Transform myTransform;

	// Use this for initialization
	void Start () {

        // Reference to the main camera
        cam = Camera.main;
        myTransform = transform;

        // Reference to the background renderer
        SpriteRenderer sRender = GetComponent<SpriteRenderer>();

        // Get the background's length along the X axis
        spriteWidth = sRender.sprite.bounds.size.x;

	}
	
	// Update is called once per frame
	void Update () {

        // If there is no background on the right
        if (hasABackground == false) {

            // The right side of the camera
            float camHorizontal = cam.orthographicSize * Screen.width / Screen.height;

            // The right edge of the background
            float backgroundPoint = (myTransform.position.x + spriteWidth / 2) - camHorizontal;

            // If the position of the camera is greater than (our background's edge minus the offset (<- this is an optional value)) 
            // and there is no new background on the right
            if (cam.transform.position.x > backgroundPoint - offSetX && hasABackground == false) {

                // Make new background
                MakeBackground();
                hasABackground = true;

            }

        }
	
	}


    private void MakeBackground() {

        // Create a new position that has a new X coordinate which is (our background's coordinte plus twice its length)
        Vector3 newPosition = new Vector3(myTransform.position.x + (spriteWidth * 2), myTransform.position.y, myTransform.position.z);

        // Make the new background with the new position
        Transform newBackground = Instantiate(myTransform, newPosition, myTransform.rotation)as Transform;
        newBackground.parent = myTransform.parent;

    }

}
