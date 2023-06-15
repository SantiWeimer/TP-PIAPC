using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorNavMeshOsos : MonoBehaviour
{
    public Transform perseguirObjetivo;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    
    void Awake()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    
    public void ActualizarPuntoDestinoNavMeshAgent(Vector3 puntoDestino)
    {
        navMeshAgent.destination = puntoDestino;
        navMeshAgent.isStopped = false;
    }

    public void ActualizarPuntoDestinoNavMeshAgent(){

        ActualizarPuntoDestinoNavMeshAgent(perseguirObjetivo.position);
    }

    public void DetenerNavMeshAgent()
    {
        navMeshAgent.isStopped = true;

    }

    public bool HemosLlegado(){


        return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !navMeshAgent.pathPending;
    }
}
