using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMossy : RockState
{
    public override void EnterState(RockStateManager rock)
    {
        rock.stateText.text = "Current State: Mossy";
        //Debug.Log("Rock is Mossy!");
    }

    public override void UpdateState(RockStateManager rock)
    {
        if (rock.StatsManager.happinessSlider.value >= 50f) {
            rock.SwitchState(new RockNeutral());
        }
        if (rock.moss > rock.attention || rock.moss > rock.thirst || rock.moss > rock.hunger) {
            rock.getHighestStat();
        } 
    }
    
}