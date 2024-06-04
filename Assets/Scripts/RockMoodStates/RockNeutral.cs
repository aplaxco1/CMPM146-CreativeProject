using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockNeutral : RockState
{
    private float movement = 0.005f;
    private float timeTillBlink = 2.5f;
    private float blinkTimer = 0.25f;
    private bool isBlinking = false;

    public override void EnterState(RockStateManager rock) {
        rock.stateText.text = "Current State: Neutral";
        rock.dialougeText.text = "I'm content. :)";
        rock.toggleExpression((int)RockStateManager.ex.neutral);
        // Debug.Log("Rock is Neutral.");
    }

    public override void UpdateState(RockStateManager rock) {
        timeTillBlink -= Time.deltaTime;
        if (timeTillBlink < 0 && !isBlinking) {
            isBlinking = true;
            rock.toggleExpression((int)RockStateManager.ex.neutral_closed);
        }
        if (isBlinking) {
            neutralBlink(rock);
        }
        neutralAnim(rock.gameObject);
        if (rock.StatsManager.happinessSlider.value >= 75f) {
            rock.SwitchState(new RockHappy());
        }
        if (rock.StatsManager.happinessSlider.value < 50f) {
            rock.getHighestStat();
        }
    }

    void neutralAnim(GameObject rock) {
        if (rock.transform.position.x >= 4f) { movement = -0.005f; }
        else if (rock.transform.position.x <= -4f) { movement = 0.005f; }
        rock.transform.position = new Vector3(rock.transform.position.x + movement, rock.transform.position.y, rock.transform.position.z);
    }

    void neutralBlink(RockStateManager rock) {
        blinkTimer -= Time.deltaTime;
        if (blinkTimer < 0) {
            rock.toggleExpression((int)RockStateManager.ex.neutral);
            isBlinking = false;
            blinkTimer = 0.25f;
            timeTillBlink = 2.5f;
        }
    }
}
