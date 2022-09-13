using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Items List", menuName ="Generator", order =51)]
public class ItemsList : ScriptableObject
{
    [SerializeField] private List<LevelGeneratingObject> _items;
    public IEnumerable<LevelGeneratingObject> Items => _items;
}
