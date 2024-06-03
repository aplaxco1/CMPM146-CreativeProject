using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class RockDialouge : MonoBehaviour
{
    public RockStateManager RockStateManager; // used to obtain values of rock

    // Reference to the TextMeshProUGUI component
    public TextMeshProUGUI uiText;

    void Start()
    {
        // Initial text
        uiText.text = "I'm content";
    }

    void Update()
    {
        // Example of changing the text when a condition is met (e.g., pressing a key)
        //if (StatsManager.isHungry == true)
        //{
        //    uiText.text = "I'm hungry!";
        //}
    }

    // Public method to change text, can be called from other scripts or UI elements
    public void ChangeText(string newText)
    {
        uiText.text = newText;
    }
}
