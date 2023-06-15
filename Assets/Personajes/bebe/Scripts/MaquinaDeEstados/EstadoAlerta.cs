using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAlerta : MonoBehaviour
{
    public float velocidadGiroBusqueda = 100f;
    public float duracionBusqueda = 4f;
    

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
        
        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
        
        
    }
    
    void Update()  
    {

        RaycastHit hit;

        if(controladorVision.PuedeVerAlJugador(out hit)){

            
            controladorNavMesh.perseguirObjetivo = hit.transform;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }


    }
}
