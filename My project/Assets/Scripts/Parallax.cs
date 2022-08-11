using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] protected GameObject _mainCamera;
    [SerializeField] protected float _speed;
    
    protected RawImage _image;
    protected float _UVpositionY;

    private void Start()
    {
        _image = GetComponent<RawImage>();
    }

    protected void Update()
    {
        _UVpositionY = _mainCamera.transform.position.y * _speed;
        _image.uvRect = new Rect(0, _UVpositionY, _image.uvRect.width, _image.uvRect.height);
    }

   
}
    
