using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThirsty : RockState
{
    public override void EnterState(RockStateManager rock)
    {
        rock.stateText.text = "Current State: Thirsty";
        //Debug.Log("Rock is Thirsty!");
    }

    public override void UpdateState(RockStateManager rock)
    {
        if (rock.StatsManager.happinessSlider.value >= 50f) {
            rock.SwitchState(new RockNeutral());
        }
        if (rock.thirst > rock.attention || rock.thirst > rock.hunger || rock.thirst > rock.moss) {
            rock.getHighestStat();
        } 
    }
    
}