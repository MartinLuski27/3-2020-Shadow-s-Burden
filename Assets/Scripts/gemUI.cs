using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gemUI : MonoBehaviour {

	bool gemObtained = false;
	public GameObject gameManager;
	public Text cText;

	// Update is called once per frame
	void Update () {
		this.gameManager = GameObject.Find("GameManager");

		gemObtained = gameManager.GetComponent<DontDestroy>().hasGem;

		if (gemObtained)
        {
			this.gameObject.GetComponent<Image>().enabled = true;
			cText.enabled = true;
        }
	}
}