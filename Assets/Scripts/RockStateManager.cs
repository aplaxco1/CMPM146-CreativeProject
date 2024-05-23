using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockStateManager : MonoBehaviour
{

    RockState currentState;

    public float attention = 10f;
    public float hunger = 10f;
    public float thirst = 10f;
    public float moss = 10f;

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
        //SwitchState(new RockHappy());
        Debug.Log("Rock Was Pet!");
        attention += 5;
    }
}