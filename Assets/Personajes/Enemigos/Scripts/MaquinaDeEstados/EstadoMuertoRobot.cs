using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoMuertoRobot : MonoBehaviour
{
    public Animator anim;
    
    private ControladorNavMeshEnemigos controladorNavMesh;
    private ControladorVisionEnemigos controladorVision;


    void Awake()
    {
        
        controladorNavMesh = GetComponent<ControladorNavMeshEnemigos>();
        controladorVision = GetComponent<ControladorVisionEnemigos>();
        
        anim = GetComponent<Animator>();
    }

    void OnEnable(){

        

        controladorNavMesh.DetenerNavMeshAgent();
        
        if(anim != null){

            anim.Play("MuerteRobot");

        }
    }
    
    void Update()
    {
        

    }
}
