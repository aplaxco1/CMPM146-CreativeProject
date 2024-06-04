using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBored : RockState
{

    private bool isMoving = false;
    private float timeMove = 2f;
    private float timeTillMove = 2f;
    private float movement = 0.0025f;

    public override void EnterState(RockStateManager rock)
    {
        rock.stateText.text = "Current State: Bored";
        rock.dialougeText.text = "I'm kinda bored...";
        rock.toggleExpression((int)RockStateManager.ex.bored);
        // Debug.Log("Rock is Bored!");
    }

    public override void UpdateState(RockStateManager rock)
    {
        timeTillMove -= Time.deltaTime;
        if (!isMoving && timeTillMove <= 0) {
            isMoving = true;
            timeMove = Random.Range(1f, 4f);
            timeTillMove = Random.Range(1f, 5f);
        }
        if (isMoving) {
            boredAnim(rock);
        }
        if (rock.StatsManager.happinessSlider.value >= 50f) {
            rock.SwitchState(new RockNeutral());
        }
        if (rock.StatsManager.happinessSlider.value <= 15f) {
            rock.SwitchState(new RockSad());
        }
        if (rock.attention > rock.hunger || rock.attention > rock.thirst || rock.attention > rock.moss) {
            rock.getHighestStat();
        } 
    }

    private void boredAnim(RockStateManager rock) {
        timeMove -= Time.deltaTime;
        if (timeMove > 0) {
            if (rock.transform.position.x >= 4f) { movement = -0.0025f; }
            else if (rock.transform.position.x <= -4f) { movement = 0.0025f; }
            rock.transform.position = new Vector3(rock.transform.position.x + movement, rock.transform.position.y, rock.transform.position.z);
        }
        else {
            isMoving = false;
        }
    }
    
}
