using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnpauseState : IState
{

    private bool isGamePaused;

    public UnpauseState(bool isGamePaused)
    {
        this.isGamePaused = isGamePaused;
    }

    public void Enter()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
