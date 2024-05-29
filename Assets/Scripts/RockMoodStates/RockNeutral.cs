using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockNeutral : RockState
{
    public override void EnterState(RockStateManager rock) {
        Debug.Log("Rock is Neutral.");
    }

    public override void UpdateState(RockStateManager rock) {
        if (rock.attention > 50f) {
            rock.SwitchState(new RockHappy());
        }
    }
}
