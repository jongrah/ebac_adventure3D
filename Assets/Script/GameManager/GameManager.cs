using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Ebac.StateMachine;

public class GameManager : Singleton<GameManager>
{
    public enum GameStates
    {
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE
    }

    public StateMachine<GameStates> stateMachine;

    public void Start()
    {
        Init();
    }

    public void Init()
    {
        stateMachine = new StateMachine<GameStates>();
        stateMachine.Init();
        stateMachine.RegisterStates(GameStates.INTRO, new GMStateIntro());
        stateMachine.RegisterStates(GameStates.GAMEPLAY, new GMStateGameplay());
        stateMachine.RegisterStates(GameStates.PAUSE, new GMStatePause());
        stateMachine.RegisterStates(GameStates.WIN, new GMStateWin());
        stateMachine.RegisterStates(GameStates.LOSE, new GMStateLose());

        stateMachine.SwitchState(GameStates.INTRO); 
    }


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            stateMachine.SwitchState(GameStates.INTRO);
            Debug.Log("Intro");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            stateMachine.SwitchState(GameStates.GAMEPLAY);
            Debug.Log("Andar");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SwitchState(GameStates.PAUSE);
            Debug.Log("Pular");
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            stateMachine.SwitchState(GameStates.WIN);
            Debug.Log("Parar");
        }
        
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.SwitchState(GameStates.LOSE);
            Debug.Log("Correr");
        }

    }
}
