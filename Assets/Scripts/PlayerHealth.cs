using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 5;
    public int currentHealth;

    public AudioSource hurtSound;

    public int moralidad = 0;

    public HealthBar healthBar;

    public Animator animator;
    
    // Use this for initialization
    //El jugador comienza con la máxima salud y se muestra en la barra de vida
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

    //El jugador recibe daño y se disminuye en la cantidad de daño recibido su vida
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
        hurtSound.Play();

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
