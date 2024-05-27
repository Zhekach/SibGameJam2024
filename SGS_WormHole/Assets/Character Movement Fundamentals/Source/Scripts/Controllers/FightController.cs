using CMF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightController : MonoBehaviour
{

    protected CharacterInput characterInput;
    protected AnimationControlTest animatorController;

    private void Awake()
    {
        characterInput = GetComponent<CharacterInput>();
        animatorController = GetComponent<AnimationControlTest>();
    }

    void Update()
    {
        if (characterInput != null && characterInput.IsFightKeyPressed() == true)
        {
            animatorController.OnFight?.Invoke();
        }
    }
}
