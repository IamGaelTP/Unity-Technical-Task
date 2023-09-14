using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum eGameStates
{
    STARTUP,
    HOME,
    GAME
}

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager INSTANCE { get { return instance; } }

    public bool isGamePaused { get; private set; }
    public  bool isOnTutorial { get; private set; }
    public eGameStates currentGameState { get; private set; }


    private void Awake()
    {
        if(instance != null && instance != this)
        {
            this.gameObject.DestroyObject();
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void SetNewGameState(eGameStates newState)
    {
        EndCurrentStatateBehaviour();
        currentGameState = newState;
        StartCurrentStatateBehaviour();
    }

    private void StartCurrentStatateBehaviour()
    {
        switch (currentGameState)
        {
            case eGameStates.STARTUP:
                break;
            case eGameStates.HOME:
                break;
            case eGameStates.GAME:
                break;
        }
    }

    private void EndCurrentStatateBehaviour()
    {
        switch (currentGameState)
        {
            case eGameStates.STARTUP:
                break;
            case eGameStates.HOME:
                break;
            case eGameStates.GAME:
                break;
        }
    }

    public void PauseGame(bool wantToPause)
    {
        isGamePaused = wantToPause;
        Time.timeScale = isGamePaused ? 0 : 1;
    }

}
