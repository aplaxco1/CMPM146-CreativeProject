using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedRockState : PlayerState
{
    private float feedTimer = 3f;
    private float animSpeed = 0.005f;

    public override void EnterState(RockStateManager rock)
    {
        Debug.Log("Rock is being fed!");
        rock.food.SetActive(true);
        feedTimer = 3f;
    }

    public override void UpdateState(RockStateManager rock)
    {
        feedAnim(rock);
        feedTimer -= Time.deltaTime;
        if (feedTimer <= 0) {
            if (!(rock.currentState is RockBored)) {
                rock.StatsManager.IncreaseHunger();
            }
            else if (Random.value > 0.5f){
                rock.StatsManager.IncreaseHunger();
            }
            else {
                rock.dialougeText.text = "I'm not interested in eating right now...";
            }
            rock.food.SetActive(false);
            rock.SwitchSubstate(null);
        }
    }

    void feedAnim(RockStateManager rock) {
        if (rock.food.transform.localPosition.y >= 10f) {animSpeed = -0.005f; }
        else if (rock.food.transform.localPosition.y <= 9f) {animSpeed = 0.005f; }
        rock.food.transform.localPosition = new Vector3(rock.food.transform.localPosition.x, rock.food.transform.localPosition.y + animSpeed, rock.food.transform.localPosition.z);
    }
    
}