using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHungry : RockState
{
    public override void EnterState(RockStateManager rock)
    {
        rock.stateText.text = "Current State: Hungry";
        rock.StatsManager.rateOfDecay *= 1.5f;
        rock.dialougeText.text = "I'm hungry... :<";
        rock.toggleExpression((int)RockStateManager.ex.hungry);
        // Debug.Log("Rock is Hungry!");
    }

    public override void UpdateState(RockStateManager rock)
    {
        if (rock.StatsManager.happinessSlider.value >= 50f) {
            rock.StatsManager.rateOfDecay = rock.StatsManager.rate;
            rock.SwitchState(new RockNeutral());
        }
        if (rock.StatsManager.happinessSlider.value <= 15f) {
            rock.SwitchState(new RockSad());
        }
        if (rock.hunger > rock.attention || rock.hunger > rock.thirst || rock.hunger > rock.moss) {
            rock.StatsManager.rateOfDecay = rock.StatsManager.rate;
            rock.getHighestStat();
        } 
    }
    
}
