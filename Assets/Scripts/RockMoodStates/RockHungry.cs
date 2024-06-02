using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHungry : RockState
{
    public override void EnterState(RockStateManager rock)
    {
        rock.stateText.text = "Current State: Hungry";
        // Debug.Log("Rock is Hungry!");
    }

    public override void UpdateState(RockStateManager rock)
    {
        if (rock.StatsManager.happinessSlider.value >= 50f) {
            rock.SwitchState(new RockNeutral());
        }
        if (rock.hunger > rock.attention || rock.hunger > rock.thirst || rock.hunger > rock.moss) {
            rock.getHighestStat();
        } 
    }
    
}
