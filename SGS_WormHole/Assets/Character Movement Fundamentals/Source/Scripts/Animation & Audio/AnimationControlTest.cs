using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlTest : MonoBehaviour
{
    public bool isWalkTriggered;
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalkTriggered == true)
        {
            Animator.SetBool("Walk", true);
            Animator.SetBool("Idle", false);
        }
        else
        {
            Animator.SetBool("Idle", true);
            Animator.SetBool("Walk", false);
        }
    }
}
