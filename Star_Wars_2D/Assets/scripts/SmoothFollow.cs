﻿// Smooth Follow from Standard Assets
// Converted to C# because I fucking hate UnityScript and it's inexistant C# interoperability
// If you have C# code and you want to edit SmoothFollow's vars ingame, use this instead.
using UnityEngine;
using System.Collections;

public class SmoothFollow : MonoBehaviour
{
    public GameObject target_o;
    // The target we are following
    public Transform target;
    // The distance in the x-z plane to the target
    public float distance = 50.0f;
    // the height we want the camera to be above the target
    public float height = 5.0f;
    // How much we 
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;
    public Camera camera;

    // Place the script in the Camera-Control group in the component menu
    [AddComponentMenu("Camera-Control/Smooth Follow")]

    void Start()
    {
        target_o = GameObject.Find("Main");
        camera = GetComponent<Camera>();
        camera.orthographicSize = 8;
    }

    void Update()
    {
        // Early out if we don't have a target
        if (!target) return;

        // Calculate the current rotation angles
        float wantedRotationAngle = target.eulerAngles.y;
        float wantedHeight = target.position.y + height - 3.0f;

        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        // Damp the rotation around the y-axis
        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

        // Damp the height
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime * 5.0f);

        // Convert the angle into a rotation
        var currentRotation = Quaternion.Euler(0, 0, 0);

        // Set the position of the camera on the x-z plane to:
        // distance meters behind the target
        transform.position = target.position;
        transform.position -= currentRotation * Vector3.forward * distance;

        // Set the height of the camera
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        // Always look at the target
        //transform.LookAt(target);
    }
}   