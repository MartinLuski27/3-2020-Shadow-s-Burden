using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	public int moralidad = 0;
	public bool hasGem = false;
	public int health = 5;

	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(this.gameObject);
	}
}
