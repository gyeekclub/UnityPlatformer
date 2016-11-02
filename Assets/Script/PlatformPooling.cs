using UnityEngine;
using System.Collections.Generic;

public class PlatformPooling : MonoBehaviour {

    public GameObject platform;

    public float distance;

    public GameObject player;

    public int platformAmount;

    List<GameObject> pooledPlatforms;


    // Use this for initialization
    void Start() {

        pooledPlatforms = new List<GameObject>();

        // Create the platforms and make them inactive until we don't use it
        //platformAmount: the number of platforms needed to fill our screen
        for (int i = 0; i < platformAmount; i++) {

            GameObject obj = Instantiate(platform);
            obj.SetActive(false);
            pooledPlatforms.Add(obj);

        }

    }

    // Update is called once per frame
    void Update() {

        GeneratePlatform();

    }

    public void GeneratePlatform() {

        for (int i = 0; i < pooledPlatforms.Count; i++) {

            // If we found an inactive element in the hierarchy
            if (!pooledPlatforms[i].activeInHierarchy) {

                // Then relocate it to another coordinates
                Vector3 newPos = new Vector3(pooledPlatforms[i].transform.position.x + 5 + distance, transform.position.y, 
                    transform.position.z);

                // Let this platform to be the newObj object
                GameObject newObj = pooledPlatforms[i];

                // Make it active and set its position
                newObj.SetActive(true);
                newObj.transform.position = newPos;

                distance += 5;
            }

        }

        // Find our first platform
        GameObject platforms = GameObject.FindGameObjectWithTag("Platform");

        // If the platform reaches a certain positon
        if (platforms.transform.position.x < player.transform.position.x - 15f) {

            // Then make it inactive
            platforms.SetActive(false);

        }

    }

}
