using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlTest : MonoBehaviour
{
    public Action<bool> OnIdle;
    public Action<bool> OnRun;
    public Action OnJump;
    public Action OnFall;
    public Action OnHardLand;
    public Action OnFight;
    public Action OnHeal;
    public Action OnSlide;

    public readonly string runName = "Run";
    public readonly string idleName = "Idle";
    public readonly string jumpName = "Jump";

    public Animator Animator;

    [Header("Test")]

    public bool isRunning;

    // Start is called before the first frame update
    void Start()
    {
        OnRun += Run;
        OnIdle += Idle;
        OnJump += Jump;

        Animator = GetComponentInChildren<Animator>();
    }

    private void Run(bool isRunning)
    {
        Animator.SetBool(runName, isRunning);
    }

    private void Idle(bool isIdle)
    {
        Animator.SetBool(idleName, isIdle);
    }

    private void Jump()
    {
        Animator.SetTrigger(jumpName);
    }
}
