using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireMover : MonoBehaviour
{
    [SerializeField] private float _normalSpeed;
    [SerializeField] private float _boostedSpeed;
    [SerializeField] private float _suddenDeathNormalSpeed;
    [SerializeField] private float _suddenDeathBoostedSpeed;
    [SerializeField] private GameObject _playerObject;

    private float _fireSpeed;

    private SuddenDeathAlert _suddenDeath;

    private bool _fireIsStopped;



    private void OnEnable()
    {
        _fireSpeed = _normalSpeed;
        _suddenDeath = GetComponent<SuddenDeathAlert>();
        _suddenDeath.SuddenDeath += SuddenDeathHandler;
    }

    private void OnDisable()
    {
        _suddenDeath.SuddenDeath -= SuddenDeathHandler;
    }
    private void Update()
    {
        if (!_fireIsStopped)
        {
            MoveFire();
        }
    }
    public void MoveFire()
    {
        if (Vector2.Distance(gameObject.transform.position, _playerObject.transform.position) > 6)
        {
            _fireSpeed = _boostedSpeed;
        }
        else
        {
            _fireSpeed = _normalSpeed;
        }
        gameObject.transform.Translate(Vector2.up * _fireSpeed * Time.deltaTime);
    }
    public void StopFire()
    {
        _fireIsStopped = true;
    }

    private void SuddenDeathHandler()
    {
        _normalSpeed = _suddenDeathNormalSpeed;
        _boostedSpeed = _suddenDeathBoostedSpeed;
    }
}
    
