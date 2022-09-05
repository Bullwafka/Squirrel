using UnityEngine;
using UnityEngine.UI;
using TMPro;

public abstract class ShopItem : MonoBehaviour
{
    [SerializeField] public Sprite Sprite;
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private int _price;

    public string Name => _name;
    public string Description => _description;
    public int Price => _price;
    public abstract void OnBuy();
}
