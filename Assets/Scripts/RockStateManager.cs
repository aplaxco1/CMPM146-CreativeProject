using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockStateManager : MonoBehaviour
{

    RockState currentState;

    // used for player interactions
    PlayerState currentSubState;
    public GameObject hand;
    public GameObject food;
    public GameObject water;

    public float attention = 10f;
    public float hunger = 10f;
    public float thirst = 10f;
    public float moss = 10f;

    // Start is called before the first frame update
    void Start()
    {
        currentState = new RockHappy();
        currentState.EnterState(this);
        currentSubState = null;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        if (currentSubState != null) { currentSubState.UpdateState(this); }
    }

    public void SwitchState(RockState state) {
        currentState = state;
        state.EnterState(this);
    }

    public void SwitchSubstate(PlayerState state) {
        currentSubState = state;
        if (state != null) { state.EnterState(this); }
    }

    public void switchToFeedState() {
        if (currentSubState == null) { SwitchSubstate(new FeedRockState()); }
    }

    public void switchToWaterState() {
        if (currentSubState == null) { SwitchSubstate(new WaterRockState()); }
    }

    public void switchToPetState() {
        if (currentSubState == null) { SwitchSubstate(new PetRockState()); }
    }
}