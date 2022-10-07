using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShard : MonoBehaviour
{
    public int healthToGive;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "body")
        {
            collision.gameObject.GetComponentInParent<Player>().AddHealth(healthToGive);
            Destroy(this.gameObject);
        }
    }
}
