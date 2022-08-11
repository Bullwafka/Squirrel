using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Test1", menuName = "Shop/Test1", order = 51)]
public class TestGood1 : ShopItem
{
    public override void OnBuy()
    {
        Debug.Log(Name + "Bought");
    }
}