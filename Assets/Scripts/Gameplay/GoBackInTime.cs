using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoBackInTime : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inputBox.text == "02152023")
        {
            SceneManager.LoadScene("LevelOld");
        }
    }
}
