using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueMele : MonoBehaviour {

    public Animator animacion;
    public Transform PuntoAtaque;
    public LayerMask enemyLayer;

    public float Rango = 0.5f;
    public int Daño = 1;

	void Update ()
    {
		if (Input.GetKeyDown(KeyCode.Z))
        {
            Ataque();
        }
	}
    void Ataque()
    {
        animacion.SetTrigger("Ataque");
        Collider2D[] golpearEnemigo = Physics2D.OverlapCircleAll(PuntoAtaque.position, Rango, enemyLayer);

        foreach(Collider2D enemy in golpearEnemigo)
        {
            enemy.GetComponent<enemy>().TakeDamage(Daño);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (PuntoAtaque == null)
            return;

        Gizmos.DrawWireSphere(PuntoAtaque.position, Rango);
    }
}
