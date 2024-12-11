using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Updater : MonoBehaviour
{
    public Slider updateProgress;
    private string NewVersionNumber = "2020a_07";
    private string githubUrl = "https://api.github.com/repos/KorbynTalks/Pixel-Platformer/tags";

    private void Start()
    {
        InvokeRepeating("Check", 0.5f, 10);
    }

    private void Check()
    {
        string ReturnedText;
        WWW GetGithubTags = new WWW(githubUrl);
        if (GetGithubTags.isDone)
        {
            ReturnedText = GetGithubTags.text;
            string[] ReturnedTextSplit = ReturnedText.Split(",");
            bool DoesContainNewVersion = ReturnedTextSplit[13].Contains(NewVersionNumber);

            Debug.Log("Got tags. Amount: " + ReturnedTextSplit.Length);

            if(DoesContainNewVersion)
            {

            } else
            {
                
            }
        }
    }
}
