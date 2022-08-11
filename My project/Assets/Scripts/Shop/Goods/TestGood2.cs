using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Test2", menuName = "Shop/Test2", order = 51)]
public class TestGood2 : ShopItem
{
    public override void OnBuy()
    {
       Debug.Log(Name + "Bought");
    }
}
