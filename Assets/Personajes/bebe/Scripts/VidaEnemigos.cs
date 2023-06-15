using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigos : MonoBehaviour
{

    public int hp;
    public int mitadHP;
    public int danoBala;
    public Animator anim;

    private bool desacContador = true;
    private bool primeraVez = false;
    //contador para oso
    public EstadoQuieto contadorOso;
    
    //navmesh
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private MaquinaDeEstados maquinaDeEstados;
    
    void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        
    }

    void Start(){

        anim = GetComponent<Animator>();

    }


    void Update(){

        if(hp <= mitadHP){

            if(anim != null){

                anim.Play("Enojado");

            }

            if(primeraVez == false){

                this.navMeshAgent.speed += 3.5f;
                
                primeraVez = true;
            }
        }

        if(hp <= 0){

            if(desacContador == true){

                this.navMeshAgent.isStopped = true;
                contadorOso.contMuertes += 1;
                desacContador = false;

            if(anim != null){

                anim.Play("Muerto");
                anim.enabled = false;

            }
            }
            
            
            

            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoDerrotado);
            return;

        }
    }
    private void OnTriggerEnter(Collider other) {
        

        if(other.gameObject.tag == "bala"){

            hp -= danoBala;
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);

        }
    }
}
