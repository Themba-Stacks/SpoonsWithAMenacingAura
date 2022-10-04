using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform lightBeamPoint;
    public GameObject lightBeamPrefab;
    public float lightBeamForce = 20f;
    private Animator animate;

    private void Start()
    {
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject lightbeam = Instantiate(lightBeamPrefab, lightBeamPoint.position, lightBeamPoint.rotation);
        lightbeam.transform.rotation = this.transform.rotation;
        Rigidbody2D rb = lightbeam.GetComponent<Rigidbody2D>();
        rb.AddForce(lightBeamPoint.up * lightBeamForce, ForceMode2D.Impulse);
        animate.SetTrigger("ShootTrigger");        
    }
}
