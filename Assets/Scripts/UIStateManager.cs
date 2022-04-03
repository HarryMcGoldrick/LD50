using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStateManager : Singleton<UIStateManager>
{
    [SerializeField]
    public KeyValuePairSerialized<UIState, GameObject[]>[] uiStates;

    public UIState currentState;

    private void Start()
    {
        Cursor.visible = false;
        SwitchState(currentState);
    }

    private void Update()
    {
        HandleUIMenuControls();
    }

    public void SwitchState(UIState state)
    {
        currentState = state;
        if (currentState == UIState.HUD)
        {
            GameStateManager.Instance.SwitchState(GameState.PLAYING);
            Cursor.visible = false;
        }
        else
        {
            GameStateManager.Instance.SwitchState(GameState.FREEZE);
            Cursor.visible = true;
        }

        SetAllWindowsActive(false);
        SetWindowsActive(state, true);
    }

    public void ToggleState(UIState state)
    {
        if (currentState == state)
        {
            SwitchState(UIState.HUD);
        } else
        {
            SwitchState(state);
        }
    }

    private void SetAllWindowsActive(bool active)
    {
        for (int i = 0; i < uiStates.Length; i++)
        {
            GameObject[] windows = uiStates[i].Value;
            for (int j = 0; j < windows.Length; j++)
            {
                windows[j].SetActive(active);
            }
        }
    }

    private void SetWindowsActive(UIState state, bool active)
    {
        for (int i = 0; i < uiStates.Length; i++)
        {
            if (state != uiStates[i].Key)
                continue;

            GameObject[] windows = uiStates[i].Value;
            for (int j = 0; j < windows.Length; j++)
            {
                windows[j].SetActive(active);
            }
        }
    }

    public void HandleUIMenuControls()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleState(UIState.PAUSE_MENU);
        }
    }
}

public enum UIState
{
    MAIN_MENU,
    HUD,
    PAUSE_MENU,
    DEATH,
    LEVELUP_MENU,
}
