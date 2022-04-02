using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashOnDamageTaken : MonoBehaviour
{
    public float flashDuration;
    public Damagable damagable;
    public Material flashMaterial;
    public SpriteRenderer spriteRenderer;
    private Material storedSpriteMaterial;
    private bool isFlashing = false;

    private void Start()
    {
        damagable.OnDamageTaken.AddListener(() => StartCoroutine(FlashRoutine()));
        storedSpriteMaterial = spriteRenderer.material;
    }

    private IEnumerator FlashRoutine()
    {
        if (!isFlashing)
        {
            isFlashing = true;
            spriteRenderer.material = flashMaterial;
            yield return new WaitForSeconds(flashDuration);
            spriteRenderer.material = storedSpriteMaterial;
            isFlashing = false;
        }
    }

}
