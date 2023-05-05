using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPatrulla : MonoBehaviour
{
    public Transform[] WayPoints;
    public Color colorEstado = Color.green;
    public Animator animator;

    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;
    private ControladorVision controladorVision;

    private int siguienteWayPoint;
    private int WayPointActual;

    void Awake(){

        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        controladorVision = GetComponent<ControladorVision>();
        animator = GetComponent<Animator>();
    }
    

    
    void Update()
    {
        
        RaycastHit hit;
        if(controladorVision.PuedeVerAlJugador(out hit)){

            controladorNavMesh.perseguirObjetivo = hit.transform;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            return;
        }

        if(controladorNavMesh.HemosLlegado()){

            
            siguienteWayPoint = Random.Range(0, 4);
            if(WayPointActual != siguienteWayPoint){
                
                
            }else{
                siguienteWayPoint = (siguienteWayPoint + 1) % WayPoints.Length;
            }
            ActualizarWayPointDestino();
            WayPointActual = siguienteWayPoint;
            
        }
        

        
    }

    void OnEnable(){

        animator.enabled = true;
        maquinaDeEstados.Indicador.material.color = colorEstado;
        ActualizarWayPointDestino();

    }

    void ActualizarWayPointDestino(){

        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent(WayPoints[siguienteWayPoint].position);
    }

    public void OnTriggerEnter(Collider other){
        
        if(other.gameObject.CompareTag("Player") && enabled){

            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAlerta);
            return;
        }
    }
}
