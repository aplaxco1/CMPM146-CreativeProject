using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHungry : RockState
{
    public override void EnterState(RockStateManager rock)
    {
        rock.stateText.text = "Current State: Hungry";
        rock.StatsManager.rateOfDecay *= 1.5
        // Debug.Log("Rock is Hungry!");
    }

    public override void UpdateState(RockStateManager rock)
    {
        if (rock.StatsManager.happinessSlider.value >= 50f) {
            rock.SwitchState(new RockNeutral());
            rock.StatsManager.rateOfDecay = rock.StatsManager.rate;
        }
        if (rock.hunger > rock.attention || rock.hunger > rock.thirst || rock.hunger > rock.moss) {
            rock.getHighestStat();
        } 
    }
    
}
