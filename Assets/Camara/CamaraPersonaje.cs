using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraPersonaje : MonoBehaviour
{
    public Transform player;
    public Vector3 camOffset;

    [Range(0.1f, 1.0f)]
    public float Smooth = 0.1f;

    public bool rotacionActive = true;
    public float velRotacion = 5f;

    public bool lookAtPlayer = false;

    void Start()
    {
        camOffset = transform.position - player.position;
    }

    
    void FixedUpdate()
    {

        if(rotacionActive){
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * velRotacion, Vector3.up);

            camOffset = camTurnAngle * camOffset;
        }
        
        Vector3 newPos = player.position + camOffset;

        transform.position = Vector3.Slerp(transform.position, newPos, Smooth);

        if(lookAtPlayer  || rotacionActive){
            transform.LookAt(player);
        }
    }
}
