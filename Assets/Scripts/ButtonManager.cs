using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;





public class ButtonManager : MonoBehaviour
{
    
    public void Jugar(string name)
    {
        SceneManager.LoadScene(name);
    }
    public void Salir()
    {
        Application.Quit();
    }
}
