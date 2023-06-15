using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContadorPuerta : MonoBehaviour
{

    public Transform tr;
    

    //public int ContadorEnemigos;
    public int EnemigosNecesarios;

    private bool comprobar = true;

    public int valor = 1;


    
    void Update()
    {
        


        if(valor >= EnemigosNecesarios && comprobar == true){

            tr.Rotate(0, -45, 0);
            comprobar = false;
            

        }
        
    }


    
}
