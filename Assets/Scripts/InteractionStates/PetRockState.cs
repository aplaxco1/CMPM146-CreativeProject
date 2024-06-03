using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetRockState : PlayerState
{
    private float petTimer = 2f;
    private float animSpeed = 0.05f;

    public override void EnterState(RockStateManager rock)
    {
        Debug.Log("Rock is being pet!");
        rock.hand.SetActive(true);
        petTimer = 2f;
    }

    public override void UpdateState(RockStateManager rock)
    {
        petAnim(rock);
        petTimer -= Time.deltaTime;
        if (petTimer <= 0) {
            if (!(rock.currentState is RockBored)) {
                rock.StatsManager.IncreaseAttention();
            }
            else if (Random.value > 0.5f){
                rock.StatsManager.IncreaseAttention();
            }
            else {
                rock.dialougeText.text = "You don't really love me. :(";
            }
            rock.hand.SetActive(false);
            Debug.Log("Rock has been pet!");
            rock.SwitchSubstate(null);
        }
    }

    void petAnim(RockStateManager rock) {
        if (rock.hand.transform.localPosition.x >= 5f) {animSpeed = -0.05f; }
        else if (rock.hand.transform.localPosition.x <= -5f) {animSpeed = 0.05f; }
        rock.hand.transform.localPosition = new Vector3(rock.hand.transform.localPosition.x + animSpeed, rock.hand.transform.localPosition.y, rock.hand.transform.localPosition.z);
    }
    
}