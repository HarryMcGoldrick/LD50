using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;

    private void Start()
    {
        playButton.onClick.AddListener(HandlePlayButton);
        exitButton.onClick.AddListener(HandleExitButton);
    }

    private void HandlePlayButton()
    {
        UIStateManager.Instance.SwitchState(UIState.HUD);
    }

    private void HandleExitButton()
    {
        Application.Quit();
    }
}
