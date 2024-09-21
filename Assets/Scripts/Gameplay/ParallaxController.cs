using UnityEngine;
using System.Collections;

public class ParallaxController : MonoBehaviour
{
    public GameObject[] parallaxObjs;
    public Transform playerTransform;

    private void Start()
    {
        
    }

    private void Update()
    {
        GameObject firstParallax = parallaxObjs[0];
        GameObject secondParallax = parallaxObjs[1];

        
    }
}