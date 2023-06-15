using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoQuietoRobot : MonoBehaviour
{
    public Animator anim;

    private MaquinaDeEstadosEnemigos maquinaDeEstados;
    private ControladorNavMeshEnemigos controladorNavMesh;
    private ControladorVisionEnemigos controladorVision;

    private int siguienteWayPoint;
    private int WayPointActual;

    void Awake(){

        maquinaDeEstados = GetComponent<MaquinaDeEstadosEnemigos>();
        controladorNavMesh = GetComponent<ControladorNavMeshEnemigos>();
        controladorVision = GetComponent<ControladorVisionEnemigos>();
        anim = GetComponent<Animator>();
    }

    void OnEnable(){

        anim.Play("Idle");
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

    public void OnTriggerEnter(Collider other){
        
        if(other.gameObject.CompareTag("Player") && enabled){

            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAtacando);
            return;
        }
    }
}
