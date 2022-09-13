using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Shop/Shop items list", order = 51)]
public class ShopItemsList : ScriptableObject
{
    [SerializeField] public List<ShopItem> List;
}
