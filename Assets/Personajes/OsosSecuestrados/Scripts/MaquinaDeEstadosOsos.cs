using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaDeEstadosOsos : MonoBehaviour
{
    public MonoBehaviour EstadoQuieto;
    public MonoBehaviour EstadoCorriendo;
    public MonoBehaviour EstadoInicial;


    private MonoBehaviour estadoActual;
    

    void Start()
    {
        ActivarEstadoOsos(EstadoInicial);
    }

    public void ActivarEstadoOsos(MonoBehaviour nuevoEstado){

        if(estadoActual!=null) estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;

    }

    
}
