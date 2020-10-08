using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;
    
    public GameObject menuPausaUI;
	
	// Update is called once per frame
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

    public void Continuar ()
    {
        menuPausaUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pausar ()
    {
        menuPausaUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    
    public void GuardarySalir ()
    {
        //Falta la parte de guardado, por ahora solo tenemos la de salir al menú principal
        SceneManager.LoadScene(0);
    }
}
