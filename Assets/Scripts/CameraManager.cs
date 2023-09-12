using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraManager : MonoBehaviour
{
    Transform target;
    Vector3 offset;
    float smoothSpeed = 0.04f;
    private void Start()
    {
        target = GameObject.Find("Ball").transform;
        offset = transform.position-target.position;

    }
    private void LateUpdate()
    {
        Vector3 newPos = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        transform.position = newPos;
    }
}