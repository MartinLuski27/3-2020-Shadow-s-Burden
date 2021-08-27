using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class mainMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public AudioSource UIsound;

    public GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
    }

    //Función que se aplica al slider, que toma su valor y lo relaciona con el del volumen del mixer de audio principal, para reducir o aumentar el volumen.
    public void setVolumen (float volumen)
    {
        gameManager = GameObject.Find("GameManager");
        audioMixer.SetFloat("volumen", volumen * 10);
        gameManager.GetComponent<DontDestroy>().volumenValorSlider = volumen;
    }

    //Función que toma el número de la escena actual (menú) y carga la siguiente (pirámide) en estado de juego.
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        UIsound.Play();
    }
     
    //Función que cierra la aplicación por completo.
    public void quitGame()
    {
        Application.Quit();
        UIsound.Play();
    }

    public void Reset()
    {
        Debug.Log("reset");
        SceneManager.LoadScene(1);
    }
}
