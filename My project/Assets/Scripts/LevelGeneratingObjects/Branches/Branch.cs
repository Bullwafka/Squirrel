using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Branch : LevelGeneratingObject
{
    public static float CurrentPositionY;
    public static float SpawnDistance;
    public override void SetCurrentPositionY(float value)
    {
        Branch.CurrentPositionY += value;
    }

    public override void SetSpawnDistance()
    {
        Branch.SpawnDistance += MinGenerateDistance;
    }

    public override float GetCurrentPosition()
    {
        return Branch.CurrentPositionY;
    }

    public override float GetSpawnDistance()
    {
        return Branch.SpawnDistance;
    }
}
