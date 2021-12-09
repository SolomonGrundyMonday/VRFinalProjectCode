using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    // Private variables for movement speed, camera rig.

    private const float moveSpeed = 0.1f;
    private GameObject rig;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        // Find Camera rig on startup - optimization GameObject.Find is presumably computationally expensive.
        rig = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Save y-coordinate of Player's translation. 
        float y = rig.transform.position.y;

        // If user presses 'W' key, move forward.
        if (Input.GetKey(KeyCode.W))
        {
            // Translate Camera rig forward by a factor of moveSpeed.
            rig.transform.Translate(Vector3.forward * moveSpeed);
        }
        // If user presses 'S' key, move backward.
        else if (Input.GetKey(KeyCode.S))
        {
            // Translate Camera rig backward by a factor of moveSpeed.
            rig.transform.Translate(Vector3.back * moveSpeed);
        }
        // If user presses 'A' key, strafe right.
        else if (Input.GetKey(KeyCode.A))
        {
            // Translate Camera rig left by a factor of moveSpeed.
            rig.transform.Translate(Vector3.left * moveSpeed);
        }
        // If user presses 'D' key, strafe left.
        else if (Input.GetKey(KeyCode.D))
        {
            // Translate Camera rig right by a factor of moveSpeed.
            rig.transform.Translate(Vector3.right * moveSpeed);
        }

        // Make sure the y-value of the Player's translation does not change regardless of rotation.
        float x = rig.transform.position.x;
        float z = rig.transform.position.z;
        Vector3 pos = new Vector3(x, y, z);

        rig.transform.SetPositionAndRotation(pos, rig.transform.rotation);        
    }
}
