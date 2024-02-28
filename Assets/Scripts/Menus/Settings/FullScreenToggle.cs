using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenToggle : MonoBehaviour
{

    public void Fullscene(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;

        Debug.Log("Fullscreen is " + isfullscreen);
    }

}
