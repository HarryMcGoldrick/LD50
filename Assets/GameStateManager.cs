using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : Singleton<GameStateManager>
{
    public GameState currentState;

    private void Start()
    {
        SwitchState(currentState);
    }

    public void SwitchState(GameState state)
    {
        this.currentState = state;
        HandleStateChange();
    }

    private void HandleStateChange()
    {
        if (currentState == GameState.FREEZE)
        {
            FreezeState();
        } else if (currentState == GameState.PLAYING)
        {
            PlayingState();
        }
    }

    private void FreezeState()
    {
        Time.timeScale = 0;
    }

    private void PlayingState()
    {
        Time.timeScale = 1;
    }
}

public enum GameState
{
    PLAYING,
    FREEZE,
}
