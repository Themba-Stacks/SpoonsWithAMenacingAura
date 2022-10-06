using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoShard : MonoBehaviour
{
    public int ammoToGive;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<shooting>().addAmmo(ammoToGive);
            Destroy(this.gameObject);
        }
    }
}