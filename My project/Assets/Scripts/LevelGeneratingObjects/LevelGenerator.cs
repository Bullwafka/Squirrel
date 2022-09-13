using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private LevelGeneratingSystem _levelObjectGenerator;
    [SerializeField] private GameObject _playerObject;

    [SerializeField] private List<LevelObject> _branchesList;
    [SerializeField] private Branch _branch;
    public List<InteractableObject> _itemsList;
    public List<InteractableItem> _interactableItemsList;

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
        foreach (InteractableObject item in _itemsList)
        {
            if (_playerObject.transform.position.y >= item.Object.SpawnDistance)
            {
                _levelObjectGenerator.SetObjectToLevel(item);
                Debug.Log("SPAWN" + item.gameObject.name);
            }
        }
        LevelObject branch = _branchesList[Random.Range(0, _branchesList.Count - 1)];

        if (_playerObject.transform.position.y >= branch.Object.SpawnDistance)
        {
            _levelObjectGenerator.TrySetBranchToLevel(branch);
        }

    }

    private void SetRandomBranch()
    {
        int index = Random.Range(0, _branchesList.Count - 1);
        int rotation = Random.Range(0, 100);
        if (rotation > 50)
        {
            _branch.MinPositionX = 2.6f;
            _branch.MaxPositionX = 2.6f;
            _branchesList[index].gameObject.transform.localRotation = new Quaternion(0, 0, 180, 0);
        }
        else
        {
            _branch.MinPositionX = -2.6f;
            _branch.MaxPositionX = -2.6f;
            _branchesList[index].gameObject.transform.localRotation = new Quaternion(0, 0, 0, 0);
        }
        _levelObjectGenerator.SetObjectToLevel(_branchesList[index]);
    }

    //private void UpdateAllBranchesGeneratorValues(int index, Branch branch)
    //{
    //    List<Branch> list = _branchesList;
    //    list.RemoveAt(index);
    //    for (int i = 0; i < list.Count; i++)
    //    {
    //        list[i].Object.SetSpawnDistance();
    //        list[i].Object.CurrentPositionY = _branchesList[index].Object.CurrentPositionY;
    //    }
    //    list.Add(branch);
    //}
    //public void OnSpawnObject()
    //{
    //    foreach (LevelGeneratingObject item in _levelObjectGenerator._itemsList)
    //    {
    //        _levelObjectGenerator.TrySetObjectToLevel(item);
    //    }
    //}
}
