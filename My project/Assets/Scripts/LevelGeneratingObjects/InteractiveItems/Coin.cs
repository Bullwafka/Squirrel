using UnityEngine;
[CreateAssetMenu(fileName = "Coin", menuName = "Level objects/Coin", order = 51)]
[System.Serializable]
public class Coin : InteractableItem
{
    [SerializeField] private int _coinValue;

    //SavingSystem value
    public int CoinValue => _coinValue;

    public override void OnItemTake()
    {
        EventManager.InvokePickUpCoinEvent(_coinValue);
    }

    public void Updatevalue(int value)
    {
        _coinValue = value;
    }
}
