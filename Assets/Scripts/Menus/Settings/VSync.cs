using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VSync : MonoBehaviour {

    public static int vSyncCount;
    [SerializeField] private Slider fpsSlider;
    public static int targetFrameRate;

    public void VSyncToggle(string sceneName) {
        QualitySettings.vSyncCount = vSyncCount;
    }

    private void Start()
    {
        fpsSlider.value += targetFrameRate;
        Application.targetFrameRate = targetFrameRate;
    }

    
}
