using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHungry : RockState
{
    public override void EnterState(RockStateManager rock)
    {
        rock.stateText.text = "Current State: Hungry";
        rock.dialougeText.text = "I'm so hungry... I just keep feeling worse. :(";
        rock.StatsManager.rateOfDecay *= 1.5f;
        rock.dialougeText.text = "I'm hungry... :<";
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
