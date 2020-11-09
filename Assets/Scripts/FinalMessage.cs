using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalMessage : MonoBehaviour
{
	GameObject gameManager;
	int moralidad = 0;
	public string mensajeBueno;
	public string mensajeNeutro;
	public string mensajeMalo;

    public AudioSource UIsound3;

	// Use this for initialization
	void Start()
	{
		gameManager = GameObject.Find("GameManager");
		if (gameManager != null) moralidad = gameManager.GetComponent<DontDestroy>().moralidad;

		if (moralidad > 0)
        {
			gameObject.GetComponent<Text>().text = mensajeBueno;
        }
		else if (moralidad < 0)
        {
			gameObject.GetComponent<Text>().text = mensajeMalo;
		}
		else
        {
			gameObject.GetComponent<Text>().text = mensajeNeutro;
		}
	}

	void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
            UIsound3.Play();
        }
    }
}
