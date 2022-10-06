using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideManagement : MonoBehaviour
{
    public Transform[] bounds;
    public int shardsToDrop;
    private BarrierManagement parentManager;

    private void Start()
    {
        parentManager = GetComponentInParent<BarrierManagement>();
    }

    public void decreaseHealth()
    {
        if (parentManager.currentHealth > 0)
            parentManager.decreaseBarrierHealth();
    }
}
