using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Animator animator;

    public float speed = 5f;
    public float rotationSpeed = 50f;

    private float x, y;
    
    void Update()
    {


        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        
        
        transform.Rotate(0f, x * Time.deltaTime * rotationSpeed, 0f);
        transform.Translate(0f, 0f, y * Time.deltaTime * speed);

        animator.SetFloat("veX", x);
        animator.SetFloat("veY", y);
    }

    
}
