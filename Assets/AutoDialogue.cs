using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDialogue : MonoBehaviour {

	public GameObject dialogo;
    public GameObject player;
    public Animator animator;

	void OnTriggerEnter2D(Collider2D collInfo)
    {
		if (collInfo.CompareTag("Player"))
        {
            animator.SetTrigger("forceIdle");
			dialogo.GetComponent<NPCDialogue>().hasEnteredAuto = true;
            player.GetComponent<PlayerMovement>().enabled = false;
            player.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            Destroy(this.gameObject);
        }
    }
}
