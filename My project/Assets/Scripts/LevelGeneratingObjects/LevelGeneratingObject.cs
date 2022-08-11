using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class LevelGeneratingObject : MonoBehaviour
{
    [SerializeField] private int _poolSize = 30;
    public int PoolSize => _poolSize;

    [SerializeField] private float _minGenerateDistance;
    public float MinGenerateDistance => _minGenerateDistance;

    [SerializeField] private float _maxGenerateDistance;
    public float MaxGenerateDistance => _maxGenerateDistance;

    [SerializeField] private float _minPositionX;
    public float MinPositionX => _minPositionX;

    [SerializeField] private float _maxPositionX;
    public float MaxPositionX => _maxPositionX;

    
    public virtual float GetSpawnDistance()
    {
        return 0;
    }
    public virtual void SetCurrentPositionY(float value)
    {

    }

    public virtual float GetCurrentPosition()
    {
        return 0;
    }
    public virtual void SetSpawnDistance()
    {
        
    }
    public virtual void ResetGeneratorValues()
    {

    }
    protected virtual void OnDisableObject()
    {

    }
    public void DisableObject()
    {
        OnDisableObject();
        gameObject.SetActive(false);
    }
}

