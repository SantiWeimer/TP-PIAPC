using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersecucion : MonoBehaviour
{
    
    public float duracionPersecucion = 10f;
    public Animator animator;

    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;

    private float tiempoPersiguiendo;

    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
    }

    void OnEnable(){

        tiempoPersiguiendo = 0f;
        
    }

    
    void Update()
    {
        RaycastHit hit;
        if(!controladorVision.PuedeVerAlJugador(out hit, true)){
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            return;
        }

        tiempoPersiguiendo += Time.deltaTime;

        if(tiempoPersiguiendo >= duracionPersecucion)
        {
            controladorNavMesh.DetenerNavMeshAgent();
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoCansado);
            return;
        }

        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
    }
}
