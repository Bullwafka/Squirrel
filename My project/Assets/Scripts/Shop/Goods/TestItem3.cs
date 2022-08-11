using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Test3", menuName = "Shop/Test3", order = 51)]
public class TestItem3 : ShopItem
{
    public override void OnBuy()
    {
        Debug.Log(Name + "Bought");
    }
}
