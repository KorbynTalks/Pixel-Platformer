using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public string WhatsThisObject = "";

    void OnTriggerEnter2D(Collider2D other)
    {
            gameObject.SetActive(false);
    }
}