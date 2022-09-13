using UnityEngine.Events;
using UnityEngine;

public abstract class InteractableItem : LevelGeneratingObject
{ 
    public void UpdateItemData(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
    public abstract void OnItemTake();
}



public class EventManager : MonoBehaviour
{
    public static UnityEvent<int> PickUpCoin = new UnityEvent<int>();

    public static void InvokePickUpCoinEvent(int coinCount)
    {
        PickUpCoin.Invoke(coinCount);
    }
}
