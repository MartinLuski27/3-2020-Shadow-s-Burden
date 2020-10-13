using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class mainMenu : MonoBehaviour {

    public AudioMixer audioMixer;

    public void setVolumen (float volumen)
    {
        audioMixer.SetFloat("volumen", volumen * 10);
    }

    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
     
    public void quitGame()
    {
        Application.Quit();
    }
}
