using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : InteractiveItem
{
    [SerializeField] private int _coinValue;
    public static float CurrentPositionY;
    public static float SpawnDistance;
    public override void SetSpawnDistance()
    {
        Coin.SpawnDistance += MinGenerateDistance;
    }

    public override void SetCurrentPositionY(float value)
    {
        Coin.CurrentPositionY += value;
    }

    public override float GetSpawnDistance()
    {
        return Coin.SpawnDistance;
    }

    public override float GetCurrentPosition()
    {
        return Coin.CurrentPositionY;
    }

    protected override void OnItemTake()
    {
        EventManager.InvokePickUpCoinEvent(_coinValue);
    }
}
