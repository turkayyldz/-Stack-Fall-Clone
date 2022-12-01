using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    bool impact;



    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

   


   
    void Update()
    {
        // input kontrol.
        if (Input.GetMouseButtonDown(0))
        {
            impact = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            impact = false;
        }
    }


    
    private void FixedUpdate()
    {
        //fizik i�lemleri
        //A��a��ya do�r� hareket
        if (impact)
        {
            rb.velocity = new Vector3(0, -100 * Time.fixedDeltaTime * 7, 0);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Yukar�ya Do�ru hareket
        //( velocity ) ne bir ara�t�r g�z�m.
        if (!impact)
        {
            rb.velocity = new Vector3(0, 50 * Time.deltaTime* 5, 0);
        } 
    }
    private void OnCollisionStay(Collision collision)
    {
        if (!impact)
        {
            rb.velocity = new Vector3(0, 50 * Time.deltaTime * 5,0);
        }
    }

}
