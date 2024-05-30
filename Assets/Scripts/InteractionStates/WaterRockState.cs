using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterRockState : PlayerState
{
    private float waterTimer = 3f;
    private float animSpeed = 0.5f;

    public override void EnterState(RockStateManager rock)
    {
        Debug.Log("Rock is being watered!");
        rock.water.SetActive(true);
        rock.water.transform.eulerAngles = new Vector3(rock.water.transform.eulerAngles.x, rock.water.transform.eulerAngles.y, 350);
        waterTimer = 3f;
    }

    public override void UpdateState(RockStateManager rock)
    {
        waterAnim(rock);
        waterTimer -= Time.deltaTime;
        if (waterTimer <= 0) {
            rock.StatsManager.IncreaseThirst();
            rock.StatsManager.DecreaseHygiene();
            rock.StatsManager.IncreaseHappiness();
            rock.water.SetActive(false);
            rock.SwitchSubstate(null);
        }
    }

    void waterAnim(RockStateManager rock) {
        if (rock.water.transform.eulerAngles.z >= 350) { animSpeed = -0.5f; }
        else if (rock.water.transform.eulerAngles.z <= 300) { animSpeed = 0.5f; }
        rock.water.transform.eulerAngles = new Vector3(rock.water.transform.eulerAngles.x, rock.water.transform.eulerAngles.y, rock.water.transform.eulerAngles.z + animSpeed);
    }
    
}