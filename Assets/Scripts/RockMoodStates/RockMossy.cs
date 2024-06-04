using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMossy : RockState
{
    private float movement = 0.0025f;

    private float sparkleSpeed = 0.25f;
    private GameObject sparkle1;
    private GameObject sparkle2;

    public override void EnterState(RockStateManager rock)
    {
        rock.stateText.text = "Current State: Mossy";
        rock.dialougeText.text = "I need a trim! :<";
        rock.toggleExpression((int)RockStateManager.ex.mossy);
        rock.mossyAnim.SetActive(true);
        sparkle1 = rock.mossyAnim.transform.Find("Sparkle1").gameObject;
        sparkle2 = rock.mossyAnim.transform.Find("Sparkle2").gameObject;
        //Debug.Log("Rock is Mossy!");
    }

    public override void UpdateState(RockStateManager rock)
    {
        mossyAnim(rock.gameObject);
        sparkleAnim(rock);
        if (rock.StatsManager.happinessSlider.value >= 50f) {
            rock.mossyAnim.SetActive(false);
            rock.SwitchState(new RockNeutral());
        }
        if (rock.StatsManager.happinessSlider.value <= 15f) {
            rock.mossyAnim.SetActive(false);
            rock.SwitchState(new RockSad());
        }
        if (rock.moss > rock.attention || rock.moss > rock.thirst || rock.moss > rock.hunger) {
            rock.mossyAnim.SetActive(false);
            rock.getHighestStat();
        } 
    }

    void mossyAnim(GameObject rock) {
        if (rock.transform.position.x >= 4f) { movement = -0.0025f; }
        else if (rock.transform.position.x <= -4f) { movement = 0.0025f; }
        rock.transform.position = new Vector3(rock.transform.position.x + movement, rock.transform.position.y, rock.transform.position.z);
    }

    void sparkleAnim(RockStateManager rock) {
        sparkleSpeed -= Time.deltaTime;
        if (sparkleSpeed <= 0) {
            if (sparkle1.activeSelf) {
                sparkle1.SetActive(false);
                sparkle2.SetActive(true);
            }
            else if (sparkle2.activeSelf) {
                sparkle1.SetActive(true);
                sparkle2.SetActive(false);
            }
            sparkleSpeed = 0.25f;
        }
    }
    
}
