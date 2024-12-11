using UnityEngine;
using System.Collections;

public class DevMode : MonoBehaviour
{
    public GameObject devFeatures;

    private void Update()
    {
        if (Input.GetKeyDown("space") && Input.GetKeyDown("c")) {
            devFeatures.SetActive(true);
        }
    }



}