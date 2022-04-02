using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLookHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateWeaponRotation();
    }

    private void UpdateWeaponRotation()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - this.transform.position;
        difference.Normalize();
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        if (rotationZ < -90 || rotationZ > 90)
        {
            if (this.transform.eulerAngles.y == 0)
            {
                this.transform.localRotation = Quaternion.Euler(180, 0, -rotationZ);
            }
            else if (this.transform.eulerAngles.y == 180)
            {
                this.transform.localRotation = Quaternion.Euler(180, 180, -rotationZ);
            }
        }
    }
}
