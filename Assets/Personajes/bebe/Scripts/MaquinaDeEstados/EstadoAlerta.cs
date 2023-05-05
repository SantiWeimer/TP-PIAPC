using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAlerta : MonoBehaviour
{
    public float velocidadGiroBusqueda = 100f;
    public float duracionBusqueda = 4f;
    public Color colorEstado = Color.yellow;

    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;
    private float tiempoBuscando;


    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        
    }

    void OnEnable()
    {
        maquinaDeEstados.Indicador.material.color = colorEstado;
        controladorNavMesh.DetenerNavMeshAgent();
        tiempoBuscando = 0f;
        
    }
    
    void Update()  
    {

        RaycastHit hit;

        if(controladorVision.PuedeVerAlJugador(out hit)){

            
            controladorNavMesh.perseguirObjetivo = hit.transform;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }

        transform.Rotate(0f, velocidadGiroBusqueda * Time.deltaTime, 0f);
        tiempoBuscando += Time.deltaTime;

        if(tiempoBuscando >= duracionBusqueda)
        {
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPatrulla);
            return;
        }

    }
}
