using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Puntaje : MonoBehaviour
{
    public int puntos;
    
    private TextMeshProUGUI textMesh;

    private void Start() {
        textMesh = GetComponent<TextMeshProUGUI>();
        
    }

    private void Update() {
        
        textMesh.text = puntos.ToString("0");

        if(puntos == 6){

            SceneManager.LoadScene("Ganaste");
        }
        
    }


}
