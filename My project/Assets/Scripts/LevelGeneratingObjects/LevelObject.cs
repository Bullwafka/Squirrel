using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : DisablingObject
{
    [SerializeField] protected LevelGeneratingObject _object;
    public LevelGeneratingObject Object => _object;
}
