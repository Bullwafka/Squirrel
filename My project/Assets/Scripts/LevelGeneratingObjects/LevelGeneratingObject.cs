using UnityEngine;
[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]

[System.Serializable]
public class LevelGeneratingObject : ScriptableObject
{
    [SerializeField] private int _poolSize = 30;
    public int PoolSize => _poolSize;

    [SerializeField] private float _minGenerateDistance;
    public float MinGenerateDistance => _minGenerateDistance;

    [SerializeField] private float _maxGenerateDistance;
    public float MaxGenerateDistance => _maxGenerateDistance;

    [SerializeField] protected float _minPositionX;
    public float MinPositionX => _minPositionX;

    [SerializeField] protected float _maxPositionX;
    public float MaxPositionX => _maxPositionX;

    //generator value
    [SerializeField] private float _spawnDistance;
    public float SpawnDistance => _spawnDistance;

    //generator value
    [SerializeField] private float _currentPositionY;
    public float CurrentPositionY { 
                                    get { return _currentPositionY; }
                                    set { _currentPositionY = value; }
                                  }

    public void ResetGeneratorValues()
    {
        _spawnDistance = 0;
        _currentPositionY = 0;
    }

    public void SetSpawnDistance()
    {
        _spawnDistance += _minGenerateDistance;
    }

    //public virtual float GetSpawnDistance()
    //{
    //    return 0;
    //}
    //public virtual void SetCurrentPositionY(float value)
    //{

    //}

    //public virtual float GetCurrentPosition()
    //{
    //    return 0;
    //}
    //public virtual void SetSpawnDistance()
    //{

    //}

    //public void DisableObject()
    //{
    //    gameObject.SetActive(false);
    //}
}



