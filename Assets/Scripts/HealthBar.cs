﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public Slider slider;

    public void SetMaxHealth(int health)
    {
        //Declarar el valor máximo para la salud y que empiece con ese valor de salud

        slider.maxValue = health;
        slider.value = health;
    }


    //Función para relacionar el valor de la salud del jugador con la barra.
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
