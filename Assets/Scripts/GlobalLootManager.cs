using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalLootManager : Singleton<GlobalLootManager>
{
    public GameObject gunPickupPrefab;
    public GameObject expPickupPrefab;
    public KeyValuePairSerialized<float, BaseGun>[] weaponDropChances;

    public void RollDropTable(Vector3 pos)
    {
        RollExp(pos);
        //RollGun(pos);
    }

    private void RollExp(Vector3 pos)
    {
        GameObject GOExp = Instantiate<GameObject>(expPickupPrefab);
        GOExp.transform.position = pos;
    }

    private void RollGun(Vector3 pos)
    {
        List<BaseGun> gunsToDrop = new List<BaseGun>();
        foreach (KeyValuePairSerialized<float, BaseGun> pair in weaponDropChances)
        {
            float random = Random.value;

            if (random <= pair.Key)
            {
                gunsToDrop.Add(pair.Value);
            }
        }

        if (gunsToDrop.Count == 0)
            return;
        BaseGun droppedGun = gunsToDrop[Random.Range(0, gunsToDrop.Count)];
        GameObject GO = Instantiate<GameObject>(gunPickupPrefab);
        GO.transform.position = pos;
        GO.GetComponent<GunPickup>().baseGun = droppedGun;
    }
}
