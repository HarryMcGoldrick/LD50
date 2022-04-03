using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILevelbar : Singleton<UILevelbar>
{
    public Image barFill;
    public TextMeshProUGUI levelText;

    private PlayerExpManager expManager;
    private void Start()
    {
        expManager = PlayerUtils.Instance.GetPlayerExpManager();
        expManager.OnExpAdd.AddListener(UpdateExpBar);
        barFill.fillAmount = 0;
    }

    public void UpdateExpBar()
    {
        float percentageFill = expManager.currentExp / expManager.GetRequiredExpForNextLevel();
        barFill.fillAmount = percentageFill;

        levelText.text = $"Lv {expManager.currentLevel}";
    }

}
