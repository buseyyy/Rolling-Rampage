using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [Header("Camera")]
    [SerializeField] float rotationCameraSpeed;

    private void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        transform.Rotate(Vector3.up * rotationCameraSpeed * horizontal * Time.deltaTime);
    }
}
