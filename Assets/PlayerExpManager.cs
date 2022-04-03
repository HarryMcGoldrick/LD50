using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerExpManager : MonoBehaviour
{
    public int currentLevel = 0;
    public float currentExp = 0;
    public UnityEvent OnExpAdd = new UnityEvent();
    public AudioClips levelupSound;

    public void AddExp(int exp)
    {
        currentExp += exp;
        if (currentExp >= GetRequiredExpForNextLevel())
        {
            LevelUp();
        }

        OnExpAdd.Invoke();
    }

    public void LevelUp()
    {
        currentExp -= GetRequiredExpForNextLevel();
        currentLevel++;
        AudioManager.Instance.PlayLocalOneShot(levelupSound);
        GetComponent<Damagable>().FullHeal(); 
    }

    public int GetRequiredExpForNextLevel()
    {
        float exponent = 2 * 2;
        float scale = 5f;
        return (int)((currentLevel + 1)  * exponent * scale);
    }
}
