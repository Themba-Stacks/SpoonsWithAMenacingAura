using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthShard : MonoBehaviour
{
    public int healthToGive;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            print("we collid");
            collision.gameObject.GetComponent<Shooting>().addHealth(healthToGive);
            Destroy(this.gameObject);
        }
    }
}
