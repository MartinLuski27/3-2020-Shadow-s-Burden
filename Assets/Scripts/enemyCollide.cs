using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollide : MonoBehaviour {

    public GameObject momia;

	void OnTriggerEnter2D(Collider2D info)
    {
        if (info.gameObject.tag == "bordePatrol")
        {
            momia.GetComponent<patrolAI>().flip();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
