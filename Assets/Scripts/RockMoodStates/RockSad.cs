using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockSad : RockState
{
    public override void EnterState(RockStateManager rock)
    {
        rock.stateText.text = "Current State: Sad";
        rock.dialougeText.text = "I'm really sad! :(";
        // Debug.Log("Rock is Sad!");
    }

    public override void UpdateState(RockStateManager rock)
    {
        if (rock.StatsManager.happinessSlider.value >= 15f) {
            rock.getHighestStat();
        }
    }
    
}
