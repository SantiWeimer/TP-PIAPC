using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaDeEstados : MonoBehaviour
{
    public MonoBehaviour EstadoPatrulla;
    public MonoBehaviour EstadoAlerta;
    public MonoBehaviour EstadoPersecucion;
    public MonoBehaviour EstadoCansado;
    public MonoBehaviour EstadoDerrotado;
    public MonoBehaviour EstadoInicial;


    private MonoBehaviour estadoActual;
    

    void Start()
    {
        ActivarEstado(EstadoInicial);
    }

    public void ActivarEstado(MonoBehaviour nuevoEstado){

        if(estadoActual!=null) estadoActual.enabled = false;
        estadoActual = nuevoEstado;
        estadoActual.enabled = true;

    }

    
}
