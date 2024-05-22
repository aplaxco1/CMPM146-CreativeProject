using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSad : RockState
{
    public override void EnterState(RockStateManager rock)
    {
        Debug.Log("Rock is Sad!");
    }

    public override void UpdateState(RockStateManager rock)
    {
    }
    
}
