using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EstadoCansado : MonoBehaviour
{
    
    
    public float duracionDescanso = 10f;
    public Animator animator;

    private MaquinaDeEstados maquinaDeEstados;
    private ControladorNavMesh controladorNavMesh;

    private float tiempoDescansando;

    void Awake()
    {
        maquinaDeEstados = GetComponent<MaquinaDeEstados>();
        controladorNavMesh = GetComponent<ControladorNavMesh>();
        animator = GetComponent<Animator>();
    }

    void OnEnable(){

        
        animator.enabled = false;
        tiempoDescansando = 0f;
        
    }

    
    void Update()
    {
        
        tiempoDescansando += Time.deltaTime;

        if(tiempoDescansando >= duracionDescanso)
        {
            controladorNavMesh.ActualizarPuntoDestinoNavMeshAgent();
            maquinaDeEstados.ActivarEstado(maquinaDeEstados.EstadoPatrulla);
            return;
        }

    }


}
