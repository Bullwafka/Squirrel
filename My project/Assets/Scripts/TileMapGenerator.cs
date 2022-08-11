using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapGenerator : MonoBehaviour
{
    [SerializeField] GameObject _tileMap;
    [SerializeField] GameObject _scriptHolder;
    private Vector3 _tileGenerationPositionRight;
    private Vector3 _tileGenerationPositionLeft;
    private float _yTilePosition;
    private void Start()
    {
        _tileGenerationPositionRight = new Vector3(4f, 0f, 0f);
        _tileGenerationPositionLeft = new Vector3(-5f, 0f, 0f);
        _yTilePosition = 16f;
    }

    public void GenerateTiles()
    {
        for(float x = 0; x <= 32; x++ )
        {
            _tileGenerationPositionLeft.y += _yTilePosition + x;
            Instantiate(_tileMap, _tileGenerationPositionLeft, Quaternion.identity);
            _tileGenerationPositionRight.y += _yTilePosition + x;
            Instantiate(_tileMap, _tileGenerationPositionRight, Quaternion.identity);
        }
    }
    

}
