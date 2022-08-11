using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private float _smoothSpeed;
    
    private Vector3 _offset;
    private Vector3 _desiredPosition;
    private Vector3 _smoothPosition;

    private void Start()
    {
        _offset = transform.position + new Vector3(0, 3, 0);
    }
    private void LateUpdate()
    {
        _desiredPosition = new Vector3(_offset.x, _target.transform.position.y + _offset.y, _offset.z);
        _smoothPosition = Vector3.Lerp(transform.position, _desiredPosition, _smoothSpeed);
        transform.position = _smoothPosition;
    }
}
