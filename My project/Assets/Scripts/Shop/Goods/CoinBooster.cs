using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBooster : ShopItem
{
    [SerializeField] private Coin _coin;
    [SerializeField] private int _newValue;
    
    public override void OnBuy()
    {
        _coin.Updatevalue(_newValue);
    }
}
