using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaController : MonoBehaviour
{
    public Transform shootPoint;
    
    public Transform bulletPrefab;


    void Start() {
        
        
    }


    public void Shoot(){

        Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
    }

    // public void DrawMira(Transform camera){

    //     RaycastHit hit;

    //     if(Physics.Raycast(camera.position, camera.forward, out hit)){

    //         shootPoint.LookAt(hit.point);

    //     }else{
    //         Vector3 end = camera.position + camera.forward;
    //         shootPoint.LookAt(end);
    //     }
    // }
}
