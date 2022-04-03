using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookHandler : MonoBehaviour
{
    [Header("Camera movement")]
    public float cameraDist;
    public float cameraSmooth;
    private Camera playerCamera;

    [Header("Rotation")]
    public Transform rotatingTransform;

    private Vector3 currentDampingVelocity;


    void Start()
    {
        playerCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameStateManager.Instance.currentState == GameState.FREEZE)
            return;

        UpdateWeaponRotation();
        UpdateCameraPosition();
    }

    private void UpdateWeaponRotation()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - rotatingTransform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        rotatingTransform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        if (rotationZ < -90 || rotationZ > 90)
        {
            if (this.transform.eulerAngles.y == 0)
            {
                rotatingTransform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (this.transform.eulerAngles.y == 180)
            {
                rotatingTransform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }
    }

    private Vector3 GetCameraTargetOffset(float distance)
    {
        Vector3 mouseOffset = GetMouseScreenPos() * distance; //mult mouse vector by distance scalar 
        Vector3 ret = this.transform.position + mouseOffset; //find position as it relates to the player
        //ret += shakeOffset; //add the screen shake vector to the target
        ret.z = -10; //make sure camera stays at same Z coord
        return ret;
    }

    void UpdateCameraPosition()
    {
        playerCamera.transform.position = Vector3.SmoothDamp(playerCamera.transform.position, GetCameraTargetOffset(cameraDist), ref currentDampingVelocity, cameraSmooth); //smoothly move towards the target
    }

    private Vector3 GetMouseWorldPosition()
    {
        return playerCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector3 GetMouseScreenPos()
    {
        Vector2 ret = Camera.main.ScreenToViewportPoint(Input.mousePosition); //raw mouse pos
        ret *= 2;
        ret -= Vector2.one; //set (0,0) of mouse to middle of screen
        float max = 0.9f;
        if (Mathf.Abs(ret.x) > max || Mathf.Abs(ret.y) > max)
        {
            ret = ret.normalized; //helps smooth near edges of screen
        }
        return ret;
    }
}
