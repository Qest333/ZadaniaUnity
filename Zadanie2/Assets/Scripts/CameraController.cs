﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float xRot = 0f;
    public Transform playerBody;
    public float mouseSensivity = 1.20f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y"); 

        playerBody.Rotate(Vector3.up * mouseX * mouseSensivity);

        //transform.Rotate(Vector3.right * mouseY);

        xRot -= mouseY * mouseSensivity;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }
}
