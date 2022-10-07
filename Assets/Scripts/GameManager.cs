using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoBehaviour
{
    public GameObject shape;
    public GameObject beamPrefab;
    public float timePassed; 

    public Color firstColour = Color.black;
    public Color secondColour = Color.gray;
    private bool switchTheme = false;

    private float calibratedTime = 15;

    private int maxLayers = 3;
    private int lastIndex = 0;
    public ArrayList layerShapes = new ArrayList();
    public float initialLayerSeconds;
    public float layerDifferenceSeconds;

    private void Update()
    {
        timePassed += Time.deltaTime;
    }

    private void FixedUpdate()
    {            
        if (layerShapes.Count < maxLayers)
        {
            GameObject layer = Instantiate(shape);
            layer.transform.localScale *= initialLayerSeconds / calibratedTime;

            float ratioForTime = lastIndex * layerDifferenceSeconds - timePassed % layerDifferenceSeconds;
            layer.transform.localScale += lastIndex * layer.transform.localScale * (layerDifferenceSeconds / initialLayerSeconds);           
            layer.GetComponent<BarrierManagement>().maxTime = lastIndex * (layerDifferenceSeconds) + initialLayerSeconds;
            layer.GetComponent<BarrierManagement>().startHealth *= lastIndex + 1;

            foreach (SpriteRenderer child in layer.GetComponentsInChildren<SpriteRenderer>()) { 
                 child.material.color = switchTheme ? firstColour : secondColour;
            }

            layerShapes.Add(layer);
            lastIndex++;
        }
    }

    public void removeBarrier(GameObject barrier)
    {
        layerShapes.Remove(barrier);
        switchTheme = !switchTheme;

        GetComponent<Camera>().backgroundColor = switchTheme ? secondColour : firstColour;

        foreach (GameObject shape in layerShapes) {
            foreach (SpriteRenderer child in shape.GetComponentsInChildren<SpriteRenderer>())
            {
                child.material.color = switchTheme ? firstColour : secondColour;
            }
        }
    }
}
