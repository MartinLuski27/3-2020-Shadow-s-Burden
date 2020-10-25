using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike4 : MonoBehaviour {

    public GameObject player;
    void OnTriggerEnter2D()
    {
        player.transform.position = new Vector3(26f, 5f, 0f);
        player.GetComponent<PlayerHealth>().takeDamage(1);
    }
}
