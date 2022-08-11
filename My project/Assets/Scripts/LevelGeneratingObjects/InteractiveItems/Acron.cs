using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acron : InteractiveItem
{
    [SerializeField] private int _staminaValue;
    public static float CurrentPositionY;
    public static float SpawnDistance;
    public override void SetSpawnDistance()
    {
        Acron.SpawnDistance += MinGenerateDistance;
    }

    public override void SetCurrentPositionY(float value)
    {
        Acron.CurrentPositionY += value;
    }

    public override float GetSpawnDistance()
    {
        return Acron.SpawnDistance;
    }

    public override float GetCurrentPosition()
    {
        return Acron.CurrentPositionY;
    }
    protected override void OnItemTake()
    {
        Player player = GameObject.Find("PlayerObject").GetComponent<Player>();
        player.ChangeStamina(_staminaValue);
    }
}
