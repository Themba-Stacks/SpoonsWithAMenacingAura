using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject shape;

    private float calibratedTime = 15;

    private int maxLayers = 3;
    private int lastIndex = 0;
    public ArrayList layerShapes = new ArrayList();
    public float initialLayerSeconds;
    public float layerDifferenceSeconds;

    private void FixedUpdate()
    {            
        if (layerShapes.Count < maxLayers)
        {
            GameObject layer = Instantiate(shape);
            layer.transform.localScale *= initialLayerSeconds / calibratedTime;
            layer.transform.localScale += lastIndex * layer.transform.localScale * (layerDifferenceSeconds / initialLayerSeconds);
            layer.GetComponent<BarrierManagement>().maxTime = lastIndex * layerDifferenceSeconds + initialLayerSeconds;

            layerShapes.Add(layer);
            lastIndex++;
        }
    }

    public void removeBarrier(GameObject barrier)
    {
        layerShapes.Remove(barrier);
    }
}
