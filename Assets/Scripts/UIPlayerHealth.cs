using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealth : MonoBehaviour
{
    public Color maxHealthColor;
    public Color minHealthColor;
    public Image healthbarFill;

    private Damagable playerDamagable;

    private void Start()
    {
        playerDamagable = PlayerUtils.Instance.GetPlayerGameObject().GetComponent<Damagable>();
        playerDamagable.OnDamageTaken.AddListener(() => UpdateHealthDisplay(playerDamagable.currentHealth, playerDamagable.maxHealth));
        UpdateHealthDisplay(playerDamagable.currentHealth, playerDamagable.maxHealth);
    }

    public void UpdateHealthDisplay(float currentHealth, float maxHealth)
    {
        float percentageFill = currentHealth / maxHealth;
        healthbarFill.color = GetColorForFillValue(percentageFill);
        healthbarFill.fillAmount = percentageFill;
    }

    public Color GetColorForFillValue(float fillValue)
    {
        return Color.Lerp(minHealthColor, maxHealthColor, fillValue);
    }

}
