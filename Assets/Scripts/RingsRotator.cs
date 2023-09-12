using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.PackageManager.UI;
using UnityEditor;
using UnityEngine;

public class RingsRotator : MonoBehaviour
{
    public float rotationSpeedPC;
    public float rotationSpeedMobile;
    private void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            float mouseX = Input.GetAxis("Mouse X");
            transform.Rotate(0, -mouseX* rotationSpeedPC * Time.deltaTime,0);
        }
#elif UNITY_ANDROID
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
            float xDeltaPos = Input.GetTouch(0).deltaPosition.x;
            transform.Rotate(0, -xDeltaPos * rotationSpeedMobile* Time.deltaTime, 0);
        }
#endif
    }
}
