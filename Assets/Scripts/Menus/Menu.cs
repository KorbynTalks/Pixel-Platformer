using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {

    public AudioSource[] audios;
    private Slider slider;
    [SerializeField] private Animator fadeAnimator;

    public void GoToScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }

    public void QuitApp() {
        Application.Quit();
        Debug.Log("Application has quit.");
    }

    public void PlayRandomSound()
    {
        audios[Random.Range(0, audios.Length)].Play();
    }

    public void SoundSlider()
    {
        slider = GetComponentInChildren<Slider>();
        AudioListener.volume = slider.value;
    }
}
