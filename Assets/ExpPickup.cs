using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpPickup : BasePickup
{
    public int exp = 1;

    protected override void ConsumePickup()
    {
        PlayerUtils.Instance.GetPlayerExpManager().AddExp(exp);
        Destroy(this.gameObject);
    }

}