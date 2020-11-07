using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quicksand : MonoBehaviour {

	public bool isInQuicksand = false;
	public GameObject player;
	public float inSandGravity = 0.3f;
	public float inSandDrag = 1f;

	void OnTriggerEnter2D(Collider2D collInfo)
	{
		if (collInfo.gameObject.name == "Player")
		{
			isInQuicksand = true;
			player.GetComponent<Rigidbody2D>().gravityScale = inSandGravity;
			player.GetComponent<Rigidbody2D>().drag = inSandDrag;
			player.GetComponent<PlayerMovement>().enabled = false;
			StartCoroutine(QuicksandDamage());
		}
	}
	void OnTriggerExit2D(Collider2D collInfo)
	{
		if (collInfo.gameObject.name == "Player")
		{
			isInQuicksand = false;
			player.GetComponent<Rigidbody2D>().gravityScale = 2.7f;
			player.GetComponent<Rigidbody2D>().drag = 0;
			player.GetComponent<PlayerMovement>().enabled = true;
		}
	}
	IEnumerator QuicksandDamage()
    {
		while (isInQuicksand)
		{
			player.GetComponent<PlayerHealth>().takeQuicksandDamage(1);
			yield return new WaitForSeconds(0.5f);
			if (player.GetComponent<PlayerHealth>().currentHealth <= 0)
				isInQuicksand = false;
		}
    }
}
