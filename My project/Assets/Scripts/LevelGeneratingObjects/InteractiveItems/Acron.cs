using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Acron", menuName = "Level objects/Acron", order = 51)]
[System.Serializable]
public class Acron : InteractableItem
{
    [SerializeField] private int _staminaValue;
    private Player _player = null;
    public override void OnItemTake()
    {
        if(_player == null)
        {
            _player = GameObject.FindObjectOfType<Player>().GetComponent<Player>();
        }
        _player.ChangeStaminaValue(_staminaValue);
    }
}
