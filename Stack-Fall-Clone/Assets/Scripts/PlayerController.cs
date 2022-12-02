using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    bool impact;

    float currentTime;   // çarptýðýmýzda zamanýmýzý arttýracak

    bool invincible;

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
        if (invincible)
        {
            currentTime -= Time.deltaTime * .35f;
        }
        else
        {
            if (impact)
            {
                currentTime += Time.deltaTime * 0.8f;
            }
            else
            {
                currentTime -= Time.deltaTime * 0.5f;
            }
        }
       
        if (currentTime>=1)
        {
            currentTime = 1;
            invincible = true;
        }
        else if (currentTime<=0)
        {
            currentTime = 0;
            invincible = false;
        }
    }


    
    private void FixedUpdate()
    {
        //fizik iþlemleri
        //Aþþaðýya doðrý hareket
        if (impact)
        {
            rb.velocity = new Vector3(0, -100 * Time.fixedDeltaTime * 7, 0);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        // Yukarýya Doðru hareket
        //( velocity ) ne bir araþtýr gözüm.

        if (!impact)
        {
            rb.velocity = new Vector3(0, 50 * Time.deltaTime * 5, 0);
        }
        else
        {
            if (invincible)
            {
                if (collision.gameObject.tag == "enemy"&& collision.gameObject.tag == "plane")
                {
                   
                    Destroy(collision.transform.parent.gameObject);
                }
               
            }
            else // yenilmez deðilse bunu yapýyor.
            {
                if (collision.gameObject.tag == "enemy")
                {
                    // Destroy(collision.transform.parent.gameObject); halkalarýn hepsini siliyor.
                    //Destroy(collision.gameObject); halkanýn parçasýnýn tagý ile etkileþime girip, dokunguðu bölgeyi siliyor.
                    Destroy(collision.transform.parent.gameObject);
                }
                else if (collision.gameObject.tag == "plane")
                {
                    Debug.Log("Game Over");
                }
            }
            
           
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
