using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BarrierManagement : MonoBehaviour
{
    public int currentHealth;
    public int startHealth;
    public int maxShardsDropped;
    public Camera mainCamera;

    // Order from most likely to least
    public GameObject[] shards;

    public Gradient scalingForShards;
    public float percentageToRemove;
    public float maxTime = 1;

    private Vector3 originalScale;
    public float time = 0;

    private void Start()
    {
        currentHealth = startHealth;
        originalScale = transform.localScale;
    }

    private void Update()
    {
        if (time < maxTime)
        {
            transform.localScale -= originalScale * (percentageToRemove / (maxTime * 100)) * Time.deltaTime;
            time += Time.deltaTime;
        }
    }

    public int shardToGen()
    {
        float value = Random.value;

        if (value <= 0.5)
            return 0;
        else if (value <= 0.75)
            return 1;
        else if (value <= 0.9)
            return 2;
        return 3;
    }

    public void decreaseBarrierHealth()
    {
        currentHealth--;

        if (currentHealth <= 0)
        {
            blowUp();
        }
    }

    public void blowUp()
    {
        Transform[] children = GetComponentsInChildren<Transform>().Where((x) => x.gameObject != this.gameObject).ToArray();

        while (maxShardsDropped > 0)
        {
            Transform randomChild = children[Random.Range(0, children.Length)];
            int index = shardToGen();

            Vector2 pos = randomChild.position;
            Vector2 scale = randomChild.lossyScale;

            // Generate the x position and then the y
            float yourX = Random.Range(pos.x - scale.x / 2, pos.x + scale.x / 2);
            float yourY = Random.Range(pos.y - scale.y / 2, pos.y + scale.y / 2);

            Vector2 positionForShard = new Vector2(yourX, yourY);
            GameObject instaShard = Instantiate(shards[index], positionForShard, randomChild.rotation);

            maxShardsDropped--;
        }

        this.gameObject.SetActive(false);
        Destroy(this);
    }
}
