using UnityEngine;
using System.Collections;

public class bgChanger : MonoBehaviour
{
    public Color color1 = Color.red;
    public Color color2 = Color.blue;
    public Color color3 = Color.green;
    public float duration = 3.0F;
    public Camera MainCamera;


    private void Start()
    {
        MainCamera = GetComponent<Camera>();
        MainCamera.clearFlags = CameraClearFlags.SolidColor;
    }

    private void Update()
    {
        float t = Mathf.PingPong(Time.time, duration) / duration;
        MainCamera.backgroundColor = Color.Lerp(color1, color2, t);
        MainCamera.backgroundColor = color3;
    }


}