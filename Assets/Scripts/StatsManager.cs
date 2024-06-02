using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsManager : MonoBehaviour
{
    public Slider happinessSlider;
    public Slider hungerSlider;
    public Slider thirstSlider;
    public Slider attentionSlider;
    public Slider hygieneSlider;

    public float rate = 5f;
    public float rateOfDecay;
    private float rateOfGrowth = 20f;
    //private bool isHungry = false;
    private float decreaseInterval = 5f; //144 shld decrease to 0 over 2 hours //1800f; // 30 minutes in seconds

    void Start()
    {
        rateOfDecay = rate;
        
        hungerSlider.value = 100;
        thirstSlider.value = 100;
        attentionSlider.value = 100;
        hygieneSlider.value = 100;

        happinessSlider.value = calculateHappiness();

        StartCoroutine(DecreaseStats());
    }

    IEnumerator DecreaseStats()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseInterval);
            DecreaseValue(hungerSlider);
            DecreaseThirst();
            DecreaseValue(attentionSlider);
            DecreaseValue(hygieneSlider);
            //checkHunger();

            happinessSlider.value = calculateHappiness();
        }
    }

    void DecreaseValue(Slider slider)
    {
        if (slider.value > 0)
        {
            slider.value -= rateOfDecay;
        }
    }

    void DecreaseThirst() {
        if (thirstSlider.value > 0)
        {
            thirstSlider.value -= rateOfDecay*1.5f;
        }
    }

    public void DecreaseHygiene() {
        DecreaseValue(hygieneSlider);
    }

    public void IncreaseHappiness()
    {
        IncreaseValue(happinessSlider);
    }

    public void IncreaseHunger()
    {
        IncreaseValue(hungerSlider);
    }

    public void IncreaseThirst()
    {
        IncreaseValue(thirstSlider);
    }

    public void IncreaseAttention()
    {
        IncreaseValue(attentionSlider);
    }

    public void IncreaseHygiene()
    {
        IncreaseValue(hygieneSlider);
    }

    void IncreaseValue(Slider slider)
    {
        // // if the rock is bored, there is a 50% chance the action does nothing
        // if (checkBored()) { 
        //     if (Random.value < 0.5f) {
        //         Debug.Log("rock is not paying attention");
        //         return;
        //     }
        // }

        if (slider.value < slider.maxValue)
        {
            slider.value += rateOfGrowth;
        }
    }

    // void checkHunger() {
    //     if (hungerSlider.value < thirstSlider.value && hungerSlider.value < attentionSlider.value && hungerSlider.value < hygieneSlider.value && isHungry==false) {
    //             isHungry = true;
    //             rateOfDecay *= 1.5f;
    //             Debug.Log("rate of decay increased");
    //     } else if (hungerSlider.value >= thirstSlider.value && hungerSlider.value >= attentionSlider.value && hungerSlider.value >= hygieneSlider.value) {
    //             isHungry = false;
    //             rateOfDecay = rate;
    //     }
    // }

    // bool checkBored() {
    //     if (attentionSlider.value < thirstSlider.value && attentionSlider.value < hungerSlider.value && attentionSlider.value < hygieneSlider.value) {
    //         Debug.Log("rock is bored");
    //         return true;
    //     }
    //     return false;
    // }

    float calculateHappiness() {
        float average = hungerSlider.value + thirstSlider.value + attentionSlider.value + hygieneSlider.value;
        return average/4;
    }
}
