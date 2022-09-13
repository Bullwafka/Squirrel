using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "JumpBoost", menuName = "Level objects/JumpBoost", order = 51)]
[System.Serializable]
public class JumpBoost : InteractableItem
{
    [SerializeField] private float _boostedJumpVelocity;
    private Rigidbody2D _playerRigidbody = null;

    public override void OnItemTake()
    {
        if(_playerRigidbody == null)
        {
            _playerRigidbody = GameObject.FindObjectOfType<Player>().GetComponent<Rigidbody2D>();
        }
        _playerRigidbody.velocity = new Vector2(0, _boostedJumpVelocity);
    }
}
