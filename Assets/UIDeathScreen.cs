using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIDeathScreen : Singleton<UIDeathScreen>
{
    public GameObject screenPanel;
    public Button replayButton;
    public Button exitButton;

    private void Start()
    {
        replayButton.onClick.AddListener(ReplayLevel);
        //replayButton.exitButton.AddListener(ReplayLevel);
    }

    public void EnableDeathScreen()
    {
        this.screenPanel.SetActive(true);
    } 

    public void DisableDeathScreen()
    {
        this.screenPanel.SetActive(false);
    }

    public void ReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
}
