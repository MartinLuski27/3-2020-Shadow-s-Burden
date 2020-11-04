using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	public int moralidad = 0;
	public bool hasGem = false;
	public int health = 5;
	
	void Awake () {
		DontDestroyOnLoad(this.gameObject);
	}
}
