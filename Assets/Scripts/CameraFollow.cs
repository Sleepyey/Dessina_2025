using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public float rotationSpeed = 15f;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        //float moveX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        //float moveY = -Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        //float yRotate = transform.eulerAngles.y + moveY;
        //float xRotate = transform.eulerAngles.x + moveX;

        ////yRotate = Mathf.Clamp(yRotate, -80, 80);

        //transform.rotation = Quaternion.Euler(yRotate, xRotate, 0);
    }
}
