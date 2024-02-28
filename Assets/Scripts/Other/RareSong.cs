using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RareSong : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioSource audioSource2;
    
    // Start is called before the first frame update
    void Start()
    {
        int chance = Random.Range(1, 1000);
switch (chance)
{
case 1000:
// insert code that plays the rare credits here
audioSource2.Play();
break;
default:
// insert code that plays common credits here
audioSource.Play();
break;
}
    }
}