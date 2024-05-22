using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHappy : RockState
{
    private float sadTimer = 3f;
    private float movement = 0.05f;

    public override void EnterState(RockStateManager rock) {
        Debug.Log("Rock is Happy!");
        sadTimer = 3f;
    }

    public override void UpdateState(RockStateManager rock) {
        sadTimer -= Time.deltaTime;
        if (sadTimer <= 0) {
            rock.SwitchState(new RockSad());
        }
        happyAnim(rock.gameObject);
    }

    void happyAnim(GameObject rock) {
        if (rock.transform.position.x >= 4f) {
            movement = -0.05f;
        }
        else if (rock.transform.position.x <= -4f) {
            movement = 0.05f;
        }
        rock.transform.position = new Vector3(rock.transform.position.x + movement, rock.transform.position.y, rock.transform.position.z);
    }
}
