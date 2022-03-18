using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject victoryScreen;
    [SerializeField] private GameObject loseScreen;
    
    private StateMachine stateMachine;
    private WinState winState;
    private LoseState loseState;

    private bool playerWin;
    private bool playerLose;

    private void Awake()
    {
        stateMachine = new StateMachine();
        winState = new WinState(playerWin);
        loseState = new LoseState(playerLose);
    }

    
    void Start()
    {
        playerWin = false;
        playerLose = false;
    }

    private void Update()
    {
        if (!enemy.activeSelf)
        {
            Win();
        }

        if (!player.activeSelf)
        {
            Lose();
        }
    }

    public void Win()
    {
        stateMachine.ChangeState(winState);
        victoryScreen.SetActive(true);
    }

    public void Lose()
    {
        stateMachine.ChangeState(loseState);
        loseScreen.SetActive(true);
    }
    
}
