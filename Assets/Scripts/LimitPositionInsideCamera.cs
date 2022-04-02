using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPositionInsideCamera : MonoBehaviour
{
    void Update()
    {
        Vector3 minScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, minScreenBounds.x + 1, maxScreenBounds.x - 1), 
            Mathf.Clamp(transform.position.y, minScreenBounds.y + 1, maxScreenBounds.y - 1),
            transform.position.z);
    }
}
