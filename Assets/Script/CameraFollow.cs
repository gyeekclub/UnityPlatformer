using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;

    [SerializeField]
    private float xMin;

    [SerializeField]
    private float xMax;

    [SerializeField]
    private float yMin;

    [SerializeField]
    private float yMax;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        // Set the camera to follow our character
        // The parameters are the character's coordinates and a max and a min coordinate until the camera have to follow, 
        // e.g. if the character fall's down the camera won't follow
        // Lastly, the z coordinate remains unchanged
        transform.position = new Vector3(Mathf.Clamp(player.transform.position.x, xMin, xMax), 
            Mathf.Clamp(player.transform.position.y, yMin, yMax), transform.position.z);
	
	}
}
