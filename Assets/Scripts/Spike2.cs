using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike2 : MonoBehaviour {

    public GameObject player;
    void OnTriggerEnter2D()
    {
        player.transform.position = new Vector3(-6f, 0f, 0f);
        player.GetComponent<PlayerHealth>().takeDamage(1);
    }
}
