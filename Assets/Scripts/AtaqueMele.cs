using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AtaqueMele : MonoBehaviour {

    public Animator animator;
    public Transform PuntoAtaque;
    public LayerMask enemyLayer;

    public AudioSource hitSound;

    public float Rango = 0.5f;
    public int Daño = 1;

    public float AttackRate = 1f;
    float NextAttackTime = 0f;

	void Update ()
    {
        if(Time.time >+ NextAttackTime)
        {
                if (Input.GetKeyDown(KeyCode.Z))
            {
                Ataque();
                NextAttackTime = Time.time + 1f / AttackRate;
            }
        }
		
	}
    void Ataque()
    {
        animator.SetTrigger("Ataque");
        Collider2D[] golpearEnemigo = Physics2D.OverlapCircleAll(PuntoAtaque.position, Rango, enemyLayer);
        hitSound.Play();

        foreach(Collider2D enemy in golpearEnemigo)
        {
            Debug.Log("We hit " + enemy.name);
            if (SceneManager.GetActiveScene().buildIndex != 3)
                enemy.GetComponent<EnemyHealth>().TakeDamage(Daño);
            else if (SceneManager.GetActiveScene().buildIndex == 3)
                enemy.GetComponent<JefeHealthRemplazo>().TakeDamage(Daño);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (PuntoAtaque == null)
            return;

        Gizmos.DrawWireSphere(PuntoAtaque.position, Rango);
    }
}
