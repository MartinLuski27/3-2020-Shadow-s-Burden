using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

    //ESTE SCRIPT VA EN LOS ENEMIGOS

    public int maxHealth = 2;
    int currentHealth;
    public Animator animator;
    public GameObject enemigo;
    GameObject jugador;

    public int attackDamage2 = 1;
	
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public LayerMask attackMask;
    

    void Start()
    {
        currentHealth = maxHealth;
	}

    void Update()
    {
        //Attack();
    }

    void OnTriggerEnter2D(Collider2D collInfo)
    {
        if (collInfo.gameObject.name == "Player")
        {
            jugador = collInfo.gameObject;
            jugador.GetComponent<PlayerHealth>().takeDamage(attackDamage2);
            
            this.enabled = false;
            StartCoroutine(iFrames());
        }
    }
    IEnumerator iFrames()
    {
        yield return new WaitForSeconds(1f);
        this.enabled = true;
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
        //Aca santi, que sabe, haga para que se destruya al morir, porque yo no puedo hacer cosas con las animaciones
        animator.SetBool("Muerto", true);
		enemigo.GetComponent<Collider2D>().enabled = false;
        enemigo.GetComponent<patrolAI>().enabled = false;
        StartCoroutine(Desaparecer());
    }

    IEnumerator Desaparecer()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);
    }

    /*public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<PlayerHealth>().takeDamage(attackDamage2);
		}
	}*/

	void OnDrawGizmosSelected()
	{
        //esto dibuja el circulo donde ta la hitbox de ataque, hay que mover los valores de offset y attackrange que quede bien
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
}
