using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoPersecusionHerido : MonoBehaviour
{
    
    public Animator anim;

    private MaquinaDeEstadosEnemigos maquinaDeEstados;
    private ControladorNavMeshEnemigos controladorNavMesh;
    private ControladorVisionEnemigos controladorVision;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;

    private bool primeraVez = false;


    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstadosEnemigos>();
        controladorNavMesh = GetComponent<ControladorNavMeshEnemigos>();
        controladorVision = GetComponent<ControladorVisionEnemigos>();
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    void OnEnable(){

        if(primeraVez == false){

            this.navMeshAgent.speed -= 1.5f;
            primeraVez = true;
        }
        

        anim.Play("Herido");

        
    }
    
    void Update()
    {
        
        RaycastHit hit;
        if(!controladorVision.PuedeVerAlJugador(out hit, true)){
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucionHerido);
            return;
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
