using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Paddle : MonoBehaviour
{
    private Camera mainCamera;

    private float _pad;

    void Start()
    {
        mainCamera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        Movement();
    }

    void Movement()
    {
        _pad = mainCamera.pixelWidth / 9 ;

        float maxMovement = Mathf.Clamp(Input.mousePosition.x, _pad, (mainCamera.pixelWidth - _pad));
        float worldPos = mainCamera.ScreenToWorldPoint(new Vector3(maxMovement, 0, 0)).x;
        this.transform.position = new Vector3(worldPos, -4, 0);
    }
}
