using UnityEngine.Events;
using UnityEngine;

public abstract class InteractiveItem : LevelGeneratingObject
{
    public void UpdateItemData(string json)
    {
        JsonUtility.FromJsonOverwrite(json, this);
    }
    protected abstract void OnItemTake();
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            OnItemTake();
            gameObject.SetActive(false);
        }
    }
}

public class EventManager : MonoBehaviour
{
    public static UnityEvent<int> PickUpCoin = new UnityEvent<int>();

    public static void InvokePickUpCoinEvent(int coinCount)
    {
        PickUpCoin.Invoke(coinCount);
    }
}
