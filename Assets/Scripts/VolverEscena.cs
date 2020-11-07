using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolverEscena : MonoBehaviour {

    public LevelLoader levelLoader;
    GameObject gameManager;

    void OnTriggerEnter2D(Collider2D collInfo)
    {
        if (collInfo.gameObject.name == "Player")
        {
            gameManager = GameObject.Find("GameManager");

            gameManager.GetComponent<DontDestroy>().specialSpawnPoint = true;
            levelLoader.LoadPrevLevel();
        }
    }
}
