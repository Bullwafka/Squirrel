using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LevelGeneratingSystem : MonoBehaviour
{
    [SerializeField] private List<LevelObject> _itemsList;
    private Dictionary<string, List<GameObject>> _objectPool;
    public List<InteractableItem> _interactableItemsList;

    private void OnEnable()
    {
        InitializePool();
    }
    private void Start()
    {
        foreach (LevelObject item in _itemsList)
        {
            item.Object.ResetGeneratorValues();
        }
    }

    public void InitializePool()
    {
        Dictionary<string, List<GameObject>> gameObjectsPool = new Dictionary<string, List<GameObject>>();

        foreach (LevelObject item in _itemsList)
        {
            LevelGeneratingObject Object = item.Object;
            GameObject prefab = item.gameObject;
            List<GameObject> pool = new List<GameObject>();

            for (int i = 0; i < Object.PoolSize; i++)
            {
                GameObject spawned = Instantiate(prefab);
                spawned.SetActive(false);

                pool.Add(spawned);
            }

            gameObjectsPool.Add(prefab.name, pool);
        }

        _objectPool = gameObjectsPool;
    }
    public void SetObjectToLevel(LevelObject levelObject)
    {
        if (TrySetObjectToLevel(levelObject) == false)
        {
            CreateNewObject(levelObject.gameObject);
        }
    }

    public bool TrySetBranchToLevel(LevelObject branch)
    {
        if (TryGetObject(branch, out GameObject gameObject))
        {
            branch.Object.SetSpawnDistance();

            float positionX = Random.Range(branch.Object.MinPositionX, branch.Object.MaxPositionX);
            float positionY = Random.Range(branch.Object.MinGenerateDistance, branch.Object.MaxGenerateDistance);

            PlatformEffector2D platformRotation = gameObject.GetComponent<PlatformEffector2D>();

            if (positionX > 0)
            {
                positionX = 2.6f;
                gameObject.transform.rotation = new Quaternion(0, 0, 180, 0);
                platformRotation.rotationalOffset = 180;
            }
            else
            {
                positionX = -2.6f;
                gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
                platformRotation.rotationalOffset = 0;
            }

            gameObject.transform.position = new Vector2(positionX, positionY + branch.Object.CurrentPositionY);
            gameObject.SetActive(true);

            branch.Object.CurrentPositionY += positionY;
            return true;
        }
        return false;
    }
    public bool TrySetObjectToLevel(LevelObject levelObject)
    {
        if (TryGetObject(levelObject, out GameObject gameObject))
        {
            levelObject.Object.SetSpawnDistance();

            float positionX = Random.Range(levelObject.Object.MinPositionX, levelObject.Object.MaxPositionX);
            float positionY = Random.Range(levelObject.Object.MinGenerateDistance, levelObject.Object.MaxGenerateDistance);

            gameObject.transform.position = new Vector2(positionX, positionY + levelObject.Object.CurrentPositionY);
            gameObject.SetActive(true);

            levelObject.Object.CurrentPositionY += positionY;
            return true;
        }
        return false;
    }

    private bool TryGetObject(LevelObject levelObject, out GameObject gameObject)
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


    private GameObject CreateNewObject(GameObject prefab)
    {
        GameObject newGameObject = Instantiate(prefab);
        newGameObject.name = prefab.name;
        return newGameObject;
    }
}
