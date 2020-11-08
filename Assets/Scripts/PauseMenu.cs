using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    
    public GameObject menuPausaUI;

    public AudioSource UIsound2;
	
	// Update is called once per frame
    //Función que detecta si el juego está pausado, entonces al apretar "escape", dependiendo de si lo está o no, pausa o continua el juego.
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Continuar();
            }
            else
            {
                Pausar();
            }
        }
	}

    //Función que hace que el juego continue y vuelva a estado de juego. Se puede acceder con "escape" o su mismo botón.
    public void Continuar ()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        UIsound2.Play();
    }

    public void Pausar ()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        UIsound2.Play();
    }
    
    //Función que sale al menú principal (no guarda porque el juego es corto y no es necesario).
    public void GuardarySalir ()
    {
        SceneManager.LoadScene(1);
        UIsound2.Play();
    }
}
