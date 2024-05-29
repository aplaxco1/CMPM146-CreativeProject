using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedRockState : PlayerState
{
    private float feedTimer = 5f;
    private float animSpeed = 0.005f;

    public override void EnterState(RockStateManager rock)
    {
        Debug.Log("Rock is being Fed!");
        rock.food.SetActive(true);
        feedTimer = 5f;
    }

    public override void UpdateState(RockStateManager rock)
    {
        feedAnim(rock);
        feedTimer -= Time.deltaTime;
        if (feedTimer <= 0) {
            rock.hunger += 10;
            rock.food.SetActive(false);
            Debug.Log("Rock has been fed!");
            rock.SwitchSubstate(null);
        }
    }

    void feedAnim(RockStateManager rock) {
        if (rock.food.transform.localPosition.y >= 10f) {animSpeed = -0.005f; }
        else if (rock.food.transform.localPosition.y <= 9f) {animSpeed = 0.005f; }
        rock.food.transform.localPosition = new Vector3(rock.food.transform.localPosition.x, rock.food.transform.localPosition.y + animSpeed, rock.food.transform.localPosition.z);
    }
    
}