using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolverEscena : MonoBehaviour {

    public LevelLoader levelLoader;
	void OnTriggerEnter2D(Collider2D collInfo)
    {
        levelLoader.LoadPrevLevel();
    }
}
