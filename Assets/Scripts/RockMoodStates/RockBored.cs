using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBored : RockState
{

    private bool isMoving = false;
    private float timeMove = 2f;
    private float timeTillMove = 2f;
    private float movement = 0.0025f;
    private float timeTillEllipse = 0f;
    private float ellipseSpeed = 0.5f;
    private bool isEllipse = false;
    private int ellipseCount = 0;

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
        }
        if (isMoving) {
            boredAnim(rock);
        }
        timeTillEllipse -= Time.deltaTime;
        if (!isEllipse && timeTillEllipse <= 0) {
            isEllipse = true;
        }
        if (isEllipse) {
            ellipseAnim(rock);
        }


        if (rock.StatsManager.happinessSlider.value >= 50f) {
            toggleEllipseOff(rock);
            rock.SwitchState(new RockNeutral());
        }
        if (rock.StatsManager.happinessSlider.value <= 15f) {
            toggleEllipseOff(rock);
            rock.SwitchState(new RockSad());
        }
        if (rock.attention > rock.hunger || rock.attention > rock.thirst || rock.attention > rock.moss) {
            toggleEllipseOff(rock);
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
            timeMove = Random.Range(1f, 4f);
            timeTillMove = Random.Range(1f, 5f);
        }
    }

    private void ellipseAnim(RockStateManager rock) {
        if (ellipseCount == 0) {
            rock.boredAnims[ellipseCount].SetActive(true);
            ellipseCount += 1;
        }
        ellipseSpeed -= Time.deltaTime;
        if (ellipseSpeed < 0 && ellipseCount < 3) {
            rock.boredAnims[ellipseCount].SetActive(true);
            ellipseCount += 1;
            ellipseSpeed = 0.5f;
            if (ellipseCount == 3) {
                ellipseSpeed = Random.Range(2f, 3f);
            }
        }
        else if (ellipseSpeed < 0) {
            toggleEllipseOff(rock);
            ellipseSpeed = 0.5f;
            ellipseCount = 0;
            timeTillEllipse = Random.Range(6f, 8f);
            isEllipse = false;
        }

    }

    private void toggleEllipseOff(RockStateManager rock) {
        for (int i = 0; i < rock.boredAnims.Count; i += 1) {
            rock.boredAnims[i].SetActive(false);
        }
    }
    
}
