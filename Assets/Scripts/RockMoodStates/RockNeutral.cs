using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockNeutral : RockState
{
    private float movement = 0.005f;

    public override void EnterState(RockStateManager rock) {
        rock.stateText.text = "Current State: Neutral";
        rock.dialougeText.text = "I'm content. :)";
        rock.toggleExpression((int)RockStateManager.ex.neutral);
        // Debug.Log("Rock is Neutral.");
    }

    public override void UpdateState(RockStateManager rock) {
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
}
