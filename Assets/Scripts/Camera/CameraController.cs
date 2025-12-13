using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _inputMouseY;

    // Update is called once per frame
    void Update()
    {
        _inputMouseY = Input.GetAxis("Mouse Y");
        if (Mathf.Abs(_inputMouseY) > 0.1f)
        {
            transform.Rotate(Vector3.right, -_inputMouseY);
        }
    }
}
