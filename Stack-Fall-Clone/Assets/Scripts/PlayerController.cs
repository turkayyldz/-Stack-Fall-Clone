using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    bool impact;

    float currentTime;   // �arpt���m�zda zaman�m�z� artt�racak

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
            else // yenilmez de�ilse bunu yap�yor.
            {
                if (collision.gameObject.tag == "enemy")
                {
                    // Destroy(collision.transform.parent.gameObject); halkalar�n hepsini siliyor.
                    //Destroy(collision.gameObject); halkan�n par�as�n�n tag� ile etkile�ime girip, dokungu�u b�lgeyi siliyor.
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
