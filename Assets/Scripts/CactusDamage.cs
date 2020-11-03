using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusDamage : MonoBehaviour {

    public GameObject player;

	void OnCollisionEnter2D(Collision2D collInfo)
	{
		if (collInfo.gameObject.name == "Player")
        {
            player.GetComponent<PlayerHealth>().takeDamage(1);
        }
    }
}
