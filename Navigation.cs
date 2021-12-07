using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation : MonoBehaviour
{
    // Private variables for movement speed, camera rig.
    private const float mouseSensitivityX = 15.0f;
    private const float mouseSensitivityY = 15.0f;
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

        // Mouse movement loosely based on code at: https://answers.unity.com/questions/29741/mouse-look-script.html
        // Get mouse movement along x, y axes.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY;

        // If mouse movement along both x, y axes.
        if (mouseX != 0 && mouseY != 0)
        {
            // Limit x-axis angle to +/- 360 degrees and y-axis angle to +/- 60 degrees.
            mouseX %= 360;
            mouseY %= 60;

            // Compute x-axis quaternion based on up vector and y-axis quaternion based on left vector.
            Quaternion xQuaternion = Quaternion.AngleAxis(mouseX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(mouseY, Vector3.left);

            // Set new rotation by multiplying original rotation quaternion by xQuaternion then yQuaternion.
            rig.transform.SetPositionAndRotation(rig.transform.position, rig.transform.rotation * xQuaternion * yQuaternion);
        }
        // If mouse movement along x-axis only.
        else if (mouseX != 0 && mouseY == 0)
        {
            // Limit x-axis angle to +/- 360 degrees.
            mouseX %= 360;

            // Compute x-axis quaternion based on up vector.
            Quaternion xQuaternion = Quaternion.AngleAxis(mouseX, Vector3.up);

            // Set new rotation by multiplying original rotation quaternion by xQuaternion.
            rig.transform.SetPositionAndRotation(rig.transform.position, rig.transform.rotation * xQuaternion);
        }
        // If mouse movement along y-axis only.
        else if (mouseX == 0 && mouseY != 0)
        {
            // Limit y-axis angle to +/- 60 degrees.
            mouseY %= 60;

            // Compute yQuaternion based on left vector.
            Quaternion yQuaternion = Quaternion.AngleAxis(mouseY, Vector3.left);

            // Set new rotation by multiplying original rotation quaternion by yQuaternion.
            rig.transform.SetPositionAndRotation(rig.transform.position, rig.transform.rotation * yQuaternion);
        }
    }
}
