using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    void Update()
    {
        this.transform.position = MouseUtils.Instance.GetMouseWorldPosition();
    }
}
