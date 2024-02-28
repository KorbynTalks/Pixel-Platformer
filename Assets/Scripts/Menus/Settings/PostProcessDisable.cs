using UnityEngine.Rendering.PostProcessing; // gives us script stuff for post processing
using UnityEngine; // base engine script stuff
using UnityEngine.UI; // ui script stuff

public class PostProcessDisable : MonoBehaviour
{
    [SerializeField] private PostProcessProfile postProcessProfile;
    private bool isEnabled = true;

    void Start()
    {
        SetPostProcessingProfileEnabled(isEnabled);
    }

    public void TogglePostProcessing()
    {
        isEnabled = !isEnabled;
        SetPostProcessingProfileEnabled(isEnabled);
    }

    private void SetPostProcessingProfileEnabled(bool isEnabled)
    {
        if (postProcessProfile == null) return;

        foreach (var item in postProcessProfile.settings)
        {
            item.enabled.value = isEnabled;
        }
    }
}