using UnityEngine;
using UnityEngine.UI;

public class CheckboxManager3 : MonoBehaviour
{
    public Toggle checkbox;

    private void Start()
    {
        // Load the state of the checkbox from PlayerPrefs.
        checkbox.isOn = PlayerPrefs.GetInt("CheckboxState4", 0) == 1;

        // Set the callback function for the checkbox to save the state to PlayerPrefs.
        checkbox.onValueChanged.AddListener(SaveCheckboxState);
    }

    private void SaveCheckboxState(bool state)
    {
        // Save the state of the checkbox to PlayerPrefs.
        int stateValue = state ? 1 : 0;
        PlayerPrefs.SetInt("CheckboxState4", stateValue);
        PlayerPrefs.Save();
    }
}