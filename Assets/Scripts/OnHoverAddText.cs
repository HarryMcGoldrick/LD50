using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHoverAddText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool leftSide = true;
    public TextMeshProUGUI baseText;
    public string additionalText;

    private string startingText;

    private void Start()
    {
        startingText = baseText.text;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (leftSide)
        {
            this.baseText.text = additionalText + startingText;
        } else
        {
            this.baseText.text = startingText + additionalText;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.baseText.text = startingText;
    }
}
