using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : InteractiveItem
{
    [SerializeField] private float _boostedJumpVelocity;
    public static float CurrentPositionY;
    public static float SpawnDistance;
    public override void SetSpawnDistance()
    {
        JumpBoost.SpawnDistance += MinGenerateDistance;
    }

    public override void SetCurrentPositionY(float value)
    {
        JumpBoost.CurrentPositionY += value;
    }
    public override float GetSpawnDistance()
    {
        return JumpBoost.SpawnDistance;
    }

    public override float GetCurrentPosition()
    {
        return JumpBoost.CurrentPositionY;
    }

    public override void ResetGeneratorValues()
    {
        JumpBoost.CurrentPositionY = 0;
        JumpBoost.SpawnDistance = 0;
    }
    protected override void OnItemTake()
    {
        Rigidbody2D player = GameObject.Find("PlayerObject").GetComponent<Rigidbody2D>();
        player.velocity = new Vector2(0, _boostedJumpVelocity);
    }
}
