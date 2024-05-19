using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateAnimation3 : MonoBehaviour
{

    public Animator Animator;
    public Collider2D AnimationCollider;
    public Collider2D PlayerCollider;

    // Update is called once per frame
    void Update()
    {
        if (AnimationCollider.IsTouching(PlayerCollider)) {
            Animator.SetInteger("IsNear3", 1);
        }
    }
}
