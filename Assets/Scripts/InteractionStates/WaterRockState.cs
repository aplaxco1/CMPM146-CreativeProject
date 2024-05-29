using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRockState : PlayerState
{
    private float waterTimer = 5f;
    private float animSpeed = 0.5f;

    public override void EnterState(RockStateManager rock)
    {
        Debug.Log("Rock is being Watered!");
        rock.water.SetActive(true);
        waterTimer = 5f;
    }

    public override void UpdateState(RockStateManager rock)
    {
        waterAnim(rock);
        waterTimer -= Time.deltaTime;
        if (waterTimer <= 0) {
            rock.thirst += 10;
            rock.water.SetActive(false);
            Debug.Log("Rock has been watered!");
            rock.SwitchSubstate(null);
        }
    }

    void waterAnim(RockStateManager rock) {
        if (rock.water.transform.eulerAngles.z >= 350) { animSpeed = -0.5f; }
        else if (rock.water.transform.eulerAngles.z <= 280) { animSpeed = 0.5f; }
        Debug.Log(rock.water.transform.eulerAngles.z);
        rock.water.transform.eulerAngles = new Vector3(rock.water.transform.eulerAngles.x, rock.water.transform.eulerAngles.y, rock.water.transform.eulerAngles.z + animSpeed);
    }
    
}