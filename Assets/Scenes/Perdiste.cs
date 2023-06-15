using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Perdiste : MonoBehaviour
{
    public void JugarDeNuevo(){
        SceneManager.LoadScene("Juego");
    }

    public void SalirAlMenu(){

        SceneManager.LoadScene("MenuInicial");

    }
}
