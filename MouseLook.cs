using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    // Public properties for MouseLook script.
    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    // Private properties for MouseLook script.
    private const float xSensitivity = 15.0f;
    private const float ySensitivity = 15.0f;
    private float rotX = 0f;
    private float rotY = 0f;
    private GameObject rig;
    Quaternion originalRotation;

	void Start()
	{
        // Get the Capsule's rigid body component (if it exists).
        rig = GameObject.Find("Capsule");
        Rigidbody body = rig.GetComponent<Rigidbody>();
        if (body)
            body.freezeRotation = true;

        // Get the starting rotation Quaternion.
        originalRotation = transform.localRotation;
	}

    // MouseLook implementation borrowed from https://answers.unity.com/questions/29741/mouse-look-script.html.
    void Update()
    {
        // If the Mouse look script is using both x, y axes.
        if (axes == RotationAxes.MouseXAndY)
        {
            // Add the delta x, y mouse input and add it to the x, y rotation components.
            rotX += Input.GetAxis("Mouse X") * xSensitivity;
            rotY += Input.GetAxis("Mouse Y") * ySensitivity;

            // Keep x rotation within [-360,360] and y-rotation within [-60,60].
            if (rotX >= 360f)
                rotX -= 360f;
            else if (rotX <= -360f)
                rotX += 360f;

            rotY = Mathf.Clamp(rotY, -60f, 60f);

            // Get quaternion for x-axis based on the up vector and y-quaternion based on the left vector.
            Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
            Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);

            // Apply x, y rotations to the original rotation.
            transform.localRotation = originalRotation * xQuaternion * yQuaternion;
        }
        // If the MouseLook script is using x-axis only.
        else if (axes == RotationAxes.MouseX)
        {
            // Add the delta x mouse input and add it to the x rotation component.
            rotX += Input.GetAxis("Mouse X") * xSensitivity;

            // Keep x rotation within [-360,360].
            if (rotX >= 360f)
                rotX -= 360f;
            else if (rotX <= -360f)
                rotX += 360f;

            // Get Quaternion for x-axis based on up vector and apply x rotation to the original rotation.
            Quaternion xQuaternion = Quaternion.AngleAxis(rotX, Vector3.up);
            transform.localRotation = originalRotation * xQuaternion;
        }
        // If the MouseLook script is using y-axis only.
        else
        {
            // Add the delta y mouse input and add it to the y rotation component.
            rotY += Input.GetAxis("Mouse Y") * ySensitivity;
            rotY = Mathf.Clamp(rotY, -60f, 60f);

            // Get Quaternion for y-axis based on left vector and apply y rotaiton to the original rotation.
            Quaternion yQuaternion = Quaternion.AngleAxis(rotY, Vector3.left);
            transform.localRotation = originalRotation * yQuaternion;
        }
    }
}
