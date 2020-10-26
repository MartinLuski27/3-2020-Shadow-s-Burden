using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 5;
    public int currentHealth;

    public HealthBar healthBar;

    public Animator animator;

    public Transform rb;
    
    // Use this for initialization
	void Start () {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.T))
        {
            takeDamage(1);
        }
	}

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");

        if(currentHealth <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("Muerto", true);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
