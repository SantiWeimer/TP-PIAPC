using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersecusionRobot : MonoBehaviour
{
    
    public Animator anim;

    private MaquinaDeEstadosEnemigos maquinaDeEstados;
    private ControladorNavMeshEnemigos controladorNavMesh;
    private ControladorVisionEnemigos controladorVision;


    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstadosEnemigos>();
        controladorNavMesh = GetComponent<ControladorNavMeshEnemigos>();
        controladorVision = GetComponent<ControladorVisionEnemigos>();
        anim = GetComponent<Animator>();
    }

    void OnEnable(){

        anim.Play("Correr");
    }

    
    void Update()
    {
        RaycastHit hit;
        if(!controladorVision.PuedeVerAlJugador(out hit, true)){

            controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
        }

        controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();

    }

    public void OnTriggerEnter(Collider other){
        
        if(other.gameObject.CompareTag("Player") && enabled){

            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoAtacando);
            return;
        }
    }
}
