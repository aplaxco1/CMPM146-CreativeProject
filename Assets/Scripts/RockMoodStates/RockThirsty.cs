using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThirsty : RockState
{
    private float movement = 0.0025f;
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
        thirstyAnim(rock.gameObject);
        timeTillPopup -= Time.deltaTime;
        if (timeTillPopup < 0 && !popupActive) {
            rock.thirstyAnim.SetActive(true);
            popupActive = true;
        }
        if (popupActive) {
            thirstyPopup(rock);
        }
        if (rock.StatsManager.happinessSlider.value >= 50f) {
            rock.thirstyAnim.SetActive(false);
            rock.SwitchState(new RockNeutral());
        }
        if (rock.StatsManager.happinessSlider.value <= 15f) {
            rock.thirstyAnim.SetActive(false);
            rock.SwitchState(new RockSad());
        }
        if (rock.thirst > rock.attention || rock.thirst > rock.hunger || rock.thirst > rock.moss) {
            rock.thirstyAnim.SetActive(false);
            rock.getHighestStat();
        } 
    }
    
    void thirstyAnim(GameObject rock) {
        if (rock.transform.position.x >= 4f) { movement = -0.0025f; }
        else if (rock.transform.position.x <= -4f) { movement = 0.0025f; }
        rock.transform.position = new Vector3(rock.transform.position.x + movement, rock.transform.position.y, rock.transform.position.z);
    }

    public void thirstyPopup(RockStateManager rock) {
        popupTime -= Time.deltaTime;
        if (popupTime < 0) {
            rock.thirstyAnim.SetActive(false);
            popupActive = false;
            timeTillPopup = Random.Range(6f, 8f);
            popupTime = Random.Range(3f, 4f);
        }
    }
    
}
