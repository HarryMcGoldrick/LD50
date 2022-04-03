using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuManager : MonoBehaviour
{
    public Button SfxButton;
    public Image SfxImage;
    public Sprite SfxEnabled;
    public Sprite SfxDisabled;

    private bool sfxOnState = true;

    private void Start()
    {
        SfxButton.onClick.AddListener(ToggleSfxButton);
    }

    public void ToggleSfxButton()
    {
        this.sfxOnState = !this.sfxOnState;
        HandleSfxState();
    }

    public void HandleSfxState()
    {
        AudioManager.Instance.MuteAudio(!sfxOnState);
        if (sfxOnState)
        {
            SfxImage.sprite = SfxEnabled;
        } else
        {
            SfxImage.sprite = SfxDisabled;
        }
    }
}
