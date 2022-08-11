using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxSky : Parallax
{
    [SerializeField] private Texture2D[] _skyTextures;

    [SerializeField] private BackGroundChangeTrigger _backGroundTrigger;

    private int _textureIndex;

    private void OnEnable()
    {
       _backGroundTrigger.ChangeLocation += OnLocationChange;
    }

    private void OnDisable()
    {
        _backGroundTrigger.ChangeLocation -= OnLocationChange;
    }

    private void OnLocationChange()
    {
        if (_textureIndex < _skyTextures.Length - 1)
        {
            _textureIndex += 1;
            Debug.Log(_textureIndex + "index++");
        }
        else
        {
            _textureIndex = 0;
            Debug.Log(_textureIndex + "index = 0");
        }

        _image.texture = _skyTextures[_textureIndex];
    }
}
