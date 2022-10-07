using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamManagement : MonoBehaviour
{
    public Color wallDamageColour;
    public Color[] playerDamageColours;
    public TrailRenderer myTrail;
    private ParticleSystem myParticles;

    public int levelUpHits;

    private int levelUpProgress = 0;
    private int level = 0;
    private SpriteRenderer mySprite;
    private int levelCap;
    private float speed = 0;

    private void Start()
    {
        myParticles = GetComponent<ParticleSystem>();
        myTrail = GetComponentInChildren<TrailRenderer>();
        levelCap = playerDamageColours.Length;
        mySprite = GetComponent<SpriteRenderer>();
        speed = GetComponent<Rigidbody2D>().velocity.magnitude;
    }

    public void Update()
    {
        level = levelUpProgress / levelUpHits;
        GetComponent<Rigidbody2D>().velocity = transform.right.normalized * speed;

        if (level == 0)
        {
            mySprite.material.color = wallDamageColour;
            myTrail.startColor = wallDamageColour;
        }
        else
        {
            mySprite.material.color = playerDamageColours[level - 1];
            myTrail.startColor = playerDamageColours[level - 1];
        }
    }

    public void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Barrier")
        {

            if (level == 0)
            {
                col.gameObject.GetComponent<SideManagement>().decreaseHealth();
                levelUpProgress += levelUpHits;
            }
            else
                levelUpProgress = Mathf.Clamp(levelUpProgress + 1, levelUpProgress, levelCap * levelUpHits);

        }
        else if (col.gameObject.tag == "Player")
        {
            levelUpProgress = Mathf.Clamp(levelUpProgress - levelUpHits, 0, levelCap * levelUpHits);
        }

        Vector2 myDirection = GetComponent<Rigidbody2D>().velocity;
        float angle = 180*Mathf.Atan2(myDirection.y, myDirection.x)/Mathf.PI;

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
