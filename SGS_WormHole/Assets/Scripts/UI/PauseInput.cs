using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseInput : MonoBehaviour
{
    [SerializeField] private KeyCode _pauseKey = KeyCode.Escape;
    [SerializeField] private Menu _pauseMenu;

    private bool _paused = false;

    private void Update()
    {
        if (Input.GetKeyDown(_pauseKey) && _paused == false)
        {
            _pauseMenu.Activate();
            //_paused = true;
        }
        else if(Input.GetKeyDown(_pauseKey) && _paused == true)
        {
            _pauseMenu.Deactivate();
            //_paused = false;
        }
    }
}
