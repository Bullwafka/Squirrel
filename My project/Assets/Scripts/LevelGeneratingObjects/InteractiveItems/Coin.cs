using UnityEngine;

public class Coin : InteractiveItem
{
    [SerializeField] private int _coinValue;

    //SavingSystem value
    public int CoinValue => _coinValue;

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

    public override void ResetGeneratorValues()
    {
        Coin.CurrentPositionY = 0;
        Coin.SpawnDistance = 0;
    }
    protected override void OnItemTake()
    {
        EventManager.InvokePickUpCoinEvent(_coinValue);
    }

    public void Updatevalue(int value)
    {
        _coinValue = value;
    }
}
