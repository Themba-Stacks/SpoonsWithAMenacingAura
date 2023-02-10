using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform lightBeamPoint;
    public GameObject lightBeamPrefab;
    public float rayDistance;
    public float lightBeamForce = 20f;
    public int startAmmo = 0;
    public int  currentAmmo = 0;
    public Player player;
    public Rigidbody2D rb;

    private void Start()
    {
        currentAmmo = startAmmo;    
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;

        if(Input.GetButtonDown("Fire2") && currentAmmo > 0)
        {
           Shoot();
            Parry(false);
        }

        if(Input.GetMouseButtonDown(0))
        {
            Parry(true);
        }

        if(Input.GetMouseButtonUp(0))
        {
            Parry(false);
        }
    }

    void Shoot()
    {
        GameObject lightbeam = Instantiate(lightBeamPrefab, transform.position + transform.right * rayDistance, transform.rotation);
        Rigidbody2D rb = lightbeam.GetComponent<Rigidbody2D>();
        rb.AddForce(lightbeam.transform.right * lightBeamForce, ForceMode2D.Impulse);
        currentAmmo--;
    }

    void Parry(bool parry)
    {
        player.ParryAnimation(parry);
        print("Player is parrying");
    }

    public void AddAmmo(int ammoToAdd)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + ammoToAdd, 0, startAmmo);
    }
}
