using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseState : IState
{
    private bool isGamePaused;

    public PauseState(bool isGamePaused)
    {
        this.isGamePaused = isGamePaused;
    }
    
    public void Enter()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
