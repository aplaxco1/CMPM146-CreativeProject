using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHappy : RockState
{
    private float movement = 0.01f;

    public override void EnterState(RockStateManager rock) {
        rock.stateText.text = "Current State: Happy";
        rock.dialougeText.text = "I'm happy! :3";
        rock.toggleExpression((int)RockStateManager.ex.happy);
        // Debug.Log("Rock is Happy!");
    }

    public override void UpdateState(RockStateManager rock) {
        if (rock.StatsManager.happinessSlider.value < 75f) {
            rock.SwitchState(new RockNeutral());
        }
        happyAnim(rock.gameObject);
    }

    void happyAnim(GameObject rock) {
        if (rock.transform.position.x >= 4f) { movement = -0.01f; }
        else if (rock.transform.position.x <= -4f) { movement = 0.01f; }
        rock.transform.position = new Vector3(rock.transform.position.x + movement, rock.transform.position.y, rock.transform.position.z);
    }
}
