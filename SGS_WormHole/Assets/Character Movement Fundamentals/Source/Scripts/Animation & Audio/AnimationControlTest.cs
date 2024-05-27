using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationControlTest : MonoBehaviour
{
    public Action<bool> OnIdle;
    public Action<bool> OnRun;
    public Action<bool> OnFall;
    public Action<bool> OnSlide;
    public Action OnJump;
    public Action OnLandHard;
    public Action OnFight;
    public Action OnHeal;

    public readonly string idleName = "IsIdling";
    public readonly string runName = "IsRunning";
    public readonly string fallName = "IsFalling";
    public readonly string slideName = "IsSliding";
    public readonly string jumpName = "Jump";
    public readonly string landHardName = "LandHard";
    public readonly string fightName = "Fight";
    public readonly string healName = "Heal";

    public Animator Animator;
    
    void Start()
    {
        OnIdle += Idle;
        OnRun += Run;
        OnFall += Fall;
        OnSlide += Slide;
        OnJump += Jump;
        OnLandHard += LandHard;
        OnFight += Fight;
        OnHeal += Heal;

        Animator = GetComponentInChildren<Animator>();
    }

    private void Idle(bool isIdle)
    {
        Animator.SetBool(idleName, isIdle);
    }

    private void Run(bool isRunning)
    {
        Animator.SetBool(runName, isRunning);
    }
    
    private void Fall(bool isFalling)
    {
        Animator.SetBool(fallName, isFalling);
    }
        
    private void Slide(bool isSliding)
    {
        Animator.SetBool(slideName, isSliding);
    }

    private void Jump()
    {
        Animator.SetTrigger(jumpName);
    }

    private void LandHard()
    {
        Animator.SetTrigger(landHardName);
    }

    private void Fight()
    {
        Animator.SetTrigger(fightName);
    }

    private void Heal()
    {
        Animator.SetTrigger(healName);
    }
}
