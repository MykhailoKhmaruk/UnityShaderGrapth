using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseFollower : MonoBehaviour
{
    [SerializeField, Range(0,10)] 
    private float _cameraDistance = 1;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector3 pointerPosition = Input.mousePosition;

        pointerPosition.z = _cameraDistance;

        transform.position = _mainCamera.ScreenToWorldPoint(pointerPosition);
    }
}
