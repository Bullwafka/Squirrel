using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : LevelObject
{
    [SerializeField] private InteractableItem _item;
    public InteractableItem Item => _item;

    private void Awake()
    {
        _object = _item;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _item.OnItemTake();
            gameObject.SetActive(false);
        }
    }
}
