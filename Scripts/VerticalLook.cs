using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalLook : MonoBehaviour
{

    [SerializeField] private GameObject _vertical;
    [SerializeField] private byte _sensitivity;
    [SerializeField] private float _speed;
    [SerializeField] private byte _minLimit;
    [SerializeField] private byte _maxLimit;
    private float _currentAngle;
    
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _currentAngle = 0;
    }


    void Update()
    {
        float y = Input.GetAxis("Mouse Y") * _sensitivity * _speed * Time.deltaTime;
        float x = Input.GetAxis("Mouse X") * _sensitivity * _speed * Time.deltaTime;
        _currentAngle += y;
        _currentAngle = Mathf.Clamp(_currentAngle, -_minLimit, _maxLimit);
        _vertical.transform.localRotation = Quaternion.Euler(-_currentAngle, 0,0);
        transform.Rotate(transform.up * x);
    }
}
