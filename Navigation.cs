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
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        // Find Camera rig on startup - optimization GameObject.Find is presumably computationally expensive.
        rig = GameObject.Find("Main Camera");
        Rigidbody rigidBody = rig.GetComponent<Rigidbody>();
        rigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {

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

        float x = rig.transform.position.x;
        float z = rig.transform.position.z;
        Vector3 pos = new Vector3(x, y, z);

        rig.transform.SetPositionAndRotation(pos, rig.transform.rotation);

        // Mouse movement loosely based on code at: https://answers.unity.com/questions/29741/mouse-look-script.html
        // Get mouse movement along x, y axes.
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivityX;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivityY;

        // If mouse movement along x-axis.
        if (mouseX != 0)
        {
            // Limit x-axis angle to +/- 360 degrees.
            mouseX %= 360;

            // Compute x-axis quaternion based on up vector.
            Quaternion xQuaternion = Quaternion.AngleAxis(mouseX, Vector3.up);

            // Set new rotation by multiplying original rotation quaternion by xQuaternion.
            rig.transform.localRotation = rig.transform.localRotation * xQuaternion;
        }
        // If mouse movement along y-axis.
        if (mouseY != 0)
        {
            // Limit y-axis angle to +/- 60 degrees.
            mouseY %= 60;

            // Compute yQuaternion based on left vector.
            Quaternion yQuaternion = Quaternion.AngleAxis(mouseY, Vector3.left);

            // Set new rotation by multiplying original rotation quaternion by yQuaternion.
            rig.transform.localRotation = rig.transform.localRotation * yQuaternion;
        }
    }
}
