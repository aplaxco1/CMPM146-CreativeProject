using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatsManager : MonoBehaviour
{
    public Slider happinessSlider;
    public Slider hungerSlider;
    public Slider thirstSlider;
    public Slider attentionSlider;

    private float decreaseInterval = 5f; //144 shld decrease to 0 over 2 hours //1800f; // 30 minutes in seconds

    void Start()
    {
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
            DecreaseValue(thirstSlider);
            DecreaseValue(attentionSlider);
        }
    }

    void DecreaseValue(Slider slider)
    {
        if (slider.value > 0)
        {
            slider.value -= 1;
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
        if (slider.value < slider.maxValue)
        {
            slider.value += 1;
        }
    }
}
