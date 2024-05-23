using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockStateManager : MonoBehaviour
{

    RockState currentState;

    // used for player interactions
    PlayerState currentSubState;
    public GameObject hand; // used for the lil pet animation

    public float attention = 10f;
    public float hunger = 10f;
    public float thirst = 10f;
    public float moss = 10f;

    // Start is called before the first frame update
    void Start()
    {
        hand = GameObject.Find("Hand");
        hand.SetActive(false);

        currentState = new RockHappy();
        currentState.EnterState(this);
        currentSubState = null;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this);
        if (currentSubState != null) {currentSubState.UpdateState(this); }
    }

    public void SwitchState(RockState state) {
        currentState = state;
        state.EnterState(this);
    }

    public void SwitchSubstate(PlayerState state) {
        currentSubState = state;
        state.EnterState(this);
    }

    void OnMouseDown() {
        //SwitchState(new RockHappy());
        if (currentSubState == null) {
            SwitchSubstate(new PetRockState());
        }
    }
}