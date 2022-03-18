﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    private StateMachine stateMachine;
    private PauseState pauseState;
    private UnpauseState unpauseState;
    private bool isGamePaused;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (!isGamePaused)
            {
                PauseGame();
            }
            else
            {
                UnpauseGame();
            }
        }
    }

    public void PauseGame()
    {
        stateMachine.ChangeState(pauseState);
        isGamePaused = true;
    }

    public void UnpauseGame()
    {
        stateMachine.ChangeState(unpauseState);
        isGamePaused = false;
    }

    private void Awake()
    {
        stateMachine = new StateMachine();
        pauseState = new PauseState(isGamePaused);
        unpauseState = new UnpauseState(isGamePaused);
    }
    
    
}
