using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHungry : RockState
{
    private float movement = 0.0025f;
    public float timeTillPopup = 0f;
    public float popupTime = 3f;
    public bool popupActive = false;

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
        hungryAnim(rock.gameObject);
        timeTillPopup -= Time.deltaTime;
        if (timeTillPopup < 0 && !popupActive) {
            rock.hungryAnim.SetActive(true);
            popupActive = true;
        }
        if (popupActive) {
            hungryPopup(rock);
        }
        if (rock.StatsManager.happinessSlider.value >= 50f) {
            rock.hungryAnim.SetActive(false);
            rock.StatsManager.rateOfDecay = rock.StatsManager.rate;
            rock.SwitchState(new RockNeutral());
        }
        if (rock.StatsManager.happinessSlider.value <= 15f) {
            rock.hungryAnim.SetActive(false);
            rock.SwitchState(new RockSad());
        }
        if (rock.hunger > rock.attention || rock.hunger > rock.thirst || rock.hunger > rock.moss) {
            rock.hungryAnim.SetActive(false);
            rock.StatsManager.rateOfDecay = rock.StatsManager.rate;
            rock.getHighestStat();
        } 
    }

    void hungryAnim(GameObject rock) {
        if (rock.transform.position.x >= 4f) { movement = -0.0025f; }
        else if (rock.transform.position.x <= -4f) { movement = 0.0025f; }
        rock.transform.position = new Vector3(rock.transform.position.x + movement, rock.transform.position.y, rock.transform.position.z);
    }

    public void hungryPopup(RockStateManager rock) {
        rock.hungryAnim.SetActive(true);
        popupTime -= Time.deltaTime;
        if (popupTime < 0) {
            rock.hungryAnim.SetActive(false);
            popupActive = false;
            timeTillPopup = Random.Range(4f,6f);
            popupTime = Random.Range(3f, 4f);
        }
    }
    
}
