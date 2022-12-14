using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    public HealthBar healthBar;
    public Shooting shooting;
    private Animator animate;
    Vector2 movement;
    Vector2 mousePosition;

    // Health variables

    public int maxHealth = 100;
    public int currentHealth;
    public bool isParrying = false;

    // Start is called before the first frame update

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        animate = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        // stop game
        if (currentHealth <= 0)
        {
            new WaitForSeconds(6);
            SceneManager.LoadScene(0);
        }
    }

   // void FixedUpdate()
   // {
  //      rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

 //       Vector2 lookDirection = mousePosition - rb.position;
  //      float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
//        rb.rotation = angle;
    //}

    public void TakeDamage(int damage)
    {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
    }

    public void ArmsDamage(int damage)
    {
        if (!isParrying)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }

    public void AddHealth(int healthToAdd)
    {
        currentHealth += healthToAdd;
        healthBar.SetHealth(currentHealth);
    }

    public void Relight(int lightbeams)
    {
        shooting.AddAmmo(lightbeams);
    }

    public void ParryAnimation(bool parry)
    {
        animate.SetBool("parry", parry);
        isParrying = parry;
    }
}
