using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private float cameraSpeed = 1;

    void Update()
    {
        transform.position += new Vector3(cameraSpeed, 0, 0);
    }
}
