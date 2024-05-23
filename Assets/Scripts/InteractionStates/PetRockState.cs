using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetRockState : PlayerState
{
    private float petTimer = 1f;

    public override void EnterState(RockStateManager rock)
    {
        Debug.Log("Rock is being Pet!");
        rock.hand.SetActive(true);
        petTimer = 1;
    }

    public override void UpdateState(RockStateManager rock)
    {
        petTimer -= Time.deltaTime;
        if (petTimer <= 0) {
            rock.attention += 5;
            rock.hand.SetActive(false);
            Debug.Log("Rock has been pet!");
            rock.SwitchSubstate(null);
        }
    }
    
}