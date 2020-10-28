using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCollide : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D info)
    {
        if (info.GetComponent<Collider>().tag == "bordePatrol")
        {
            Debug.Log("trigger mostri");
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
