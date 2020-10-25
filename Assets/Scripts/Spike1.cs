using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike1 : MonoBehaviour {

    public GameObject player;
    void OnTriggerEnter2D()
    {
        player.transform.position = new Vector3(-41f, 3.3f, 0f);
        player.GetComponent<PlayerHealth>().takeDamage(1);
    }
}
