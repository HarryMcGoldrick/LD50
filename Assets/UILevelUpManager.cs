using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILevelUpManager : MonoBehaviour
{
    public BaseGun[] guns; // Convert to upgrades
    public UIUpgrade[] uiUpgrades;

    private void Start()
    {
        for (int i = 0; i < uiUpgrades.Length; i++)
        {
            int index = i;
            uiUpgrades[i].confirmButton.onClick.AddListener(() => TriggerUpgrade(index));
        }

        PlayerUtils.Instance.GetPlayerExpManager().OnLevelUp.AddListener(DisplayUpgrades);
    }

    public void TriggerUpgrade(int index)
    {
        PlayerUtils.Instance.GetWeaponInventory().EquipWeapon(uiUpgrades[index].gun);
        UIStateManager.Instance.SwitchState(UIState.HUD);
    }

    public void DisplayUpgrades()
    {
        UIStateManager.Instance.SwitchState(UIState.LEVELUP_MENU);

        BaseGun[] gunsChosen = new BaseGun[uiUpgrades.Length];

        for (int i = 0; i < uiUpgrades.Length; i++)
        {
            if (i != 0) 
            {
                gunsChosen[i] = BruteForceGetNonDuplicateUpgrade(gunsChosen);
            } else
            {
                gunsChosen[i] = guns[Random.Range(0, guns.Length)];
            }

            uiUpgrades[i].gun = gunsChosen[i];

            UpdateUIUpgradeDisplay(uiUpgrades[i]);
        }
    }

    private void UpdateUIUpgradeDisplay(UIUpgrade upgrade)
    {
        upgrade.titleText.text = upgrade.gun.displayName;
        upgrade.descriptionText.text = upgrade.gun.displayDescription;
        upgrade.iconImage.sprite = upgrade.gun.sprite;
    }

    private BaseGun BruteForceGetNonDuplicateUpgrade(BaseGun[] chosenGuns)
    {
        BaseGun gun = guns[Random.Range(0, guns.Length)];
        while (IsGunInArray(chosenGuns, gun))
        {
            gun = guns[Random.Range(0, guns.Length)];
        }
        return gun;
    }

    private bool IsGunInArray(BaseGun[] chosenGuns, BaseGun gun)
    {
        for (int i = 0; i < chosenGuns.Length; i++)
        {
            if (chosenGuns[i] == null)
                return false;
            if (chosenGuns[i].displayName == gun.displayName)
                return true;
        }
        return false;
    }
}

[System.Serializable]
public struct UIUpgrade 
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;
    public Image iconImage;
    public Button confirmButton;
    public BaseGun gun;
}

