using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseUtils : Singleton<MouseUtils>
{
    private Camera playerCamera;

    public Vector2 GetMouseWorldPosition()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;
        return playerCamera.ScreenToWorldPoint(Input.mousePosition);
    }
}
