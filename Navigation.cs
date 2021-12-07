using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    // Private variables for movement speed, camera rig.
    private const float moveSpeed = 0.1f;
    private GameObject rig;

    // Start is called before the first frame update
    void Start()
    {
        // Find Camera rig on startup - optimization GameObject.Find is presumably computationally expensive.
        rig = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        // If user presses 'W' key, move forward.
        if (Input.GetKey(KeyCode.W))
        {
            // Compute new x, z coordinates
            float x = rig.transform.position.x - ((float)Math.Sin(rig.transform.rotation.y) * moveSpeed);
            float z = rig.transform.position.z - ((float)-Math.Cos(rig.transform.rotation.y) * moveSpeed);

            // Set Camera rig new position based on computed coordinates.
            Vector3 newPos = new Vector3(x, rig.transform.position.y, z);
            rig.transform.SetPositionAndRotation(newPos, rig.transform.rotation);
        }
        // If user presses 'S' key, move backward.
        else if (Input.GetKey(KeyCode.S))
        {
            // Compute new x, z coordinates.
            float x = rig.transform.position.x + ((float)Math.Sin(rig.transform.rotation.y) * moveSpeed);
            float z = rig.transform.position.z + ((float)-Math.Cos(rig.transform.rotation.y) * moveSpeed);

            // Set Camera rig new position based on computed coordinates.
            Vector3 newPos = new Vector3(x, rig.transform.position.y, z);
            rig.transform.SetPositionAndRotation(newPos, rig.transform.rotation);
        }
        // If user presses 'D' key, strafe right.
        else if (Input.GetKey(KeyCode.D))
        {
            // Compute new x, z coordinates.
            float x = rig.transform.position.x + ((float)Math.Cos(rig.transform.rotation.y) * moveSpeed);
            float z = rig.transform.position.z + ((float)Math.Sin(rig.transform.rotation.y) * moveSpeed);

            // Set Camera rig new position based on computed coordinates.
            Vector3 newPos = new Vector3(x, rig.transform.position.y, z);
            rig.transform.SetPositionAndRotation(newPos, rig.transform.rotation);
        }
        // If user presses 'A' key, strafe left.
        else if (Input.GetKey(KeyCode.A))
        {
            // Compute new x, z coordinates.
            float x = rig.transform.position.x - ((float)Math.Cos(rig.transform.rotation.y) * moveSpeed);
            float z = rig.transform.position.z - ((float)Math.Sin(rig.transform.rotation.y) * moveSpeed);

            // Set Camera rig new position based on computed coordinates.
            Vector3 newPos = new Vector3(x, rig.transform.position.y, z);
            rig.transform.SetPositionAndRotation(newPos, rig.transform.rotation);
        }
    }
}
