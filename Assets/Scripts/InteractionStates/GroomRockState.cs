using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroomRockState : PlayerState
{
    private float groomTimer = 8f;
    private float animSpeed = 0.5f;

    private GameObject closed_scissors;
    private GameObject open_scissors;

    public override void EnterState(RockStateManager rock)
    {
        Debug.Log("Rock's moss is being cut!");
        rock.scissors.SetActive(true);
        groomTimer = 8f;
        closed_scissors = rock.scissors.transform.Find("closed").gameObject;
        open_scissors = rock.scissors.transform.Find("open").gameObject;
    }

    public override void UpdateState(RockStateManager rock)
    {
        groomAnim(rock);
        groomTimer -= Time.deltaTime;
        if (groomTimer <= 0) {
            rock.moss -= 5;
            rock.scissors.SetActive(false);
            Debug.Log("Rock's moss has been cut!");
            rock.SwitchSubstate(null);
        }
    }

    void groomAnim(RockStateManager rock) {
        animSpeed -= Time.deltaTime;
        if (animSpeed <= 0) {
            if (open_scissors.activeSelf) {
                open_scissors.SetActive(false);
                closed_scissors.SetActive(true);
            }
            else if (closed_scissors.activeSelf) {
                open_scissors.SetActive(true);
                closed_scissors.SetActive(false);
            }
            animSpeed = 0.5f;
        }
    }
    
}