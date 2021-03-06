﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour {

    public float dampTime = 0.15f;
    public float camOffset = 0.05f;
    private Vector3 velocity = Vector3.zero;
    public Transform target;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            
            Vector3 point = cam.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta;
            
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
            transform.position = new Vector3(transform.position.x, transform.position.y + camOffset, transform.position.z);
        }

    }
}
