using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoShard : MonoBehaviour
{
    public int ammoToGive;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "body")
        {
            collision.gameObject.GetComponentInParent<Player>().Relight(ammoToGive);
            Destroy(this.gameObject);
        }
    }
}
