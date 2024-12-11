using UnityEngine;
using UnityEngine.UI;

public class CheckboxManager4 : MonoBehaviour
{
    public Slider slider;

    private void Start()
    {
        // Load the state of the checkbox from PlayerPrefs.
        slider.value = PlayerPrefs.GetFloat("SliderState1", 50);

        // Set the callback function for the checkbox to save the state to PlayerPrefs.
        slider.onValueChanged.AddListener(SaveCheckboxState);
    }

    private void SaveCheckboxState(float state)
    {
        // Save the state of the checkbox to PlayerPrefs.
        PlayerPrefs.SetFloat("SliderState1", state);
        PlayerPrefs.Save();
    }
}