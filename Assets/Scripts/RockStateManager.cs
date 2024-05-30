using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class RockStateManager : MonoBehaviour
{
    public StatsManager StatsManager; // used to obtain values from the sliders
    RockState currentState;

    // used for player interactions
    PlayerState currentSubState;
    public GameObject hand;
    public GameObject food;
    public GameObject water;
    public GameObject scissors;

    public float attention;
    public float hunger;
    public float thirst;
    public float moss;

    // Start is called before the first frame update
    void Start()
    {
        currentState = new RockNeutral();
        currentState.EnterState(this);
        currentSubState = null;
        
        updateStatsFromSliders();
    }

    // Update is called once per frame
    void Update()
    {
        updateStatsFromSliders();
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

    public void switchToGroomState() {
        if (currentSubState == null) { SwitchSubstate(new GroomRockState()); }
    }

    public void switchToPetState() {
        if (currentSubState == null) { SwitchSubstate(new PetRockState()); }
    }

    public void updateStatsFromSliders() {
        attention = StatsManager.attentionSlider.value;
        hunger = StatsManager.hungerSlider.value;
        thirst = StatsManager.thirstSlider.value;
        moss = StatsManager.hygieneSlider.value;
    }
}