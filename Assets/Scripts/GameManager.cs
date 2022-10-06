using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] layerShapes;

    private float calibratedTime = 15;

    public float layerDifferenceSeconds;
    public float initialLayerSeconds;

    private void Start()
    {
        for(int i = 0; i < layerShapes.Length; i++)
        {
            GameObject layer = Instantiate(layerShapes[i]);
            layer.transform.localScale *= initialLayerSeconds / calibratedTime;
            layer.transform.localScale += i * layer.transform.localScale * (layerDifferenceSeconds / initialLayerSeconds);
            layer.GetComponent<BarrierManagement>().maxTime = i * layerDifferenceSeconds + initialLayerSeconds;
        }
    }
}
