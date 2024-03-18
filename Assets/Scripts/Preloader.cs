using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Preloader : MonoBehaviour
{
    private CanvasGroup fadeGroup;
    private float loadTime;
    private float minimunLogoTime = 2.0f; // Minimo tiempo en cargar la escena

    private void Start()
    {
        //Toma el único CanvasGroup en la escena
        fadeGroup = FindObjectOfType<CanvasGroup>();
        //Comience con una pantalla blanca
        fadeGroup.alpha = 1;

        //pre load the game
        //si el tiempo de carga es excelente, dele un pequeño tiempo de búfer para que podamos apreciar el logotipo

        if (Time.time < minimunLogoTime)
            loadTime = minimunLogoTime;
        else
            loadTime = Time.time;
    }

    private void Update()
    {
        if (Time.time < minimunLogoTime)
        {
            fadeGroup.alpha = 1 - Time.time;
        }

        if (Time.time > minimunLogoTime && loadTime != 0)
        {
            fadeGroup.alpha = Time.time - minimunLogoTime;
            if (fadeGroup.alpha >= 1)
            {
                SceneManager.LoadScene("Menu");
            }
        }

    }
}