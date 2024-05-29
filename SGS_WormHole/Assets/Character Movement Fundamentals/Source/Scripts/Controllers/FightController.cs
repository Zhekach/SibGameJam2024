using CMF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{
    protected CharacterInput characterInput;
    protected AnimationControlTest animatorController;

    public bool IsFighting { get; private set; }

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
