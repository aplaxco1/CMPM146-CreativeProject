using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsManager : MonoBehaviour
{
    public Slider happinessSlider;
    public Slider hungerSlider;
    public Slider thirstSlider;
    public Slider attentionSlider;

    private float rate = 20f;
    private float rateOfDecay;
    private float rateOfGrowth;
    private bool isHungry = false;
    private float decreaseInterval = 5f; //144 shld decrease to 0 over 2 hours //1800f; // 30 minutes in seconds

    void Start()
    {
        rateOfDecay = rate;
        rateOfGrowth = rate;
        happinessSlider.value = 200;
        hungerSlider.value = 100;
        thirstSlider.value = 100;
        attentionSlider.value = 100;

        StartCoroutine(DecreaseStats());
    }

    IEnumerator DecreaseStats()
    {
        while (true)
        {
            yield return new WaitForSeconds(decreaseInterval);

            DecreaseValue(happinessSlider);
            DecreaseValue(hungerSlider);
            DecreaseThirst();
            DecreaseValue(attentionSlider);
            checkHunger();
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

    void IncreaseValue(Slider slider)
    {
        // if the rock is bored, there is a 50% chance the action does nothing
        if (checkBored()) { 
            if (Random.value < 0.5f) {
                Debug.Log("rock is not paying attention");
                return;
            }
        }

        if (slider.value < slider.maxValue)
        {
            slider.value += rateOfGrowth;
        }
    }

    void checkHunger() {
        if (hungerSlider.value < thirstSlider.value && hungerSlider.value < attentionSlider.value && isHungry==false) {
                isHungry = true;
                rateOfDecay *= 1.5f;
                Debug.Log("rate of decay increased");
        } else if (hungerSlider.value >= thirstSlider.value && hungerSlider.value >= attentionSlider.value) {
                isHungry = false;
                rateOfDecay = rate;
        }
    }

    bool checkBored() {
        if (attentionSlider.value < thirstSlider.value && attentionSlider.value < hungerSlider.value) {
            Debug.Log("rock is bored");
            return true;
        }
        return false;
    }
}
