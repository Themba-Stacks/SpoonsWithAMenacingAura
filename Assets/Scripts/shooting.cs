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
    private Animator animate;
    public Player player;

    private void Start()
    {
        animate = GetComponent<Animator>();
        currentAmmo = startAmmo;    
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        if(Input.GetButtonDown("Fire2") && currentAmmo > 0)
        {
            Shoot();
            // testing player health
            // player.TakeDamage(5);
        }
    }

    void Shoot()
    {
        GameObject lightbeam = Instantiate(lightBeamPrefab, transform.position + transform.right * rayDistance, transform.rotation);
        Rigidbody2D rb = lightbeam.GetComponent<Rigidbody2D>();
        rb.AddForce(lightbeam.transform.right * lightBeamForce, ForceMode2D.Impulse);
        currentAmmo--;
    }

    public void addHealth(int healthToAdd)
    {
        print("i guess");
    }

    public void addAmmo(int ammoToAdd)
    {
        currentAmmo = Mathf.Clamp(currentAmmo + ammoToAdd, 0, startAmmo);
        // rb.AddForce(lightBeamPoint.up * lightBeamForce, ForceMode2D.Impulse);
        // animate.SetTrigger("ShootTrigger");
    }
}
