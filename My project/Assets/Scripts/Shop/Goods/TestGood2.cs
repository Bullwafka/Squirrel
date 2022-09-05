using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGood2 : ShopItem
{
    public override void OnBuy()
    {
       Debug.Log(Name + "Bought");
    }
}
