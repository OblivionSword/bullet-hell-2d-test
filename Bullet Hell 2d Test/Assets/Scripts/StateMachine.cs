using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public IState currentState { get; private set; }
    public IState previousState { get; private set; }

    public void Initialize(IState startingState)
    {
        currentState = startingState;
        startingState.Enter();
    }

    public void ChangeState(IState newState)
    {
        currentState?.Exit();
        previousState = currentState;
        currentState = newState;
        currentState.Enter();
    }

    public IState GetCurrentState()
    {
        return currentState;
    }

    
    void Update()
    {
        currentState?.Execute();
    }

    public void SwitchToPreviousState()
    {
        currentState.Exit();
        currentState = previousState;
        currentState.Enter();
    }
    
}
