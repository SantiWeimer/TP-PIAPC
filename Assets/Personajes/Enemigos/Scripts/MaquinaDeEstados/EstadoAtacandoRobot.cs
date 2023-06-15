using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoAtacandoRobot : MonoBehaviour
{
    public Animator anim;

    private MaquinaDeEstadosEnemigos maquinaDeEstados;
    private ControladorNavMeshEnemigos controladorNavMesh;
    private ControladorVisionEnemigos controladorVision;
    private int vida;

    private float tiempoEspera = 2f;
    private float tiempo;
    


    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstadosEnemigos>();
        controladorNavMesh = GetComponent<ControladorNavMeshEnemigos>();
        controladorVision = GetComponent<ControladorVisionEnemigos>();
        
        anim = GetComponent<Animator>();
    }

    void OnEnable(){

        
        controladorNavMesh.DetenerNavMeshAgent();

        anim.Play("Ataque");

        tiempo = 0f;
    }

    void Update(){

        tiempo += Time.deltaTime;
        
        vida = GetComponent<VidaRobots>().hp;
        
        if(tiempo >= tiempoEspera)
        {
            if(vida <= 50){

                controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
                maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucionHerido);
                return;

            }else{

                controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
                maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
                return;
            }
            
            
        }
    }
    
    
}
