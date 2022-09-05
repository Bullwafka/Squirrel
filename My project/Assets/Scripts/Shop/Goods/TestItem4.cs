using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem4 : ShopItem
{
    public override void OnBuy()
    {
        Debug.Log(Name + "Bought");
    }
}
