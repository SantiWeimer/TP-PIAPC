using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaquinaDeEstadosEnemigos : MonoBehaviour
{
    public MonoBehaviour EstadoQuieto;
    public MonoBehaviour EstadoPersecucion;
    public MonoBehaviour EstadoPersecucionHerido;
    public MonoBehaviour EstadoAtacando;
    public MonoBehaviour EstadoMuerto;
    public MonoBehaviour EstadoInicial;


    public MeshRenderer Indicador;


    public MonoBehaviour estadoActual;
    

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
