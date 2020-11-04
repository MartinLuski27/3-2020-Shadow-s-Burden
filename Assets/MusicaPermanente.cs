using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicaPermanente : MonoBehaviour {
	void Awake () {
		DontDestroyOnLoad(this.gameObject);
	}
}
