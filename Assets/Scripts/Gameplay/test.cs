// Code created by Kao#1232
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    [Range(0f, 10f)]
    public float waitTime = 3f;

    [Range(0f, 10f)]
    public float timeSlower = 2.0f;

    private float fixedDeltaTime;

    void Awake()
    {
        this.fixedDeltaTime = Time.fixedDeltaTime;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Time.timeScale = timeSlower;
            Debug.Log(Time.timeScale);

            StartCoroutine(WaitForSecondsAndResume(waitTime));
        }
    }

    IEnumerator WaitForSecondsAndResume(float seconds)
    {
        yield return new WaitForSecondsRealtime(seconds);
        Time.timeScale = 1f;
        Debug.Log(Time.timeScale);
    }
}
