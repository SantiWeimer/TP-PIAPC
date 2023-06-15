using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float power = 100f;

    public float lifeTime = 5f;

    private float deltatiempo = 0f;

    Rigidbody bulletRb;

    void Start() {

       bulletRb = GetComponent<Rigidbody>(); 

       bulletRb.velocity = this.transform.forward * power;
    }

    void FixedUpdate() {
        

        deltatiempo += Time.deltaTime;

        if(deltatiempo >= lifeTime){

            Destroy(this.gameObject);
        }
    }
}
