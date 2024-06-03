using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using TMPro;

public class RockStateManager : MonoBehaviour
{
    public StatsManager StatsManager; // used to obtain values from the sliders

    [Header("Current Rock States")]
    public RockState currentState;
    public PlayerState currentSubState;
    public TMP_Text stateText;
    public TextMeshProUGUI dialougeText;

    [Header("Interaction Animations")]
    // used for player interactions
    public GameObject hand;
    public GameObject food;
    public GameObject water;
    public GameObject scissors;

    [Header("Stat Values")]    
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

    public void getHighestStat() {
        if (attention <= hunger && attention <= thirst && attention <= moss && !(currentState is RockBored)) {
            SwitchState(new RockBored());
        }
        else if (hunger <= attention && hunger <= thirst && hunger <= moss && !(currentState is RockHungry)) {
            SwitchState(new RockHungry());
        }
        else if (thirst <= attention && thirst <= hunger && thirst <= moss && !(currentState is RockThirsty)) {
            SwitchState(new RockThirsty());
        }
        else {
            SwitchState(new RockMossy());
        }
    }
}