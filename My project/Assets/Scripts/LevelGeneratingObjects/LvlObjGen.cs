using System.Collections.Generic;
using UnityEngine;

public class LvlObjGen : MonoBehaviour
{
    [SerializeField] private NewLevelObjectsGenerator _levelObjectGenerator;
    [SerializeField] private GameObject _playerObject;

    [SerializeField] private List<Branch> _branchesList;

    public List<InteractiveItem> _itemsList;
    private void OnEnable()
    {
        _levelObjectGenerator.InitializePool();
    }
    //private void Start()
    //{
    //    foreach (LevelGeneratingObject item in _itemsList)
    //    {
    //        for (int i = 0; i < 3; i++)
    //        {
    //            _levelObjectGenerator.SetObjectToLevel(item);
    //        }
    //    }
    //}

    private void Update()
    {
        if (_playerObject.transform.position.y >= Branch.SpawnDistance)
        {
            SetRandomBranch();
        }
        foreach (LevelGeneratingObject item in _itemsList)
        {
            if (_playerObject.transform.position.y >= item.GetSpawnDistance())
            {
                _levelObjectGenerator.SetObjectToLevel(item);
                Debug.Log("SPAWN" + item.gameObject.name);

            }
        }
    }

    private void SetRandomBranch()
    {
        int index = Random.Range(0, _branchesList.Count);
        Branch branch = _branchesList[index];
        _levelObjectGenerator.SetObjectToLevel(branch);
    }

    //public void OnSpawnObject()
    //{
    //    foreach (LevelGeneratingObject item in _levelObjectGenerator._itemsList)
    //    {
    //        _levelObjectGenerator.TrySetObjectToLevel(item);
    //    }
    //}
}
