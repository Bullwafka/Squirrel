using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject _leftWall;
    [SerializeField] private GameObject _rightWall;
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private GameObject _tileMapGrid;
    [SerializeField] private float _lvlGenerateDistance;

    private Vector3 _positionR;
    private Vector3 _positionL;
    private Vector3 _playerPosition;
    private Vector3 _tileMapGridPosition;

    private void Start()
    {
        _playerPosition.y = 3;
        _positionR = new Vector3(2.88f, 0f, 0);
        _positionL = new Vector3(-2.88f, 0f, 0);
        _tileMapGridPosition = new Vector3(0f, 0f, 0f);
    }
    private void Update()
    {
        if(_playerObj.transform.position.y >= _playerPosition.y)
        {
            _playerPosition.y += _lvlGenerateDistance;
            CreateWalls();
        }
    }
    public void CreateWalls()
    {
        _positionL.y += 20f;
        _positionR.y += 20f;
        _tileMapGridPosition.y += 20f;
        
        Instantiate(_rightWall, _positionR, Quaternion.identity);
        Instantiate(_leftWall, _positionL, Quaternion.identity);
        Instantiate(_tileMapGrid, _tileMapGridPosition, Quaternion.identity);
    }

    
}
