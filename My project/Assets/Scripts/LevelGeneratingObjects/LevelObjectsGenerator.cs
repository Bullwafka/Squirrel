using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.Linq;

public class LevelObjectsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] _branches;
    [SerializeField] private GameObject _playerObj;
    [SerializeField] private GameObject _acron;
    [SerializeField] private GameObject _coin;
    [SerializeField] private GameObject _jumpBoost;
    [SerializeField] private GameObject _objectPoolSpawnPoint;
    [SerializeField] private float _minBranchDistance;
    [SerializeField] private float _maxBranchDistance;
    [SerializeField] private float _minCoinDistance;
    [SerializeField] private float _maxCoinDistance;
    [SerializeField] private float _maxAcronDistance;
    [SerializeField] private float _minAcronDistance;
    [SerializeField] private float _minJumpBoostDistance;
    [SerializeField] private float _maxJumpBoostDistance;
    [SerializeField] private float _leftBranchPosition;
    [SerializeField] private float _rightBranchPosition;
    [SerializeField] private float _lvlGenerateDistance;
    [SerializeField] private int _poolSize;

    private Vector3 _playerPosition;
    private Vector3 _branchPosition;
    private Vector3 _coinPosition;
    private Vector3 _acronPosition;
    private Vector3 _jumpBoostPosition;

    private List<GameObject> _branchesPool = new List<GameObject>();

    public UnityEvent SpawnObjects;

    private void Initialize()
    {
        for (int i = 0; i < _branches.Length; i++)
        {
            for (int j = 0; j < _poolSize; j++)
            {
                GameObject spawned = Instantiate(_branches[i], _objectPoolSpawnPoint.transform);
                spawned.SetActive(false);

                _branchesPool.Add(spawned);
            }
        }
        System.Random random = new System.Random();
        _branchesPool = _branchesPool.OrderBy(x => random.Next()).ToList();
    }

    private void Start()
    {
        //Initialize();
        _playerPosition.y = 3;
        _branchPosition = new Vector3(-1.5f, 1f, 0f);
        _acronPosition = new Vector3(0, 0, 0);
        _jumpBoostPosition = new Vector3(0, 0, 0);
        _playerPosition = _playerObj.transform.position;
    }

    private void Update()
    {
        if (_playerObj.transform.position.y >= _playerPosition.y)
        {
            _playerPosition.y += _lvlGenerateDistance;
            //CreateCoins();
            //SetRandomBranch();
            //CreateAcron();
            //CreateJumpBoost();
            //SpawnObjects?.Invoke();
        }
    }
    private void SetRandomBranch()
    {
        int random = Random.Range(0, _branches.Length - 1);
        string name = _branches[random].name;

        GameObject branch = _branchesPool.First(p => p.activeSelf == false && p.name == name + "(Clone)");
        branch.SetActive(true);

        _branchPosition.y += Random.Range(_minBranchDistance, _maxBranchDistance);

        if (branch.tag == "RightBranch")
        {
            _branchPosition.x = _rightBranchPosition;
        }

        else
        {
            _branchPosition.x = _leftBranchPosition;
        }

        branch.transform.position = _branchPosition;

    }
    //private void CreateCoins()
    //{
    //    _coinPosition.x = Random.Range(-2.2f, 2.2f);
    //    _coinPosition.y += Random.Range(_minCoinDistance, _maxCoinDistance);
    //    Instantiate(_coin, _coinPosition, Quaternion.identity);
    //}

    //private void CreateAcron()
    //{
    //    _acronPosition.x = Random.Range(-2.2f, 2.2f);
    //    _acronPosition.y += Random.Range(_minAcronDistance, _maxAcronDistance);
    //    Instantiate(_acron, _acronPosition, Quaternion.identity);
    //}

    //private void CreateJumpBoost()
    //{
    //    _jumpBoostPosition.x = Random.Range(-2.2f, 2.2f);
    //    _jumpBoostPosition.y += Random.Range(_minJumpBoostDistance, _maxJumpBoostDistance);
    //    Instantiate(_jumpBoost, _jumpBoostPosition, Quaternion.identity);
    //}
}
