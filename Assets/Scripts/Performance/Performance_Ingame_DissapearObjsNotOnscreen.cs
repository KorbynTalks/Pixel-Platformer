using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Performance_Ingame_DissapearObjsNotOnscreen : MonoBehaviour // All of this is WIP! Look around what ive done so far for now.
{
    public Camera gameCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Get the Camera Component from gameCamera
        gameCamera = GetComponent<Camera>();

        // Culling Group stuff
        CullingGroup group = new CullingGroup();
        group.targetCamera = Camera.main;
        BoundingSphere[] spheres = new BoundingSphere[1000];
        spheres[0] = new BoundingSphere(Vector3.zero, 1f);
        group.SetBoundingSpheres(spheres);
        group.SetBoundingSphereCount(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
