using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JefeHealthRemplazo : MonoBehaviour {


    //DENTRO DEL PROYECTO YA HAY UN SCRIPT DE JEFEHEALTH
    //REEMPLAZEN LO QUE HAY EN ESE SCRIPT POR LO QUE HAY ACA, DEBERIA FUNCIONAR
    //METANLO EN EL JEFE Y SAQUENLE AL JEFE EL SCRIPT DE "enemy"
    //EN EL SCRIPT DE ATAQUE MELEE AGREGUEN LA SIGUIENTE LINEA:
    //enemy.GetComponent<JefeHealth>().TakeDamage(Daño); DEBAJO DE enemy.GetComponent<enemy>().TakeDamage(Daño);

	public int maxHealth = 15;
    int currentHealth;
    public Animator animator;
    
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
