using UnityEngine;
using UnityEngine.UI;

public class VSync : MonoBehaviour {
    public Toggle vSyncToggleCheck;

    private void Update()
    {
        if (vSyncToggleCheck.isOn)
        {
            QualitySettings.vSyncCount = 1;
        }
        else
        {
            QualitySettings.vSyncCount = 0;
        }
    }

}
