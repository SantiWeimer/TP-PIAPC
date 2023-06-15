using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoCorriendo : MonoBehaviour
{
    public Transform Salida;

    //public Animator anim;

    private MaquinaDeEstadosOsos maquinaDeEstadosOsos;
    private ControladorNavMeshOsos controladorNavMeshOsos;

    void Awake(){

        maquinaDeEstadosOsos = GetComponent<MaquinaDeEstadosOsos>();
        controladorNavMeshOsos = GetComponent<ControladorNavMeshOsos>();
        
    }
    

    
    void Update()
    {
        
        if(controladorNavMeshOsos.HemosLlegado()){    
         
           
        controladorNavMeshOsos.DetenerNavMeshAgent();
                    
        }
        

        
    }

    void OnEnable(){


        ActualizarWayPointDestino();
        //anim.Play("Corriendo");

    }

    void ActualizarWayPointDestino(){

        controladorNavMeshOsos.ActualizarPuntoDestinoNavMeshAgent(Salida.position);
    }

    
}
