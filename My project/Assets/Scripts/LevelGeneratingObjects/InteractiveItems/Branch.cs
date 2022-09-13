using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "NewBranch", menuName = "Level objects/Branch", order = 51)]
public class Branch : LevelGeneratingObject
{
    new public float MinPositionX { get { return base._minPositionX; } set {base._minPositionX = value; }}
    new public float MaxPositionX { get { return base._maxPositionX; } set {base._maxPositionX = value; }}

}
