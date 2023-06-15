using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoQuieto : MonoBehaviour
{

    private MaquinaDeEstadosOsos maquinaDeEstadosOsos;
    private ControladorNavMeshOsos controladorNavMeshOsos;


    public Puntaje puntaje;

    private bool rescate = false;

    //public Animator anim;

    public int contMuertes;
    public int Totalmuertes;

    void Awake(){

        maquinaDeEstadosOsos = GetComponent<MaquinaDeEstadosOsos>();
        controladorNavMeshOsos = GetComponent<ControladorNavMeshOsos>();

    }

    private void OnEnable() {
        
        //anim.Play("Idle");
    }

    
    void Update()
    {
        VerificarMuertes();

    }

    public void VerificarMuertes(){

        if(contMuertes == Totalmuertes){

            if(rescate == false){
                puntaje.puntos += 1;
                rescate = true;
            }
            maquinaDeEstadosOsos.ActivarEstadoOsos(maquinaDeEstadosOsos.EstadoCorriendo);
            return;
        }
    }
}
