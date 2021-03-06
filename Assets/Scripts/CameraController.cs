﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing;        // The speed with which the camera will be following.
    public bool end;

    Vector3 offset;

    private void Awake()
    {
        if (target == null)
        {
            print("Target of cam is null.");
            target = GameObject.FindGameObjectWithTag("player").transform;
        }

        end = false;
    }

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        if (!end)
        {
            Vector3 targetCamPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
        }
    }
}
