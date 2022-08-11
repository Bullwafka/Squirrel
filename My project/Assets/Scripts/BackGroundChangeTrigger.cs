using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BackGroundChangeTrigger : MonoBehaviour
{
    [SerializeField] private float _backGroundChangeRange;

    private float _currentTriggerPositionY;

    public event UnityAction ChangeLocation;

    private void Start()
    {
        gameObject.transform.position = new Vector2(0, _backGroundChangeRange);
        _currentTriggerPositionY = gameObject.transform.position.y;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Squirrel"))
        {
            ChangeLocation.Invoke();
            gameObject.transform.position = new Vector2(0, _currentTriggerPositionY + _backGroundChangeRange);
            _currentTriggerPositionY = gameObject.transform.position.y;
        }
    }
}
