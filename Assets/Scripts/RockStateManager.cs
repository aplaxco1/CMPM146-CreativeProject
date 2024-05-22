using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockStateManager : MonoBehaviour
{

    RockState currentState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = new RockHappy();
        currentState.EnterState(this);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
    }

    public void SwitchState(RockState state) {
        currentState = state;
        state.EnterState(this);
    }

    void OnMouseDown() {
        SwitchState(new RockHappy());
    }
}