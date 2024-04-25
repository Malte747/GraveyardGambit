using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookUpdated : MonoBehaviour
{
    

    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    public Vector2 sensitivity = Vector2.one * 360f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
