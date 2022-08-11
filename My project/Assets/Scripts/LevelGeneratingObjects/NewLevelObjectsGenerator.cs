using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NewLevelObjectsGenerator : MonoBehaviour
{
    [SerializeField] private List<LevelGeneratingObject> _itemsList;

    private Dictionary<string, List<GameObject>> _objectPool;

    private void Start()
    {
        foreach (LevelGeneratingObject item in _itemsList)
        {
            item.ResetGeneratorValues();
        }
    }

    public void InitializePool()
    {
        Dictionary<string, List<GameObject>> gameObjectsPool = new Dictionary<string, List<GameObject>>();

        foreach (LevelGeneratingObject item in _itemsList)
        {
            GameObject prefab = item.gameObject;
            List<GameObject> pool = new List<GameObject>();

            for (int i = 0; i < item.PoolSize; i++)
            {
                GameObject spawned = Instantiate(prefab);
                spawned.SetActive(false);

                pool.Add(spawned);
            }

            gameObjectsPool.Add(prefab.name, pool);
        }

        _objectPool = gameObjectsPool;
    }

    public bool TrySetObjectToLevel(LevelGeneratingObject levelObject)
    {
        if (TryGetObject(levelObject, out GameObject gameObject))
        {
            levelObject.SetSpawnDistance();
            
            
            float positionX = Random.Range(levelObject.MinPositionX, levelObject.MaxPositionX);
            float positionY = Random.Range(levelObject.MinGenerateDistance, levelObject.MaxGenerateDistance);

            float currentPositionY = levelObject.GetCurrentPosition();
            gameObject.transform.position = new Vector2(positionX, positionY + currentPositionY);
            gameObject.SetActive(true);

            levelObject.SetCurrentPositionY(positionY); 

            
            return true;
        }
        return false;
    }

    private bool TryGetObject(LevelGeneratingObject levelObject, out GameObject gameObject)
    {
        if (_objectPool.TryGetValue(levelObject.gameObject.name, out List<GameObject> objectPool) && objectPool.Count > 0)
        {
            gameObject = objectPool.FirstOrDefault(p => p.activeSelf == false);

            if (gameObject != null)
                return true;
        }
        gameObject = null;
        return false;
    }

    public void SetObjectToLevel(LevelGeneratingObject levelObject) 
    {
        if (TrySetObjectToLevel(levelObject) == false)
        {
            CreateNewObject(levelObject.gameObject);
        }
    }

    private GameObject CreateNewObject(GameObject prefab)
    {
        GameObject newGameObject = Instantiate(prefab);
        newGameObject.name = prefab.name;
        return newGameObject;
    }
}
