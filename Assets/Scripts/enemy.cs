using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemy : MonoBehaviour {

    public int maxHealth = 15;
    int currentHealth;
    public Animator animator;
    public GameObject boss;
    

    void Start()
    {
        currentHealth = maxHealth;
        
	}

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            animator.SetTrigger("Hurt");
        }
    }
    
    void Die()
    {
        animator.SetBool("Muerto", true);
		GetComponent<Collider2D>().enabled = false;
    }
}
