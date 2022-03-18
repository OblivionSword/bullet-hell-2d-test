using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : IState
{
    private bool playerWin;

    public WinState(bool playerWin)
    {
        this.playerWin = playerWin;
    }
    
    public void Enter()
    {
        playerWin = true;
        Time.timeScale = 0f;
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}
