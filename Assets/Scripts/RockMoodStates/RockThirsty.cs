using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThirsty : RockState
{
    public float timeTillPopup = 0f;
    public float popupTime = 3f;
    public bool popupActive = false;

    public override void EnterState(RockStateManager rock)
    {
        rock.stateText.text = "Current State: Thirsty";
        rock.dialougeText.text = "I really need water... ;w;";
        rock.toggleExpression((int)RockStateManager.ex.thirsty);
        //Debug.Log("Rock is Thirsty!");
    }

    public override void UpdateState(RockStateManager rock)
    {
        timeTillPopup -= Time.deltaTime;
        if (timeTillPopup < 0 && !popupActive) {
            popupActive = true;
        }
        if (popupActive) {
            thirstyAnim(rock);
        }
        if (rock.StatsManager.happinessSlider.value >= 50f) {
            rock.SwitchState(new RockNeutral());
        }
        if (rock.StatsManager.happinessSlider.value <= 15f) {
            rock.SwitchState(new RockSad());
        }
        if (rock.thirst > rock.attention || rock.thirst > rock.hunger || rock.thirst > rock.moss) {
            rock.getHighestStat();
        } 
    }

    public void thirstyAnim(RockStateManager rock) {
        rock.thirstyAnim.SetActive(true);
        popupTime -= Time.deltaTime;
        if (popupTime < 0) {
            rock.thirstyAnim.SetActive(false);
            popupActive = false;
            timeTillPopup = Random.Range(6f, 8f);
            popupTime = Random.Range(3f, 4f);
        }

    }
    
}
