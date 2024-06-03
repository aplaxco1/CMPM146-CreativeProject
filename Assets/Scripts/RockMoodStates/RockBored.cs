using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBored : RockState
{
    public override void EnterState(RockStateManager rock)
    {
        rock.stateText.text = "Current State: Bored";
        // Debug.Log("Rock is Bored!");
    }

    public override void UpdateState(RockStateManager rock)
    {
        if (rock.StatsManager.happinessSlider.value >= 50f) {
            rock.SwitchState(new RockNeutral());
        }
        if (rock.attention > rock.hunger || rock.attention > rock.thirst || rock.attention > rock.moss) {
            rock.getHighestStat();
        } 
    }
    
}
