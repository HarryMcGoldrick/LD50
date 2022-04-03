using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIDeathScreen : Singleton<UIDeathScreen>
{
    public Button replayButton;
    public Button exitButton;

    private void Start()
    {
        replayButton.onClick.AddListener(ReplayLevel);
        exitButton.onClick.AddListener(() => UIStateManager.Instance.SwitchState(UIState.MAIN_MENU));
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
