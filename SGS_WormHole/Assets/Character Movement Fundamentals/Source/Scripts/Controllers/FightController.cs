using CMF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    public bool IsFighting { get; private set; }

    protected CharacterInput characterInput;
    protected AnimationControlTest animatorController;

    private void Awake()
    {
        characterInput = GetComponent<CharacterInput>();
        animatorController = GetComponent<AnimationControlTest>();
    }

    void Update()
    {
        IsFighting = animatorController.GetFightAnimState();

        if (characterInput.IsFightKeyPressed() == true && IsFighting == false)
        {
            animatorController.OnFight?.Invoke();
        }
    }
}
