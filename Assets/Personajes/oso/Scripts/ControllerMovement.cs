using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controller : MonoBehaviour
{
    public Animator anim;

    Rigidbody rb;
    public float speed = 200;
    public float rotationSpeed = 50f;
    public int vida;

    private float x, y;

    Transform tr;
    public Transform cameraShoulder;
    public Transform cameraHolder;
    private Transform cam;
    public Transform aimingCamera;
    
    private float rotY = 0f;


    public float cameraRotationSpeed = 200;
    public float minAngle = -45;
    public float maxAngle = 45;
    public float cameraSpeed = 200;

    
    private bool muerte = false;

    //arma

    public bool Shooting;
    public bool Aiming;

    public ArmaController arma;

    //vida
    public VidaUI descuentoVida;



    void Start() {

        tr = this.transform;
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        cam = Camera.main.transform;

    }


    void Update()
    {
       
        //actualizacion vida
        descuentoVida.vidaui = vida;

        if(muerte == false){

        //movimiento camara
        CameraControl();

        //movimiento personaje
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
        
        transform.Rotate(0f, x * Time.deltaTime * rotationSpeed, 0f);
        transform.Translate(0f, 0f, y * Time.deltaTime * speed);

        anim.SetFloat("veX", x);
        anim.SetFloat("veY", y);

        //disparo

        Shooting = Input.GetKeyDown(KeyCode.Mouse0);

        ArmaControl();

        //apuntar

        Aiming = Input.GetKey(KeyCode.Mouse1);

        if(vida <= 0){

            if(anim != null){

                anim.Play("MuerteOso");
                muerte = true;

                SceneManager.LoadScene("Perdiste");
                
            }

        }

        }
        

    }


    public void CameraControl(){

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaT = Time.deltaTime;

        rotY += mouseY * cameraRotationSpeed * deltaT;

        float rotX = mouseX * cameraRotationSpeed * deltaT;

        tr.Rotate(0, rotX, 0);
        

        rotY = Mathf.Clamp(rotY, minAngle, maxAngle);

        Quaternion localRotation = Quaternion.Euler(-rotY, 0, 0);
        cameraShoulder.localRotation = localRotation;

        if(Aiming){

            cam.position = Vector3.Lerp(cam.position, aimingCamera.position, cameraSpeed * deltaT);
            cam.rotation = Quaternion.Lerp(cam.rotation, aimingCamera.rotation, cameraSpeed * deltaT);

        }else{

            cam.position = Vector3.Lerp(cam.position, cameraHolder.position, cameraSpeed * deltaT);
            cam.rotation = Quaternion.Lerp(cam.rotation, cameraHolder.rotation, cameraSpeed * deltaT);
        }

        
    }

    private void OnTriggerEnter(Collider other) {
        
        //descuento vida golpe robot
        if(other.gameObject.tag == "Golpe"){

            vida = vida - 10;

        }
    }

    public void ArmaControl(){

        if(arma != null){

            if(Shooting){
                arma.Shoot();
            }
            
        }

        
    }
}
