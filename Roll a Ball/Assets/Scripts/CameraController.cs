﻿using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    public GameObject player;
    private Vector3 offset;

	// Use this for initialization
	void Start () {
        // 3rd person
        offset = transform.position - player.transform.position;
	}
	
	// LateUpdate is called once per frame after all objects was render
	void LateUpdate () {
        transform.position = player.transform.position + offset;
	}
}
