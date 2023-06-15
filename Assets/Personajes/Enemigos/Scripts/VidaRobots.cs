using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaRobots : MonoBehaviour
{
    public int hp;
    public int mitadHP;
    public int danoBala;
    

    //contador puerta

    private bool vivo = true;
    private bool cont1 = true;

    public ContadorPuerta contador;
    public EstadoQuieto contadorOso;
    
    
    //navmesh
    
    private MaquinaDeEstadosEnemigos maquinaDeEstados;
    private ControladorNavMeshEnemigos controladorNavMesh;
    
    void Awake()
    {
        controladorNavMesh = GetComponent<ControladorNavMeshEnemigos>();
        maquinaDeEstados = GetComponent<MaquinaDeEstadosEnemigos>();
        
        
    }

    




    void Update(){

        if(hp <= mitadHP && vivo == true){

            
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucionHerido);
            vivo = false;
            return;

        }

        if(hp <= 0 && vivo == false){

            if(cont1 == true){
                cont1 = false;
                contador.valor += 1;
                contadorOso.contMuertes += 1;
                
                maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoMuerto);
                return;
            }
            
        }
    }


    private void OnTriggerEnter(Collider other) {
        

        if(other.gameObject.tag == "bala" && hp > 0){

            hp -= danoBala;




            if(hp <= mitadHP){
                maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucionHerido);
                
            }else{

                maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPersecucion);
            }

            
            
            

        }

    }
}
